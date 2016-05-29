using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace CleanDuplicationFiles
{
    public partial class FrmMain : Form
    {
        Thread thCollection = null;
        Thread thAnalysis = null;
        Thread thCompute = null;
        public static string connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\业余开发\CleanDuplicateFiles\DB\FileInfos.accdb";
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbd.SelectedPath;
            }
        }

        private void btnCollectBaseInfo_Click(object sender, EventArgs e)
        {
            txtRunningLog.Text = "Collect FileInfo Start Time:" + DateTime.Now.ToLongTimeString();
            thCollection = new Thread(new ThreadStart(CollectFiles));
            thCollection.Start();
            
        }

        private void CollectFiles()
        {
            CollectBaseFileInfo cbfi = new CollectBaseFileInfo(txtDirectory.Text);
            cbfi.RecursionToList();
            txtRunningLog.Text += "\r\nCollect FileInfo End Time:" + DateTime.Now.ToLongTimeString();
            txtRunningLog.Text += "\r\nWrtie DB Start Time:" + DateTime.Now.ToLongTimeString();
            cbfi.WriteToDB();
            txtRunningLog.Text += "\r\nWrtie DB End Time:" + DateTime.Now.ToLongTimeString();
            thCompute = new Thread(new ThreadStart(CollectCRC32ByIDs));
            thCompute.Start();

        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            lvResult.Items.Clear();
            thAnalysis = new Thread(new ThreadStart(AnalysisNameSize));
            thAnalysis.Start();
            //AnalysisNameSize();

        }

        private void AnalysisNameSize()
        {
            AnalysisNameSizeCRC("DuplicateCountByNameSizeCRC");
        }

        private void AnalysisNameSizeCRC(string viewName)
        {
            lvResult.BeginUpdate();
            btnAnalysis.Enabled = false;
            ///只适用文件名与文件大小的判断
            OleDbConnection conn = new OleDbConnection(connString);
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + viewName);
                cmd.Connection = conn;
                OleDbDataReader reader = cmd.ExecuteReader();
                int i = 0;
                string fileName = "";
                string fileSize = "0";
                while (reader.Read())
                {
                    if (reader["FileSize"].ToString() != fileSize
                        || fileName != reader["FileName"].ToString()
                        )
                    {
                        i++;
                        fileSize = reader["FileSize"].ToString();
                        fileName = reader["FileName"].ToString();
                    }

                    ListViewItem lvi = new ListViewItem();
                    if (i % 2 == 0)
                        lvi.BackColor = Color.YellowGreen;
                    else
                        lvi.BackColor = Color.White;

                    lvi.SubItems.Add(i.ToString());

                    lvi.SubItems.Add(fileName);
                    lvi.SubItems.Add((Convert.ToInt32(fileSize) / 1024).ToString());
                    lvi.SubItems.Add(reader["DuplicateCount"].ToString());
                    lvi.SubItems.Add(reader["FileCreateTime"].ToString());
                    lvi.SubItems.Add(reader["FileLastModifyTime"].ToString());
                    lvi.SubItems.Add(reader["FileAllPath"].ToString());
                    lvi.SubItems.Add(reader["FileCRC32"].ToString());
                    lvi.SubItems.Add(reader["ID"].ToString());

                    lvResult.Items.Add(lvi);

                }
            }
            lvResult.EndUpdate();
            btnAnalysis.Enabled = true;
        }

        private void lvResult_DoubleClick(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count > 0)
            {
                System.Diagnostics.Process.Start("explorer.exe", lvResult.SelectedItems[0].SubItems[7].Text.Substring(0, lvResult.SelectedItems[0].SubItems[7].Text.LastIndexOf(@"\")));
            }
        }

        private void btnComputeCRC32_Click(object sender, EventArgs e)
        {
            thCompute = new Thread(new ThreadStart(CollectCRC32ByIDs));
            thCompute.Start();
            //CollectCRC32ByIDs();
        }

        private void CollectCRC32ByIDs()
        {

            btnComputeCRC32.Enabled = false;
            AnalysisNameSizeCRC("DuplicateCountByNameSize");
            Dictionary<string, string> ids = new Dictionary<string, string>();
            for (int i = 0; i < lvResult.Items.Count; i++)
            {
                ids.Add(lvResult.Items[i].SubItems[9].Text.ToString(),
                    lvResult.Items[i].SubItems[7].Text.ToString());
            }

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand();
            using (conn)
            {
                conn.Open();
                cmd.Connection = conn;



                int finishCount = 0;
                foreach (var id in ids)
                {
                    byte[] bytes = File.ReadAllBytes(id.Value);
                    uint crcValue = Crc32C.Crc32CAlgorithm.Compute(bytes);

                    cmd.CommandText = "Update FileInfos set FileCRC32 ='" + crcValue.ToString() + "'  where ID = " + id.Key.ToString();

                    int i = cmd.ExecuteNonQuery();
                    finishCount++;
                    txtRunningLog.Text = "Compute CRC Finished:" + finishCount + " / " + ids.Count;

                }

            }

            btnComputeCRC32.Enabled = true;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thAnalysis != null)
            {
                if (thAnalysis.ThreadState == ThreadState.Running)
                {
                    thAnalysis.Abort();
                }
            }


            if (thCollection != null)
            {
                if (thCollection.ThreadState == ThreadState.Running)
                {
                    thCollection.Abort();
                }
            }


            if (thCompute != null)
            {
                if (thCompute.ThreadState == ThreadState.Running)
                {
                    thCompute.Abort();
                }
            }
        }
        private void btnKeepOldFiles_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lvResult.Items.Count; i++)
            {
                lvResult.Items[i].Checked = true;
            }

            string curGroupID = "0";

            DateTime OldestFileTime = DateTime.MaxValue;
            int OldFileIndex = -1;
            for (int i = 0; i < lvResult.Items.Count; i++)
            {
                string groupID = lvResult.Items[i].SubItems[1].Text.ToString();
                if (groupID != curGroupID)
                {
                    if (OldFileIndex != -1)
                    {
                        lvResult.Items[OldFileIndex].Checked = false;
                    }
                    OldestFileTime = Convert.ToDateTime(lvResult.Items[i].SubItems[5].Text.ToString());
                    OldFileIndex = i;
                    curGroupID = groupID;

                }
                else
                {
                    DateTime curCreateTime = Convert.ToDateTime(lvResult.Items[i].SubItems[5].Text.ToString());
                    if (curCreateTime.Ticks - OldestFileTime.Ticks < 0)
                    {
                        OldestFileTime = curCreateTime;
                        OldFileIndex = i;
                    }
                }
            }
            if (OldFileIndex != -1)
            {
                lvResult.Items[OldFileIndex].Checked = false;
            }
        }
        private void btnKeepNewFiles_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvResult.Items.Count; i++)
            {
                lvResult.Items[i].Checked = true;
            }

            string curGroupID = "0";
            DateTime NewestFileDate = DateTime.MinValue;
            int NewFilesIndex = -1;
            for (int i = 0; i < lvResult.Items.Count; i++)
            {
                string groupID = lvResult.Items[i].SubItems[1].Text.ToString();
                if (groupID != curGroupID)
                {
                    if (NewFilesIndex != -1)
                    {
                        lvResult.Items[NewFilesIndex].Checked = false;
                    }
                    NewestFileDate = Convert.ToDateTime(lvResult.Items[i].SubItems[5].Text.ToString());
                    NewFilesIndex = i;
                    curGroupID = groupID;

                }
                else
                {
                    DateTime curCreateTime = Convert.ToDateTime(lvResult.Items[i].SubItems[5].Text.ToString());
                    if (curCreateTime.Ticks - NewestFileDate.Ticks > 0)
                    {
                        NewestFileDate = curCreateTime;
                        NewFilesIndex = i;
                    }
                }
            }
            if (NewFilesIndex != -1)
            {
                lvResult.Items[NewFilesIndex].Checked = false;
            }

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            if (MessageBox.Show("是否确认删除选中的文件（请仔细检查打勾需要删除的文件）？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < lvResult.Items.Count; i++)
                {
                    if (lvResult.Items[i].Checked)
                    {
                        File.Delete(lvResult.Items[i].SubItems[7].Text.ToString());
                        signFileRemoved(lvResult.Items[i].SubItems[9].Text.ToString());
                    }
                }
            }
            btnAnalysis_Click(sender, e);
            btnRemove.Enabled = true;
        }

        private void signFileRemoved(string id)
        {


            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand();
            using (conn)
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Update FileInfos set IsDelete ='Yes' where ID = " + id.ToString();

                int i = cmd.ExecuteNonQuery();

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;



namespace CleanDuplicationFiles
{
    class CollectBaseFileInfo
    {
        private OleDbConnection conn = new OleDbConnection();
        private string directory;
        public CollectBaseFileInfo(string path)
        {
            directory = path;
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\业余开发\CleanDuplicateFiles\DB\FileInfos.accdb";

        }

        private List<EVFileInfo> evFileInfos = new List<EVFileInfo>();
        public List<EVFileInfo> EvFileInfos
        {
            get
            {
                return EvFileInfos;
            }

        }

        public void WriteToDB()
        {
            OleDbCommand cmd = new OleDbCommand();
            using (conn)
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM FileInfos";
                cmd.ExecuteNonQuery();
                OleDbParameter[] pas = new OleDbParameter[6];
                pas[0] = new OleDbParameter("@p1", OleDbType.VarChar);
                pas[1] = new OleDbParameter("@p2", OleDbType.VarChar);
                pas[2] = new OleDbParameter("@p3", OleDbType.VarChar);
                pas[3] = new OleDbParameter("@p4", OleDbType.BigInt);
                pas[4] = new OleDbParameter("@p5", OleDbType.Date);
                pas[5] = new OleDbParameter("@p6", OleDbType.Date);

                cmd.Parameters.AddRange(pas);
                int rows = 0;
                foreach (var efi in evFileInfos)
                {

                    cmd.CommandText = "Insert into FileInfos(FileName,Ext,FileAllPath,FileSize,FileCreateTime,FileLastModifyTime) values(@p1,@p2,@p3,@p4,@p5,@p6)";
                    pas[0].Value = efi.FileName;
                    pas[1].Value = efi.FileExt;
                    pas[2].Value = efi.FileAllPath;
                    pas[3].Value = efi.FileSize / 1024;
                    pas[4].Value = efi.FileCreateTime;
                    pas[5].Value = efi.FileLastModifyTime;

                    rows += cmd.ExecuteNonQuery();

                }


            }
        }

        
        public void RecursionToList()
        {
            RecursionToList(directory);
        }
        private void RecursionToList(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            foreach (var f in files)
            {
                EVFileInfo fi = getFileInfo(f);
                evFileInfos.Add(fi);
            }
            string[] directories = Directory.GetDirectories(directory);
            foreach (var d in directories)
            {
                RecursionToList(d);
            }


        }

        private EVFileInfo getFileInfo(string filePath)
        {
            EVFileInfo efi = new EVFileInfo();
            FileInfo fi = new FileInfo(filePath);
            efi.FileAllPath = filePath;
            efi.FileExt = fi.Extension;
            efi.FileName = fi.Name;
            efi.FileSize = fi.Length;
            efi.FileCreateTime = fi.CreationTime;
            efi.FileLastModifyTime = fi.LastWriteTime;
            return efi;
        }
    }
}

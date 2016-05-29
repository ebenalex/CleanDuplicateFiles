using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDuplicationFiles
{
    class EVFileInfo
    {
        public string FileAllPath { get; set; }
        public string FileExt { get; set; }
        public string FileName { get; set; }
        //K
        public long FileSize { get; set; }
        public DateTime FileCreateTime { get; set; }
        public DateTime FileLastModifyTime { get; set; }
        public string FileCRC32 { get; set; }
        public string FileMD5 { get; set; }
        public string FileAuthor { get; set; }


    }
}

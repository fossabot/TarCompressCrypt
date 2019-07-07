﻿using TCC.Lib.Blocks;
using TCC.Lib.Database;

namespace TCC.Lib.Options
{
    public class CompressOption : TccOption
    {
        public BlockMode BlockMode { get; set; }
        public CompressionAlgo Algo { get; set; }
        public int CompressionRatio { get; set; }
        public BackupMode BackupMode { get; set; }
    }
}
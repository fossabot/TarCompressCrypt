﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Lib.Command
{
    public class CommandResult
    {
        public int ExitCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Output { get; set; }
        public string Errors { get; set; }
        public bool HasError => !String.IsNullOrEmpty(Errors);
        public string Command { get; set; }
        public List<string> Infos { get; set; }
        public long ElapsedMilliseconds { get; set; }

        public void ThrowOnError()
        {
            if (HasError)
            {
                var sb = new StringBuilder();
                sb.AppendLine("command : " + Command);
                sb.AppendLine("error : " + Errors);
                throw new TccException(sb.ToString());
            }
        }
    }
}
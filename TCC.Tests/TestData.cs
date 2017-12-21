﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TCC.Tests
{
    public class TestData
    {
        public List<FileInfo> Files { get; set; }
        public List<DirectoryInfo> Directories { get; set; }
        public string Target { get; set; }

        public CompressOption GetTccCompressOption(PasswordMode passwordMode, string targetFolder)
        {
            string src;
            if (Files != null)
            {
                src = String.Join(" ", Files.Select(i => i.FullName));
            }
            else if (Directories != null)
            {
                src = String.Join(" ", Directories.Select(i => i.FullName));
            }
            else
            {
                throw new MissingMemberException();
            }
            Target = targetFolder;

            var compressOption = new CompressOption
            {
                BlockMode = BlockMode.Individual,
                SourceDirOrFile = src,
                DestinationDir = Target,
                Threads = "all",
                PasswordMode = passwordMode,
                Password = "1234"
            };


            return compressOption;
        }

        public DecompressOption GetTccDecompressOption(PasswordMode passwordMode, string decompressedFolder)
        {
            string src;
            if (Files != null)
            {
                src = String.Join(" ", Files.Select(i => i.FullName));
            }
            else if (Directories != null)
            {
                src = String.Join(" ", Directories.Select(i => i.FullName));
            }
            else
            {
                throw new MissingMemberException();
            }
            Target = decompressedFolder;

            var decompressOption = new DecompressOption
            {
                SourceDirOrFile = src,
                DestinationDir = Target,
                Threads = "all",
                PasswordMode = passwordMode
            };


            return decompressOption;
        }

        public static TestData CreateFiles(int nbFiles, int sizeMb, string folder)
        {
            foreach (var i in Enumerable.Range(0, nbFiles))
            {
                var filePath = TestHelper.NewFileName(folder);
                TestHelper.FillRandomFile(filePath, sizeMb);
                Console.Out.WriteLine("File created : " + filePath);
            }
            Thread.Sleep(150); // for filesystem latency
            return new TestData
            {
                Directories = new List<DirectoryInfo> { new DirectoryInfo(folder) }
            };
        }


    }
}
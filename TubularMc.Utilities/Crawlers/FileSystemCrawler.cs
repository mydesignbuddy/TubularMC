using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Utilities
{
    public class FileSystemCrawler
    {
        public int TotalFilesFound { get; set; }
        public int TotalValidFilesFound {get;set;}
        public int TotalDirectoriesFound { get; set; }
        public IList<string> Files { get; set; } 
        public int RecursiveLevel { get; set; }
        public string SourcePath { get; set; }
        public IList<string> FilterByFileExtensions { get; set; }

        public FileSystemCrawler()
        {
        }

        public FileSystemCrawler(string sourceDirectory)
        {
            SourcePath = sourceDirectory;
        }

        public FileSystemCrawler(string sourceDirectory, int recursiveLevel)
        {
            SourcePath = sourceDirectory;
            RecursiveLevel = recursiveLevel;
        }

        public FileSystemCrawler(string sourceDirectory, int recursiveLevel, IList<string> filterByFileExtensions)
        {
            SourcePath = sourceDirectory;
            RecursiveLevel = recursiveLevel;
            FilterByFileExtensions = filterByFileExtensions;
        }

        public IList<string> Scan()
        {
            Clear();
            Files = new List<string>();
            TraverseDirectory(SourcePath, 0, FilterByFileExtensions);
            return Files;
            /*Console.WriteLine("Total Folders: {0}, Total Files: {1} Total Valid Files: {2}",
                TotalDirectoriesFound, TotalFilesFound, TotalValidFilesFound
            );*/
        }
        
        private void Clear()
        {
            if (Files != null) Files.Clear();
            TotalDirectoriesFound = 0;
            TotalFilesFound = 0;
            TotalValidFilesFound = 0;
        }

        private void TraverseDirectory(string sourceDirectory, int recursiveLevel, IList<string> filterByFileExtensions)
        {
            if (recursiveLevel <= RecursiveLevel)
            {
                // Process the list of files found in the directory. 
                string[] fileEntries = Directory.GetFiles(sourceDirectory);
                foreach (string filePath in fileEntries)
                {
                    // do something with fileName
                    var fileType = Path.GetExtension(filePath);
                    var valid = true;
                    fileType = fileType.ToLower();
                    if (filterByFileExtensions!=null)
                    {
                        valid = filterByFileExtensions.Contains(fileType);
                    }

                    if (valid)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(filePath);

                        try
                        {
                            //Console.WriteLine("File Type: {0} Name: {1} Full Path: {2}", fileType, fileName, filePath);
                            Files.Add(filePath);
                        } catch {
                            //do nothing
                        }
                        TotalValidFilesFound++;
                    }
                    TotalFilesFound++;
                }

                // Recurse into subdirectories of this directory.
                string[] subdirEntries = Directory.GetDirectories(sourceDirectory);
                foreach (string subdir in subdirEntries)
                {
                    // Do not iterate through reparse points (directory junction points)
                    if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint)
                        != FileAttributes.ReparsePoint)
                    {
                        TotalDirectoriesFound++;
                        TraverseDirectory(subdir, recursiveLevel + 1, FilterByFileExtensions);
                    }
                }
            }
        }
    }
}

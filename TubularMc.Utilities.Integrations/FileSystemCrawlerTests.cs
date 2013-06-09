using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace TubularMc.Utilities.Integrations
{
    public class when_scanning_filesystem_for_specific_files
    {
        private static FileSystemCrawler sut;
        private static string _scanFilePath;
        private static IList<string> _filterByFileExtensions;
        private static IList<string> _fileList;
        private static int _recursiveLevel;

        private Establish that = () =>
            {
                _recursiveLevel = 3;
                _scanFilePath = @"D:\Documents\Fax\test-media";
                _filterByFileExtensions = new List<string> { ".mkv", ".mp4", ".mov", ".avi", ".wmv" };
                sut = new FileSystemCrawler(_scanFilePath, _recursiveLevel, _filterByFileExtensions);
                _fileList = new List<string>();
            };

        private Because of = () => _fileList = sut.Scan();

        It should_have_the_correct_number_of_files_found = () => 
            _fileList.Count.ShouldEqual(5);
    }
}

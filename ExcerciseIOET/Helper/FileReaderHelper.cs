using System;
using System.Collections.Generic;
using System.IO;
using ExcerciseIOET.Model;

namespace ExcerciseIOET.Helper
{
	public class FileReaderHelper
	{
		public FileReaderHelper()
		{ }

		public IEnumerable<string> GetLines(string fileName)
		{
			var path = Constants.TxtFilesPath;
		#if (RELEASE)
			path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, Constants.ReleasePath); 
		#endif
			string FileToRead = String.Concat(path, fileName);
			return File.ReadLines(FileToRead);
		}
	}
}

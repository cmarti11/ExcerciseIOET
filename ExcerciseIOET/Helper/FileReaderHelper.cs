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
			string FileToRead = String.Concat(Constants.TxtFilesPath, fileName);
			return File.ReadLines(FileToRead);
		}
	}
}

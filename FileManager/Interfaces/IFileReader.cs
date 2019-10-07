using System;
using System.Collections.Generic;

namespace FileManager.Interfaces
{
    public interface IFileReader
    {
        List<Tuple<char, string[]>> ReadFile(string filePath);
    }
}

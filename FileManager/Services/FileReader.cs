using FileManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager.Services
{
    public class FileReader : IFileReader
    {
        public List<Tuple<char, string[]>> ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            List<Tuple<char, string[]>> parameters = new List<Tuple<char, string[]>>();
            foreach (string line in lines)
            {
                string[] parameter = line.Split(' ');
                char key = char.Parse(parameter[0]);
                string[] values = new string[parameter.Length - 1];
                Array.Copy(parameter, 1, values, 0, parameter.Length - 1);
                parameters.Add(Tuple.Create(key, values));
            }
            return parameters;
        }
    }
}

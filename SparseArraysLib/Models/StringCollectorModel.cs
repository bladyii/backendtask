using System;
using System.Collections.Generic;
using System.Text;

namespace SparseArraysLib.Models
{
    public class StringCollectorModel
    {
        public StringCollectorModel()
        {
            ForegroundColor = ConsoleColor.Gray;
            MinStrings = 1;
            MaxStrings = 1000;
            CollectionName = "strings";
        }

        public ConsoleColor ForegroundColor { get; }
        public int NumberOfStringToCollect { get; set; }
        public int MinStrings { get; }
        public int MaxStrings { get; }
        public string CollectionName { get; set; }
    }
}

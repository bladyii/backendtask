using System;
using System.Collections.Generic;
using System.Text;
using SparseArraysLib.Models;
using SparseArraysLib.Modules.CRUD.Interfaces;

namespace SparseArraysLib.Modules.CRUD
{
    public class MainUserInterface : IMainUserInterface
    {
        private readonly IStringsCollector _stringsCollector;

        public MainUserInterface(IStringsCollector stringsCollector)
        {
            _stringsCollector = stringsCollector;
        }
        public StringMatcherModel GatherAllUserData()
        {
            return new StringMatcherModel
            {
                Strings = _stringsCollector.Collect(new StringCollectorModel()),
                Queries = _stringsCollector.Collect(new StringCollectorModel {CollectionName = "queries"})
            };
        }

        public void DisplayMatcherOutput(StringMatcherOutput outputResults)
        {

            Console.WriteLine();
            Console.WriteLine("Results");
            foreach (var t in outputResults.Results)
            {
                if (t > 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                }    
                Console.WriteLine(t);
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
}

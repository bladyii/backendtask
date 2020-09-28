using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SparseArraysLib.Models;
using SparseArraysLib.Modules.CRUD.Interfaces;

namespace SparseArraysLib.Modules.CRUD
{
    public class StringsCollector : IStringsCollector
    {
        public string[] Collect(StringCollectorModel model)
        {
            InitializeStringCollection(model);
            AskUserForSizeOfArray(model);

            var strings = InitializeArray(model);
            GetUserInput(model, strings);

            return strings;
        }

        private static void GetUserInput(StringCollectorModel model, string[] a)
        {
            for (int i = 0; i < model.NumberOfStringToCollect; i++)
            {
                Console.WriteLine($"Enter {(i + 1)} of {model.NumberOfStringToCollect} {model.CollectionName}:");
                a[i] = Console.ReadLine();
            }
        }

        private static string[] InitializeArray(StringCollectorModel model)
        {
            string[] a = new string[model.NumberOfStringToCollect];
            return a;
        }

        private void AskUserForSizeOfArray(StringCollectorModel model)
        {
            var result = Console.ReadLine();
            ValidateAndAssignNumberOfStrings(model, result);
        }

        private static void InitializeStringCollection(StringCollectorModel model)
        {
            ValidateModel(model);
            SetConsoleColor(model);
            AskForUserInput(model);
        }

        private static void AskForUserInput(StringCollectorModel model)
        {
            Console.WriteLine($"Enter a number of {model.CollectionName} you would like to input.");
        }

        private static void SetConsoleColor(StringCollectorModel model)
        {
            Console.ForegroundColor = model.ForegroundColor;
        }

        private static void ValidateModel(StringCollectorModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
        }

        private void ValidateAndAssignNumberOfStrings(StringCollectorModel model, string result)
        {
            if (ValidateNumberOfStringsInput(model, result, out var userValue))
            {
                model.NumberOfStringToCollect = userValue;
                return;
            }

            Console.WriteLine($"The number of {model.CollectionName} must be between 1 and 1000");
            AskUserForSizeOfArray(model);
            
        }

        private static bool ValidateNumberOfStringsInput(StringCollectorModel model, string result, out int userValue)
        {
            return int.TryParse(result, out userValue) && userValue >= model.MinStrings && userValue <= model.MaxStrings;
        }
    }
}

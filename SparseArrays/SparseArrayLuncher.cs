using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SparseArraysLib.Modules.Business.Interfaces;
using SparseArraysLib.Modules.CRUD.Interfaces;

namespace SparseArrays
{
    public class SparseArrayLuncher : ISparseArrayLuncher
    {
        private readonly IMainUserInterface _userInterface;
        private readonly IStringsCollector _stringsCollector;
        private readonly IStringMatcher _stringMatcher;

        public SparseArrayLuncher(IMainUserInterface userInterface, IStringsCollector stringsCollector, IStringMatcher stringMatcher)
        {
            _userInterface = userInterface;
            _stringsCollector = stringsCollector;
            _stringMatcher = stringMatcher;
        }

        public async Task LunchSparseArray()
        {
            var results = await _stringMatcher.MatchStringsAsync(_userInterface.GatherAllUserData());
            _userInterface.DisplayMatcherOutput(results);
        }

    }
}

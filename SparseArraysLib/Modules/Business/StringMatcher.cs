using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SparseArraysLib.Models;
using SparseArraysLib.Modules.Business.Interfaces;
using SparseArraysLib.Modules.CRUD.Interfaces;

namespace SparseArraysLib.Modules.Business
{
    public class StringMatcher : IStringMatcher
    {
        private readonly ILogger<IStringMatcher> _logger;

        public StringMatcher(ILogger<IStringMatcher> logger)
        {
            _logger = logger;
        }

        public async Task<StringMatcherOutput> MatchStringsAsync(StringMatcherModel matcherModel)
        {
            var output = new StringMatcherOutput {Results = new int[matcherModel.Queries.Length]};

            await MatchingStringsAsync(matcherModel, output);

            return output;
        }

        private async Task MatchingStringsAsync(StringMatcherModel matcherModel, StringMatcherOutput output)
        {
            await Task.Run(() => {
                try
                {
                    var stringList = matcherModel.Strings;

                foreach (var query in matcherModel.Queries.Select((value, index) => (value, index)))
                {
                    var searchResults = stringList.ToList().FindAll(x => x == query.value);
                    output.Results[query.index] = searchResults?.Count ?? 0;
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _logger.LogError(e.Message, e);
                    throw;
                }
              
            });
        }
    }
}

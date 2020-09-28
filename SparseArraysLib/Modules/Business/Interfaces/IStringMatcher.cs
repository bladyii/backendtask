using System.Threading.Tasks;
using SparseArraysLib.Models;

namespace SparseArraysLib.Modules.Business.Interfaces
{
    public interface IStringMatcher
    {
        Task<StringMatcherOutput> MatchStringsAsync(StringMatcherModel matcherModel);
    }
}

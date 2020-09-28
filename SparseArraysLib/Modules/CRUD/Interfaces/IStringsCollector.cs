using System.Threading.Tasks;
using SparseArraysLib.Models;

namespace SparseArraysLib.Modules.CRUD.Interfaces
{
    public interface IStringsCollector
    {
        string[] Collect(StringCollectorModel model);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SparseArraysLib.Models;

namespace SparseArraysLib.Modules.CRUD.Interfaces
{
    public interface IMainUserInterface
    {
        StringMatcherModel GatherAllUserData();
        void DisplayMatcherOutput(StringMatcherOutput outputResults);
    }
}

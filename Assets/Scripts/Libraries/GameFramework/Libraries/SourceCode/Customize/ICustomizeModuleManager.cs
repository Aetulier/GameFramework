using System.Collections;
using System.Collections.Generic;

namespace GameFramework.Customize {
    public interface ICustomizeModuleManager
    {
        void AddCustomizeModule(ICustomizeModule customizeModule);
        ICustomizeModule GetCustomizeModule(string moduleTypeName);
        void RemoveCustomizeModule(ICustomizeModule customizeModule);
    }
   
}


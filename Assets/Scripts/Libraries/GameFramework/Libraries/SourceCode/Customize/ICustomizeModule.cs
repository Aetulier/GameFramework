using System.Collections;
using System.Collections.Generic;

namespace GameFramework.Customize
{
    public interface ICustomizeModule
    {
        void OnUpdate(float elapseSeconds, float realElapseSeconds);

        object GetData();

    }
}

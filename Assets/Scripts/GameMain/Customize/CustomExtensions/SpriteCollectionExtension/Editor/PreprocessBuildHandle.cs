using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace GameMain.SpriteCollection
{
    public  class PreprocessBuildHandle: IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;
 
        public void OnPreprocessBuild(BuildReport report)
        {
           SpriteCollectionUtility.RefreshSpriteCollection();
        }
    }
}
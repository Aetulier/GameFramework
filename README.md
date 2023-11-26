# GameProject

## 游戏框架Game Framework说明  

### Config  全局配置
1.存储一些初始信息如场景名称  
2.获取配置 ```GameEntry.Config.GetXX("XX)```  
### Data Node  数据节点
1.存储游戏运行时的各种临时数据(如当前战斗英雄和怪物的数据)  
2.设置数据 ```GameEntry.DataNode.SetData<VarXXData>("XX", xxData);```  
3.获取数据 ```GameEntry.DataNode.GetData<VarXXData>("xxData");```  
### Data Table  数据表
1.存储英雄怪物数据(包括 名称 图片资源 各种属性数据技能数据)  
2.存储场景信息音乐信息等等  
3.读取表格 ```GameEntry.DataTable.GetDataTable<DRXX>(); ```  
### Debugger 调试用
### Entity 实体
1.实例化对象 类似Instantiate(xx),带有一个继承实体的脚本  
2.生成实体 ```GameEntry.Entity.ShowEntity<xx>(entityId, AssetUtility.GetEntityAsset("xx"), "xx", xxData); ```  
<details>
<summary>实体脚本模板</summary>
<pre><code>
namespace GameMain
{
    public class xx : EntityLogic
    {
        //生成实体时初始化类似Awake
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);         
        }
        //显示实体时调用
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);        
        }
         //隐藏实体时调用
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }
         //显示实体时每帧调用
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
         //实体回收时调用
        protected override void OnRecycle()
        {
            base.OnRecycle();        
        }
    }
}
    
</code></pre>
</details>

### Event 事件
1.可跨模块与脚本调用，用于游戏逻辑之间的解耦(注册类似开始回合 结束回合 UI按钮事件等等事件)  
2.事件注册 
```
//订阅(对象初始化时订阅)
GameEntry.Event.Subscribe(EventName.xx, xx);
//取消订阅(对象销毁或者不再使用事件时取消订阅)
GameEntry.Event.Unsubscribe(EventName.xx, xx);
//订阅函数
private void xx(object sender, GameEventArgs e)
{
  var eventData = e as GameEventBase;
  xx? data_ = eventData.UserData as xx?;//事件传递的数据
}

```
### Procedure  流程
1.整个游戏流程由状态机控制  
<img src="Document Picture/流程.png">  
2.流程说明  
<details>
<summary>流程模板</summary>
<pre><code>
using UnityEngine;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace GameMain
{
    public class Procedure_xx : ProcedureBase
    {
        //整个流程初始化时调用，一般为进入游戏后就调用类似Awake(userData为生成实体时自定义传递的数据)
        protected override void OnInit(ProcedureOwner procedureOwner, object userData)
        {
            base.OnInit(procedureOwner, userData);
        }
        //每次进入流程时调用
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }
        //当前流程每帧调用
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }
        //离开流程时调用
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);         
        }
        //整个流程销毁时调用，一般在关闭游戏时调用
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}
</code></pre>
</details>

切换流程 ```ChangeState<Procedure_xx>(procedureOwner);```

### Resource  资源
1.资源加载初始化流程位于ProcedureInitResources，编辑器模式时框架会调用AssetDatabase.LoadAssetAtPath加载资源，打包模式需要打包AB包。资源加载均为异步加载。  
2.加载资源 ```GameEntry.Resource.LoadAsset(assetName,loadAssetCallbacks)``` 需要自己监听加载完成的回调函数  
3.加载资源 ```GameEntry.Resource.LoadAssetAsync<T>(assetName)``` 可等待的异步模式 返回加载的资源类型

### UI  界面
1.加载UI界面 ```GameEntry.UI.OpenUIForm_Ex(AssetUtility.GetUIAsset("xx"), "xx");```  
2.制作UI预制需要新建一个继承UGuiForm的脚本  
<details>
<summary>UI模板</summary>
<pre><code>
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFramework.Event;
using UnityGameFramework.Runtime;
namespace GameMain
{
    public class UIXX : UGuiForm
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }
        protected override void OnRecycle()
        {
            base.OnRecycle();
        }
    }
}

</code></pre>
</details>

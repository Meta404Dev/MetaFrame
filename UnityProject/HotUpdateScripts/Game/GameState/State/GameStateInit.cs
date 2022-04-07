using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.UI;
//using XFramework.Audio;
using MetaFramework.ExcelData;
using MetaFramework.Res;
using JEngine.Core;

public static class GameStateInit
{
    public static void Enter()
    {
        //init game

        //ÅäÖÃ¼ÓÔØº¯Êý
        ResLoadTool.funcResLoad =
            (path) =>
            {
                return AssetMgr.Load(path);
            };

        //change to home
        GameStateManager.Instance.SetState(GameStateType.Home);
    }
    public static void Exit()
    {

    }
}

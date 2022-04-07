using MetaFramework.SceneLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.ExcelData;
using MetaFramework.UI;

public static class GameStateHome
{
    public static void Enter()
    {
        Debug.LogError("enter home!");

        SceneLoadHandler loader = new SceneLoadHandler();
        loader.Start(SceneType.Home, EnterScene);
    }

    public static void EnterScene()
    {
        Debug.LogError("enter home scene!");

        var data = ExcelDataManager.Instance.GetExcelItem<ExcelDataTableMonster, ExcelDataItemMonster>(1);

        Debug.Log("speed: " + data.speed);

        UITool.Open<UITip>();
    }

    public static void Exit()
    {

    }
}
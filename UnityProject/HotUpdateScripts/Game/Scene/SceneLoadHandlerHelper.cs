using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.SceneLoad;
using MetaFramework.UI;

/// <summary>
/// 场景加载器扩展，会自动添加移除Loading界面
/// </summary>
public static class SceneLoadHandlerHelper
{
    public static void Start(this SceneLoadHandler self, SceneType targetScene, Action onComplete = null)
    {
        UITool.Open<UILoading>((ui) =>
        {
            var uiLoading = ui as UILoading;

            self.Init(targetScene.ToString(), uiLoading.onLoading,
                (asyncOp) =>
                {
                    UITool.Close<UILoading>();

                    onComplete?.Invoke();
                });

            self.Start();
        });
    }
}

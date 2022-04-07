using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.SceneLoad;
using MetaFramework.UI;

/// <summary>
/// ������������չ�����Զ�����Ƴ�Loading����
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

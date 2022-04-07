using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.UI;
using System;

public class UILoading : UIBase<UIModelLoading, UIViewLoading>
{
    public Action<float> onLoading;

    public override UILayer GetLayer()
    {
        return UILayer.Top;
    }

    public override void OnEnter(params object[] args)
    {
        onLoading += OnEventLoading;
    }

    public override void OnExit()
    {
        onLoading -= OnEventLoading;
    }

    private void OnEventLoading(float progress)
    {
        GetView().txtInfo.text = progress.ToString();

        //Debug.Log("Loading progress:" + (progress * 100) + "%");
    }
}

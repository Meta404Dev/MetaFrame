using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MetaFramework.UI;

public class UITip : UIBase<UIModelTip, UIViewTip>
{
    public override UILayer GetLayer()
    {
        return UILayer.Top;
    }

    public override void OnEnter(params object[] args)
    {
        GetView().btnClose.onClick.AddListener(() =>
            {
                Debug.Log("ui tip click!");
                UITool.Close<UITip>();
            });

        GetView().scrollTestRect.OnHeight += (index) => { return 150; };

        GetView().scrollTestRect.OnFill += (index, go) =>
        {
            go.GetComponentInChildren<Text>().text = index.ToString();
        };

        GetView().scrollTestRect.InitData(100);
    }

    public override void OnExit()
    {

    }
}
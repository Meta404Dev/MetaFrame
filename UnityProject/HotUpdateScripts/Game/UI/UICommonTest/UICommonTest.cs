using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MetaFramework.UI;

public class UICommonTest : UIBase<UIModelCommonTest, UIViewCommonTest>
{
    public override UILayer GetLayer()
    {
        return UILayer.Center;
    }

    public override void OnEnter(params object[] args)
    {
        
    }

    public override void OnExit()
    {
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MetaFramework.UI;

/// <summary>
/// Auto Generate Class!!!
/// </summary>
public class UIViewCommonTest : IUIView
{
	public Image imgBg;

	public void Init(GameObject go)
	{
		imgBg = go.transform.Find("Img_Bg").GetComponent<Image>();

	}
}
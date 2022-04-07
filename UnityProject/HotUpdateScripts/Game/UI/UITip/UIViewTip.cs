using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MetaFramework.UI;

/// <summary>
/// Auto Generate Class!!!
/// </summary>
public class UIViewTip : IUIView
{
	public Image imgBg;
	public Text txtInfo;
	public Button btnClose;
	public Mopsicus.InfiniteScroll.InfiniteScroll scrollTestRect;
	public UICommonTest UICommonTest;

	public void Init(GameObject go)
	{
		imgBg = go.transform.Find("Node/Img_Bg").GetComponent<Image>();
		txtInfo = go.transform.Find("Node/Txt_Info").GetComponent<Text>();
		btnClose = go.transform.Find("Node/Btn_Close").GetComponent<Button>();
		scrollTestRect = go.transform.Find("Node/Scroll_TestRect").GetComponent<Mopsicus.InfiniteScroll.InfiniteScroll>();
		UICommonTest = go.transform.Find("Node/UICommonTest").GetComponent<UICommonTest>();

	}
}
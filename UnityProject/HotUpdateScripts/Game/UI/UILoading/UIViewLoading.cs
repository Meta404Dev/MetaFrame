using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MetaFramework.UI;

public class UIViewLoading : IUIView
{
	public Text txtInfo;

	public void Init(GameObject go)
	{
		txtInfo=go.transform.Find("Txt_Info").GetComponent<Text>();

	}
}
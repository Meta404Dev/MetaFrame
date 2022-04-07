using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using MetaFramework.ExcelData;

/// <summary>
/// Auto Generate Class!!!
/// </summary>
[System.Serializable]
public class ExcelDataItemMonster : ExcelDataItemBase
{
    /// <summary>
    /// 名字
    /// </summary>
    public string name;

    /// <summary>
    /// 攻击
    /// </summary>
    public int attack;

    /// <summary>
    /// 生命值
    /// </summary>
    public int health;

    /// <summary>
    /// 速度
    /// </summary>
    public float speed;

    /// <summary>
    /// 为Boss?
    /// </summary>
    public bool isBoss;


    public int ID { get { return id; } }
}

/// <summary>
/// Auto Generate Class!!!
/// </summary>
public class ExcelDataTableMonster : ExcelDataTableBase<ExcelDataItemMonster>
{
    public override void Init(string json)
    {
        List<Dictionary<string, string>> allDataList = LitJson.JsonMapper.ToObject<List<Dictionary<string, string>>>(json);

        List<ExcelDataItemMonster> list = new List<ExcelDataItemMonster>();
        for (int i = 0; i < allDataList.Count; i++)
        {
            Dictionary<string, string> data = allDataList[i];

            ExcelDataItemMonster item = new ExcelDataItemMonster()
            {
                id = Convert.ToInt32(data["id"]),
                name = data["name"],
                attack = Convert.ToInt32(data["attack"]),
                health = Convert.ToInt32(data["health"]),
                speed = Convert.ToSingle(data["speed"]),
                isBoss = Convert.ToBoolean(data["isBoss"]),

            };
            list.Add(item);
        }

        datas = list.ToArray();
    }
}
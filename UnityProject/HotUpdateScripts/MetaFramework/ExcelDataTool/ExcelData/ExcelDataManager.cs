using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using MetaFramework.Res;
using MetaFramework.Singleton;

namespace MetaFramework.ExcelData
{
    public class ExcelDataManager : SingletonTemplate<ExcelDataManager>
    {
        public const string EXCEL_RES_PATH = "Assets/HotUpdateResources/ExcelData/{0}.json";

        public Dictionary<Type, object> dic = new Dictionary<Type, object>();

        /// <summary>
        /// 获取一张表
        /// </summary>
        /// <typeparam name="K">Table</typeparam>
        /// <typeparam name="V">Item</typeparam>
        /// <returns></returns>
        public K GetExcelTableData<K, V>() where K : ExcelDataTableBase<V> where V : ExcelDataItemBase
        {
            Type type = typeof(K);
            if (dic.ContainsKey(type) && dic[type] is K)
                return dic[type] as K;

            string jsonFileName = type.Name.Replace("ExcelDataTable", "");
            string path = string.Format(EXCEL_RES_PATH, jsonFileName);
            TextAsset jsonAsset = ResLoadTool.funcResLoad(path) as TextAsset;
            string json = jsonAsset.text;

            K excelTable = Activator.CreateInstance(type) as K;
            excelTable.Init(json);

            dic.Add(type, excelTable);

            return excelTable;
        }

        /// <summary>
        /// 获取一个数据
        /// </summary>
        /// <typeparam name="K">Table</typeparam>
        /// <typeparam name="V">Item</typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public V GetExcelItem<K, V>(int id) where K : ExcelDataTableBase<V> where V : ExcelDataItemBase
        {
            var excelData = GetExcelTableData<K, V>();

            if (excelData == null) return null;

            return excelData.GetExcelItem(id);
        }

    }
}
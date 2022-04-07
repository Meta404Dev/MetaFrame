using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFramework.ExcelData
{
    public abstract class ExcelDataTableBase<T> where T : ExcelDataItemBase
    {
        public T[] datas;

        public abstract void Init(string json);

        public T GetExcelItem(int id)
        {
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i].id == id) return datas[i];
            }

            return null;
        }
    }
}
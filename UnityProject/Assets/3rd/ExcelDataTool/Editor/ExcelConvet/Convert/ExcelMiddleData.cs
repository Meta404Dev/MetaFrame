using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace XFramework.ExcelData.Editor
{
    public class ExcelMiddleData
    {
        public string excelName;
        public string excelDataClassName;
        public string excelDataAllClassName;
        public int totalDataCount;
        public int rowCount;
        public int columnCount;

        public List<string> types;
        public List<string> props;
        public List<string> notes;
        public List<Dictionary<string, string>> excelMiddleDatas;

        public void Init(DataTable sheet, int startRowIndex)
        {
            types = new List<string>();
            props = new List<string>();
            notes = new List<string>();
            excelMiddleDatas = new List<Dictionary<string, string>>();
            rowCount = sheet.Rows.Count;
            columnCount = sheet.Columns.Count;
            excelName = sheet.TableName;

            //init title
            for (int i = 0; i < columnCount; i++)
            {
                var type = sheet.Rows[startRowIndex][i].ToString();
                var prop = sheet.Rows[startRowIndex + 1][i].ToString();
                var note = sheet.Rows[startRowIndex + 2][i].ToString();

                if (!CheckTypeValid(type)) throw new Exception("type error: " + type + ", sheet: " + sheet.TableName);

                types.Add(type);
                props.Add(prop);
                notes.Add(note);
            }

            //convert data
            for (int i = startRowIndex + 3; i < rowCount; i++)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                for (int j = 0; j < columnCount; j++)
                {
                    var title = props[j];
                    var prop = sheet.Rows[i][j].ToString();
                    dic.Add(title, prop);
                }
                excelMiddleDatas.Add(dic);

                totalDataCount++;
            }
        }

        private bool CheckTypeValid(string type)
        {
            string[] validType = new string[] { "string", "int", "float", "bool" };

            for (int i = 0; i < validType.Length; i++)
            {
                if (validType[i].Equals(type)) return true;
            }

            return false;
        }

    }

}
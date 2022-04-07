using ExcelDataReader;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace XFramework.ExcelData.Editor
{
    public static class ExcelConvertTool
    {

        [MenuItem("XTools/Excel表转为Class")]
        public static void GenerateClass()
        {
            new ExcelConvertRequest().GenerateAllClass();
        }
        [MenuItem("XTools/Excel表转为Asset")]
        public static void GenerateAsset()
        {
            new ExcelConvertRequest().GenerateAllAsset();
        }
    }
}
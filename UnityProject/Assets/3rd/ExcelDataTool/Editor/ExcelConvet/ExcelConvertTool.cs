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

        [MenuItem("XTools/Excel��תΪClass")]
        public static void GenerateClass()
        {
            new ExcelConvertRequest().GenerateAllClass();
        }
        [MenuItem("XTools/Excel��תΪAsset")]
        public static void GenerateAsset()
        {
            new ExcelConvertRequest().GenerateAllAsset();
        }
    }
}
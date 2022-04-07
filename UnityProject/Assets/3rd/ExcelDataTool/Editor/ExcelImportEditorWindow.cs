//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System.IO;

//namespace XFramework.ExcelImport
//{
//    public class ExcelImportEditorWindow : EditorWindow
//    {
//        private string pathExcelFile;

//        private int curSelectWorkSheet;

//        [MenuItem("XTools/Excel导入工具 #&%E", false, 998)]
//        static void ShowEditor()
//        {
//            ExcelImportEditorWindow window = GetWindow<ExcelImportEditorWindow>();
//            window.minSize = new Vector2(600, 300);
//            window.titleContent.text = "Excel导入工具";
//        }

//        private void OnGUI()
//        {
//            #region GUIStyle 设置
//            Color fontColor = new Color(179f / 255f, 179f / 255f, 179f / 255f, 1f);

//            //GUIStyle gl = "Toggle";
//            //gl.margin = new RectOffset(0, 100, 0, 0);

//            GUIStyle titleStyle = new GUIStyle() { fontSize = 18, alignment = TextAnchor.MiddleCenter };
//            titleStyle.normal.textColor = fontColor;

//            GUIStyle sonTittleStyle = new GUIStyle() { fontSize = 15, alignment = TextAnchor.MiddleCenter };
//            sonTittleStyle.normal.textColor = fontColor;

//            GUIStyle leftStyle = new GUIStyle() { fontSize = 15, alignment = TextAnchor.MiddleLeft };
//            leftStyle.normal.textColor = fontColor;

//            GUIStyle littoleStyle = new GUIStyle() { fontSize = 13, alignment = TextAnchor.MiddleCenter };
//            littoleStyle.normal.textColor = fontColor;
//            #endregion


//            GUILayout.BeginArea(new Rect(0, 0, 600, 1200));
//            GUILayout.BeginVertical();

//            GUILayout.BeginHorizontal();

//            string path = string.IsNullOrEmpty(pathExcelFile) ? Application.dataPath : pathExcelFile;

//            EditorGUILayout.LabelField("Excel路径", leftStyle, GUILayout.Width(150));
//            pathExcelFile = GUILayout.TextField(pathExcelFile, GUILayout.Width(250));
//            if (GUILayout.Button("...", GUILayout.Width(20)))
//            {
//                string folder = Path.GetDirectoryName(path);
//                pathExcelFile = EditorUtility.OpenFilePanel("Open Excel file", folder, "excel files;*.xls;*.xlsx");
//            }
//            GUILayout.EndHorizontal();
//            using (new GUILayout.HorizontalScope())
//            {
//                EditorGUILayout.LabelField("Worksheet: ", GUILayout.Width(100));
//                CurrentSheetIndex = EditorGUILayout.Popup(machine.CurrentSheetIndex, machine.SheetNames);
//                if (machine.SheetNames != null)
//                    machine.WorkSheetName = machine.SheetNames[machine.CurrentSheetIndex];

//            }

//            GUILayout.EndVertical();
//            GUILayout.EndArea();
//        }
//    }
//}

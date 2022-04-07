using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XFramework.UI.Editor
{
    public static class UIAutoCreatePathSetting
    {
        /// <summary>
        /// ���·��
        /// </summary>
        public const string PluginPath = "Assets/3rd/MetaJUI/";

        /// <summary>
        /// ˵���ĵ�·��
        /// </summary>
        public const string ReadMeFilePath = PluginPath + "Editor/UIAutoCreate/readme.txt";

        /// <summary>
        /// ����·��
        /// </summary>
        public const string UIConfigPath = "Assets/HotUpdateResources/ScriptableObject/UIConfig.asset";

        /// <summary>
        /// Ԥ����ģ��·��
        /// </summary>
        public const string PrefabTemplatePath = "Assets/HotUpdateResources/UI/UITemplate";

        /// <summary>
        /// View�������������ļ�·��
        /// </summary>
        public const string UIViewAutoCreateConfigPath = PluginPath + "Editor/UIAutoCreate/Template/UIViewAutoCreateConfig.asset";

        /// <summary>
        /// ����ģ��·��
        /// </summary>
        public const string TemplateFilePath = PluginPath + "Editor/UIAutoCreate/Template/";
        public const string ModelTemplateName = "UIModelTemplate.txt";
        public const string ViewTemplateName = "UIViewTemplate.txt";
        public const string ControlTemplateName = "UIControlTemplate.txt";

        /// <summary>
        /// ��������·��
        /// </summary>
        public const string GenerateCsFilePath = "/HotUpdateScripts/Game/UI/";

        /// <summary>
        /// UI������������·��
        /// </summary>
        /// <returns></returns>
        public static string GetUIGenerateCSFilePath()
        {
            string hotfixPath = Application.dataPath.Replace("/Assets", GenerateCsFilePath);
            return hotfixPath;
        }
    }
}
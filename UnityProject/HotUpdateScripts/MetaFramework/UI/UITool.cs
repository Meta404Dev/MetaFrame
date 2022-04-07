using System;

namespace MetaFramework.UI
{
    /// <summary>
    /// ����UI�İ����࣬����ֱ��ͨ����̬�����
    /// �����Զ�ת���˷���
    /// </summary>
    public static class UITool
    {
        public static T Get<T>() where T : class, IUIBase
        {
            string uiName = typeof(T).Name;

            IUIBase ui = UIManager.Instance.Get(uiName);

            return ui as T;
        }

        public static void OpenStack<T>(Action<IUIBase> onComplete = null, params object[] args) where T : class, IUIBase
        {
            string uiName = typeof(T).Name;

            UIManager.Instance.OpenStack(uiName, onComplete, args);
        }

        public static void CloseStack()
        {
            UIManager.Instance.CloseStack();
        }

        public static void Open<T>(Action<IUIBase> onComplete = null, params object[] args) where T : class, IUIBase
        {
            string uiName = typeof(T).Name;

            UIManager.Instance.OpenNormal(uiName, onComplete, args);
        }

        public static void Close<T>() where T : IUIBase
        {
            string uiName = typeof(T).Name;

            UIManager.Instance.CloseNormal(uiName);
        }

        public static void Clear() 
        {
            UIManager.Instance.Clear();
        }
    }
}

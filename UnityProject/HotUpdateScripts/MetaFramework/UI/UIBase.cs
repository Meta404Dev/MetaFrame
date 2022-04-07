using UnityEngine;

namespace MetaFramework.UI
{
    /// <summary>
    /// ����UIӦ�ü̳�UIBase�����涨Model��View�ķ���
    /// </summary>
    /// <typeparam name="M">ָ��Model����</typeparam>
    /// <typeparam name="V">ָ��View����</typeparam>
    public abstract class UIBase<M, V> : IUIBase
        where M : class, IUIModel
        where V : class, IUIView
    {
        /// <summary>
        /// ui name = ���� = Ԥ������
        /// </summary>
        public string uiName { get; set; }

        /// <summary>
        /// UI���ڵ�
        /// </summary>
        public GameObject uiGo { get; set; }

        /// <summary>
        /// ���ݲ�
        /// </summary>
        public IUIModel uiModel { get; set; }

        /// <summary>
        /// ��ʾ��
        /// </summary>
        public IUIView uiView { get; set; }

        public M GetModel()
        {
            return uiModel as M;
        }

        public V GetView()
        {
            return uiView as V;
        }

        public abstract UILayer GetLayer();


        #region ��������
        /// <summary>
        /// �����һ�δ�
        /// </summary>
        public virtual void OnEnter(params object[] args) { }
        /// <summary>
        /// ������ͣ��Stack��
        /// </summary>
        public virtual void OnPause() { }
        /// <summary>
        /// ����ָ���Stack��
        /// </summary>
        public virtual void OnResume() { }
        /// <summary>
        /// ����ر�
        /// </summary>
        public virtual void OnExit() { }
        /// <summary>
        /// ����ˢ��
        /// </summary>
        public virtual void OnUpdate() { }

        #endregion
    }
}
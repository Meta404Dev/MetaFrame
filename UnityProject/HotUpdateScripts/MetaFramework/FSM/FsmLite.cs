using UnityEngine;
using System.Collections.Generic;
using System;

namespace MetaFramework.Fsm
{

    public class FsmLite<T> where T : struct
    {
        /// <summary>
        /// һ��״̬������лص�
        /// </summary>
        public class StateFunc
        {
            public Action enterFunc;
            public Action exitFunc;
        }

        /// <summary>
        /// Ĭ��״̬
        /// </summary>
        protected T m_DefaultState;

        /// <summary>
        /// ǰһ��״̬
        /// </summary>
        protected T m_PrevState;

        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        protected T m_CurState;

        /// <summary>
        /// ��ȡ����ǰ״̬
        /// </summary>
        public T GetCurState { get { return m_CurState; } }

        /// <summary>
        /// ״̬����
        /// </summary>
        protected Dictionary<T, StateFunc> m_StateFunc = new Dictionary<T, StateFunc>();

        /// <summary>
        /// ��ʼ��״̬��
        /// </summary>
        /// <param name="defaultState"></param>
        public FsmLite(T defaultState)
        {
            m_DefaultState = defaultState;
        }

        /// <summary>
        /// ״̬����ʼ����ϣ���ʼ��ĬȻ״̬��ʼ����
        /// </summary>
        public void Start()
        {
            SetState(m_DefaultState, true);
        }

        /// <summary>
        /// ע��״̬
        /// </summary>
        /// <param name="state"></param>
        /// <param name="enter"></param>
        /// <param name="update"></param>
        /// <param name="exit"></param>
        public void RegistState(T state, Action enter, Action exit)
        {
            if (m_StateFunc.ContainsKey(state)) return;

            StateFunc func = new StateFunc
            {
                enterFunc = enter,
                exitFunc = exit
            };

            this.m_StateFunc.Add(state, func);
        }

        /// <summary>
        /// ����Ϊһ��״̬
        /// </summary>
        /// <param name="state"></param>
        public void SetState(T state, bool isFirst = false)
        {
            if (!isFirst)
            {
                if (m_CurState.Equals(state)) return;
            }

            T curState = this.m_CurState;
            this.m_PrevState = curState;
            this.m_CurState = state;

            if (this.m_StateFunc.ContainsKey(curState) && (this.m_StateFunc[curState].exitFunc) != null)
            {
                this.m_StateFunc[curState].exitFunc();
            }

            if (this.m_StateFunc.ContainsKey(this.m_CurState) && (this.m_StateFunc[this.m_CurState].enterFunc) != null)
            {
                this.m_StateFunc[this.m_CurState].enterFunc();
            }
        }

        /// <summary>
        /// �Ƿ������״̬
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool HasState(T state)
        {
            return m_StateFunc.ContainsKey(state);
        }

    }

}
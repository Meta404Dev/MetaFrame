using UnityEngine;
using System.Collections.Generic;
using System;

namespace MetaFramework.Fsm
{

    public class FsmLite<T> where T : struct
    {
        /// <summary>
        /// 一个状态里的所有回调
        /// </summary>
        public class StateFunc
        {
            public Action enterFunc;
            public Action exitFunc;
        }

        /// <summary>
        /// 默认状态
        /// </summary>
        protected T m_DefaultState;

        /// <summary>
        /// 前一个状态
        /// </summary>
        protected T m_PrevState;

        /// <summary>
        /// 当前状态
        /// </summary>
        protected T m_CurState;

        /// <summary>
        /// 获取到当前状态
        /// </summary>
        public T GetCurState { get { return m_CurState; } }

        /// <summary>
        /// 状态集合
        /// </summary>
        protected Dictionary<T, StateFunc> m_StateFunc = new Dictionary<T, StateFunc>();

        /// <summary>
        /// 初始化状态机
        /// </summary>
        /// <param name="defaultState"></param>
        public FsmLite(T defaultState)
        {
            m_DefaultState = defaultState;
        }

        /// <summary>
        /// 状态机初始化完毕，开始从默然状态开始运行
        /// </summary>
        public void Start()
        {
            SetState(m_DefaultState, true);
        }

        /// <summary>
        /// 注册状态
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
        /// 设置为一个状态
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
        /// 是否包含该状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool HasState(T state)
        {
            return m_StateFunc.ContainsKey(state);
        }

    }

}
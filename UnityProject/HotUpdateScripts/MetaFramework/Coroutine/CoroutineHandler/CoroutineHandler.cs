using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFramework.CoroutineTool
{
    public static class CoroutineTool
    {
        public static CoroutineHandler Start(this IEnumerator enumerator)
        {
            CoroutineHandler handler = new CoroutineHandler(enumerator);
            handler.Start();
            return handler;
        }
    }

    public class CoroutineHandler
    {
        public IEnumerator Coroutine { get; private set; } = null;
        public bool Paused { get; private set; } = false;
        public bool Running { get; private set; } = false;
        public bool Stopped { get; private set; } = false;

        public Action<bool> OnCompleted;

        public CoroutineHandler(IEnumerator c)
        {
            Coroutine = c;
        }

        /// <summary>
        /// 启动协程
        /// </summary>
        public void Start()
        {
            if (Coroutine == null)
            {
                Debug.Log("coroutine is null!");
                return;
            }

            Running = true;
            CoroutineDriver.Run(CallWrapper());
        }

        /// <summary>
        /// 强制停止协程
        /// </summary>
        public void Stop()
        {
            Stopped = true;
            Running = false;
        }

        /// <summary>
        /// 暂停协程
        /// </summary>
        public void Pause()
        {
            Paused = true;
        }

        /// <summary>
        /// 恢复协程
        /// </summary>
        public void Resume()
        {
            Paused = false;
        }

        /// <summary>
        /// 完成回调并断引用
        /// </summary>
        private void Finish()
        {
            OnCompleted?.Invoke(Stopped);

            OnCompleted = null;

            Coroutine = null;
        }

        /// <summary>
        /// 添加协程执行完成事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public CoroutineHandler SetComplete(Action<bool> action)
        {
            this.OnCompleted += action;
            return this;
        }

        #region IEnumerator Wrapper

        private IEnumerator CallWrapper()
        {
            yield return null;

            IEnumerator e = Coroutine;

            while (Running)
            {
                if (Paused)
                {
                    yield return null;
                }
                else
                {
                    if (e != null && e.MoveNext())
                    {
                        yield return e.Current;
                    }
                    else
                    {
                        Running = false;
                    }
                }
            }

            Finish();
        }

        #endregion
    }
}
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
        /// ����Э��
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
        /// ǿ��ֹͣЭ��
        /// </summary>
        public void Stop()
        {
            Stopped = true;
            Running = false;
        }

        /// <summary>
        /// ��ͣЭ��
        /// </summary>
        public void Pause()
        {
            Paused = true;
        }

        /// <summary>
        /// �ָ�Э��
        /// </summary>
        public void Resume()
        {
            Paused = false;
        }

        /// <summary>
        /// ��ɻص���������
        /// </summary>
        private void Finish()
        {
            OnCompleted?.Invoke(Stopped);

            OnCompleted = null;

            Coroutine = null;
        }

        /// <summary>
        /// ���Э��ִ������¼�
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.Singleton;

namespace MetaFramework.CoroutineTool
{
    public class CoroutineManager : SingletonTemplate<CoroutineManager>
    {
        /// <summary>
        /// int is hashcode
        /// </summary>
        private Dictionary<int, CoroutineHandler> cacheDic;

        public CoroutineManager()
        {
            cacheDic = new Dictionary<int, CoroutineHandler>();
        }

        public CoroutineHandler Get(int hashCode)
        {
            CoroutineHandler handler;
            if (cacheDic.TryGetValue(hashCode, out handler))
            {
                return handler;
            }

            return null;
        }

        public void Start(IEnumerator enumerator)
        {
            int hashCode = enumerator.GetHashCode();

            CoroutineHandler handler = enumerator.Start();
            handler.SetComplete((isStop) =>
            {
                cacheDic.Remove(hashCode);
            });

            cacheDic.Add(hashCode, handler);
        }

        public void Stop(int hashCode)
        {
            CoroutineHandler handler;
            if (!cacheDic.TryGetValue(hashCode, out handler))
            {
                Debug.LogError("can not find the coroutine:" + hashCode);
                return;
            }

            handler.Stop();
        }
    }
}
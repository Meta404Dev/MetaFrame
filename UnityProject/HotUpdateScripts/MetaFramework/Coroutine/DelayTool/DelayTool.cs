using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFramework.CoroutineTool
{
    public static class DelayTool
    {
        public static void DelayDo(float delayTime, Action action)
        {
            IEDelayDo(delayTime, action).Start();
        }

        private static IEnumerator IEDelayDo(float delayTime, Action action)
        {
            yield return new WaitForSeconds(delayTime);

            action?.Invoke();
        }
    }
}
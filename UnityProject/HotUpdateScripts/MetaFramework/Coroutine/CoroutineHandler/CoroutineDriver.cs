using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFramework.CoroutineTool
{
    public class CoroutineDriver : MonoBehaviour
    {
        static CoroutineDriver driver;
        static CoroutineDriver Driver
        {
            get
            {
                if (null == driver)
                {
                    GameObject go = new GameObject("[CoroutineDriver]");
                    driver = go.AddComponent<CoroutineDriver>();
                    GameObject.DontDestroyOnLoad(go);
                    go.hideFlags = HideFlags.HideAndDontSave;
                }
                return driver;
            }
        }



        void Awake()
        {
            //避免了跳场景导致的重复生成问题
            if (driver != null && driver != this)
            {
                GameObject.Destroy(gameObject);
            }
        }

        public static Coroutine Run(IEnumerator target)
        {
            return Driver.StartCoroutine(target);
        }
    }
}
using JEngine.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using MetaFramework.CoroutineTool;

namespace MetaFramework.SceneLoad
{
    /// <summary>
    /// ≥°æ∞º”‘ÿ∆˜
    /// “¿¿µ£∫
    ///     XFramework.CoroutineTool
    /// </summary>
    public class SceneLoadHandler
    {
        public const string SCENE_PATH = "Assets/HotUpdateResources/Scene/{0}.unity";

        public string targetScene;

        public Action<float> onLoading;
        public Action<AsyncOperation> onComplete;

        public void Init(string targetScene, Action<float> onLoading = null, Action<AsyncOperation> onComplete = null)
        {
            this.targetScene = targetScene;
            this.onLoading = onLoading;
            this.onComplete = onComplete;
        }

        public void Start()
        {
            string scenePath = string.Format(SCENE_PATH, targetScene);
            AssetMgr.LoadSceneAsync(scenePath, false, null, onLoading, onComplete);
            //CoroutineManager.Instance.Start(IELoad());
        }

        //public IEnumerator IELoad()
        //{
        //    yield return null;

        //    AsyncOperation ao = SceneManager.LoadSceneAsync(targetScene);
        //    ao.allowSceneActivation = false;

        //    while (!ao.isDone)
        //    {
        //        float progress = Mathf.Clamp01(ao.progress / 0.9f);
        //        onLoading?.Invoke(progress);

        //        if (Mathf.Approximately(ao.progress, 0.9f))
        //        {
        //            ao.allowSceneActivation = true;
        //        }

        //        yield return null;
        //    }

        //    onComplete?.Invoke();
        //}
    }
}
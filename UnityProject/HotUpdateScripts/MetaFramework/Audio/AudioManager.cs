//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using XFramework.CoroutineTool;
//using XFramework.Singleton;

//namespace XFramework.Audio
//{
//    public class AudioManager : SingletonTemplate<AudioManager>
//    {
//        private GameObject audioRootGo;

//        private Queue<AudioSource> cacheAudio;

//        private List<AudioSource> curPlayAudios;
//        private AudioSource curPlayBGM;

//        private int volumeAudio;
//        private int volumeBGM;

//        public int VolumeAudio
//        {
//            get => volumeAudio;
//            set => volumeAudio = value;
//        }

//        public int VolumeBGM
//        {
//            get => volumeBGM;
//            set
//            {
//                volumeBGM = value;

//                if (curPlayBGM != null)
//                {
//                    curPlayBGM.volume = volumeBGM;
//                }
//            }
//        }

//        public AudioManager()
//        {
//            cacheAudio = new Queue<AudioSource>(5);
//            curPlayAudios = new List<AudioSource>();
//            VolumeAudio = 1;
//            VolumeBGM = 1;

//            audioRootGo = new GameObject("AudioRoot");
//            GameObject.DontDestroyOnLoad(audioRootGo);
//        }

//        /// <summary>
//        /// 背景音乐
//        /// </summary>
//        /// <param name="clip"></param>
//        /// <param name="volume"></param>
//        public void PlayBGM(AudioClip clip)
//        {
//            Play(true, (source) =>
//             {
//                 source.clip = clip;
//                 source.volume = VolumeBGM;
//                 source.spatialBlend = 0;
//             });
//        }

//        /// <summary>
//        /// 普通的UI点击音效
//        /// </summary>
//        /// <param name="clip"></param>
//        /// <param name="volume"></param>
//        public void PlayAudio(AudioClip clip)
//        {
//            Play(false, (source) =>
//             {
//                 source.clip = clip;
//                 source.volume = VolumeAudio;
//                 source.spatialBlend = 0;
//             });
//        }

//        /// <summary>
//        /// 3D音效
//        /// </summary>
//        /// <param name="clip"></param>
//        /// <param name="volume"></param>
//        /// <param name="position"></param>
//        public void Play3DAudio(AudioClip clip, Vector3 position)
//        {
//            Play(false, (source) =>
//             {
//                 source.clip = clip;
//                 source.volume = VolumeAudio;
//                 source.spatialBlend = 1;
//                 source.transform.position = position;
//             });
//        }

//        /// <summary>
//        /// 停止所有音效，包括BGM
//        /// </summary>
//        public void StopAllAudio()
//        {
//            StopPlayAudio(curPlayBGM);

//            foreach (var audio in curPlayAudios)
//            {
//                StopPlayAudio(audio);
//            }
//        }

//        private void Play(bool isBgm, Action<AudioSource> onSetting)
//        {
//            AudioSource source = GetAudioSource();
//            onSetting.Invoke(source);
//            source.Play();

//            if (!isBgm) curPlayAudios.Add(source);

//            //delay recycle
//            DelayTool.DelayDo(source.clip.length,
//                () =>
//                {
//                    StopPlayAudio(source);

//                    if (!isBgm) curPlayAudios.Remove(source);
//                });
//        }

//        private void StopPlayAudio(AudioSource source)
//        {
//            source.Stop();
//            source.gameObject.SetActive(false);
//            cacheAudio.Enqueue(source);
//        }

//        private AudioSource GetAudioSource()
//        {
//            AudioSource source;

//            //优先从缓存池里取
//            if (cacheAudio.Count > 0)
//            {
//                source = cacheAudio.Dequeue();
//                source.gameObject.SetActive(true);
//            }
//            else
//            {
//                GameObject gameObject = new GameObject("audio");
//                gameObject.transform.parent = audioRootGo.transform;

//                source = gameObject.AddComponent<AudioSource>();
//                source.spatialBlend = 1f;
//                source.loop = false;
//            }

//            return source;
//        }
//    }
//}
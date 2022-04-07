//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace XFramework.Pool
//{
//    public class GameObjectPoolTest : MonoBehaviour
//    {
//        GameObjectPool pool;

//        public List<GameObject> testDatas = new List<GameObject>();

//        private void Start()
//        {
//            pool = new GameObjectPool();
//            pool.FuncGetNewObject += () =>
//            {
//                GameObject go = new GameObject();
//                return go;
//            };
//            pool.OnEventReuse += (go) =>
//            {
//                go.SetActive(true);
//            };
//            pool.OnEventRecycle += (go) =>
//            {
//                go.SetActive(false);
//            };
//        }

//        private void Update()
//        {
//            if (Input.GetKeyDown(KeyCode.Q))
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    var data = pool.GetOne();
//                    testDatas.Add(data);
//                }

//                Debug.Log(pool.PoolCount);
//            }

//            if (Input.GetKeyDown(KeyCode.W))
//            {
//                var data = pool.GetOne();
//                testDatas.Add(data);

//                Debug.Log(pool.PoolCount);
//            }

//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                var data = testDatas[testDatas.Count - 1];
//                testDatas.Remove(data);
//                pool.Recycle(data);

//                Debug.Log(pool.PoolCount);
//            }
//        }
//    }
//}
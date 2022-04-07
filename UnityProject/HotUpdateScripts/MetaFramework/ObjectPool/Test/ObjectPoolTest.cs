//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace XFramework.Pool
//{
//    [System.Serializable]
//    public class ObjectPoolTestData
//    {
//        public int count;
//    }

//    public class ObjectPoolTest : MonoBehaviour
//    {
//        ObjectPool<ObjectPoolTestData> pool;

//        public List<ObjectPoolTestData> testDatas = new List<ObjectPoolTestData>();

//        private void Start()
//        {
//            int index = 0;

//            pool = new ObjectPool<ObjectPoolTestData>();
//            pool.FuncGetNewObject += () =>
//            {
//                ObjectPoolTestData t = new ObjectPoolTestData();
//                t.count = index;
//                index++;
//                return t;
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
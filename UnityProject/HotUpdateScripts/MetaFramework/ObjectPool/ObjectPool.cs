using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFramework.Pool
{
    public class ObjectPool<T> where T : new()
    {
        /// <summary>
        /// 对象初始化方法
        /// </summary>
        public Func<T> FuncGetNewObject;

        /// <summary>
        /// 对象重用时派发事件
        /// </summary>
        public Action<T> OnEventReuse;

        /// <summary>
        /// 对象回收时派发事件
        /// </summary>
        public Action<T> OnEventRecycle;

        /// <summary>
        /// 对象销毁时派发事件
        /// </summary>
        public Action<T> OnEventDestroy;

        /// <summary>
        /// 对象池
        /// </summary>
        protected Queue<T> pool;

        /// <summary>
        /// 对象池大小
        /// </summary>
        public int PoolCount
        {
            get
            {
                return pool.Count;
            }
        }

        /// <summary>
        /// 对象池构造方法
        /// </summary>
        public ObjectPool()
        {
            pool = new Queue<T>();
        }

        /// <summary>
        /// 获取一个对象，优先从池子里取
        /// </summary>
        /// <returns></returns>
        public T GetOne()
        {
            if (pool.Count > 0)
            {
                T obj = pool.Dequeue();

                OnEventReuse?.Invoke(obj);

                return obj;
            }
            else
            {
                return CreateInstance();
            }
        }

        /// <summary>
        /// 回收一个对象到池子里
        /// </summary>
        /// <param name="obj"></param>
        public void Recycle(T obj)
        {
            if (obj == null) return;

            pool.Enqueue(obj);

            OnEventRecycle?.Invoke(obj);
        }

        /// <summary>
        /// 清理对象池
        /// </summary>
        public void Clear()
        {
            while (PoolCount > 0)
            {
                var obj = pool.Dequeue();

                OnEventDestroy?.Invoke(obj);
            }
        }

        /// <summary>
        /// 创建一个新的对象，如果没有指定创建方法，会默认new一个
        /// </summary>
        /// <returns></returns>
        protected T CreateInstance()
        {
            if (FuncGetNewObject != null)
            {
                return FuncGetNewObject();
            }
            else
            {
                return new T();
            }
        }
    }
}
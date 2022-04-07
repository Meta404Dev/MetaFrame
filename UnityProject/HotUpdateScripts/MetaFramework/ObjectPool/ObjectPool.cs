using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFramework.Pool
{
    public class ObjectPool<T> where T : new()
    {
        /// <summary>
        /// �����ʼ������
        /// </summary>
        public Func<T> FuncGetNewObject;

        /// <summary>
        /// ��������ʱ�ɷ��¼�
        /// </summary>
        public Action<T> OnEventReuse;

        /// <summary>
        /// �������ʱ�ɷ��¼�
        /// </summary>
        public Action<T> OnEventRecycle;

        /// <summary>
        /// ��������ʱ�ɷ��¼�
        /// </summary>
        public Action<T> OnEventDestroy;

        /// <summary>
        /// �����
        /// </summary>
        protected Queue<T> pool;

        /// <summary>
        /// ����ش�С
        /// </summary>
        public int PoolCount
        {
            get
            {
                return pool.Count;
            }
        }

        /// <summary>
        /// ����ع��췽��
        /// </summary>
        public ObjectPool()
        {
            pool = new Queue<T>();
        }

        /// <summary>
        /// ��ȡһ���������ȴӳ�����ȡ
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
        /// ����һ�����󵽳�����
        /// </summary>
        /// <param name="obj"></param>
        public void Recycle(T obj)
        {
            if (obj == null) return;

            pool.Enqueue(obj);

            OnEventRecycle?.Invoke(obj);
        }

        /// <summary>
        /// ��������
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
        /// ����һ���µĶ������û��ָ��������������Ĭ��newһ��
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
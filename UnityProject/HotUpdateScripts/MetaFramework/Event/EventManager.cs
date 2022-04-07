using System;
using System.Collections.Generic;
using MetaFramework.Singleton;


namespace MetaFramework.Event
{
    /// <summary>
    /// 事件中心
    /// </summary>
    public class EventManager : SingletonTemplate<EventManager>
    {
        /// <summary>
        /// 事件集合
        /// </summary>
        private Dictionary<string, List<Action<object>>> allHandler = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// 添加监听事件
        /// </summary>
        /// <param name="_eventName"></param>
        /// <param name="_callback"></param>
        public void AddListener(string _eventName, Action<object> _callback)
        {
            if (_callback == null) return;

            List<Action<object>> _events = null;
            if (allHandler.TryGetValue(_eventName, out _events))
            {
                _events.Add(_callback);
            }
            else
            {
                _events = new List<Action<object>>();
                _events.Add(_callback);
                allHandler.Add(_eventName, _events);
            }
        }

        /// <summary>
        /// 移除监听事件
        /// </summary>
        /// <param name="_eventName"></param>
        /// <param name="_callback"></param>
        public void RemoveListener(string _eventName, Action<object> _callback)
        {
            if (_callback == null) return;

            List<Action<object>> _events = null;
            if (allHandler.TryGetValue(_eventName, out _events))
            {
                if (_events.Contains(_callback))
                    _events.Remove(_callback);
            }
        }

        /// <summary>
        /// 移除该类型所有监听事件
        /// </summary>
        /// <param name="_eventName"></param>
        public void RemoveTheEvent(string _eventName)
        {
            List<Action<object>> _events = null;
            if (allHandler.TryGetValue(_eventName, out _events))
            {
                _events.Clear();
            }
        }

        /// <summary>
        /// 移除所有监听事件
        /// </summary>
        public void RemoveAllEvent()
        {
            allHandler.Clear();
        }

        /// <summary>
        /// 派发事件
        /// </summary>
        /// <param name="_eventName"></param>
        /// <param name="_param"></param>
        public void Dispatch(string _eventName, object _param)
        {
            List<Action<object>> _events = null;
            if (allHandler.TryGetValue(_eventName, out _events))
            {
                foreach (var v in _events)
                {
                    v.Invoke(_param);
                }
            }
        }
    }
}
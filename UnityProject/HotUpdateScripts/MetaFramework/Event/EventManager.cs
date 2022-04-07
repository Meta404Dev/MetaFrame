using System;
using System.Collections.Generic;
using MetaFramework.Singleton;


namespace MetaFramework.Event
{
    /// <summary>
    /// �¼�����
    /// </summary>
    public class EventManager : SingletonTemplate<EventManager>
    {
        /// <summary>
        /// �¼�����
        /// </summary>
        private Dictionary<string, List<Action<object>>> allHandler = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// ��Ӽ����¼�
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
        /// �Ƴ������¼�
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
        /// �Ƴ����������м����¼�
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
        /// �Ƴ����м����¼�
        /// </summary>
        public void RemoveAllEvent()
        {
            allHandler.Clear();
        }

        /// <summary>
        /// �ɷ��¼�
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
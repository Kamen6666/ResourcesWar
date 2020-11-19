using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Utilty
{
    public enum EventType
    {
        GetTask,
        BuyType
    }

    public class EventCenter : Singleton<EventCenter>
    {
        /// <summary>
        /// 消息中心的所有事件
        /// </summary>
        private Dictionary<EventType, Delegate> allEvents;

        private EventCenter()
        {
            allEvents = new Dictionary<EventType, Delegate>();
        }

        #region EventCenter AddListener

        private void OnAddListener(EventType eventType, Delegate action)
        {
            //无该事件类型
            if (!allEvents.ContainsKey(eventType))
            {
                allEvents.Add(eventType, action);
            }

            //如果该事件已经绑定或添加监听，新的事件和已有事件不同类型
            else if (allEvents[eventType].GetType() != action.GetType())
            {
                Debug.LogError($"添加到监听类型与事件类型不符！【消息类型为】{allEvents[eventType].GetType()} " +
                   $"  【添加的监听类型为】{action.GetType()}");

            }
            ////有事件类型，值为空
            //else if (allEvents[eventType] == null)
            //{
            //    allEvents[eventType] = action;
            //}

        }

        /// <summary>
        /// 在事件中心添加监听
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="action">无参无返回值的事件</param>
        public void AddListener(EventType eventType, Action action)
        {
            //添加监听准备
            OnAddListener(eventType, action);
            // 再已有监听基础上，添加新的监听
            allEvents[eventType] = (Action)allEvents[eventType] + action;
        }
        public void AddListener<T>(EventType eventType, Action<T> action)
        {
            //添加监听准备
            OnAddListener(eventType, action);
            // 再已有监听基础上，添加新的监听
            allEvents[eventType] = (Action<T>)allEvents[eventType] + action;
        }
        public void AddListener<T, X>(EventType eventType, Action<T, X> action)
        {
            //添加监听准备
            OnAddListener(eventType, action);
            // 再已有监听基础上，添加新的监听
            allEvents[eventType] = (Action<T, X>)allEvents[eventType] + action;
        }
        public void AddListener<T, X, Y>(EventType eventType, Action<T, X, Y> action)
        {
            //添加监听准备
            OnAddListener(eventType, action);
            // 再已有监听基础上，添加新的监听
            allEvents[eventType] = (Action<T, X, Y>)allEvents[eventType] + action;
        }
        public void AddListener<T, X, Y, Z>(EventType eventType, Action<T, X, Y, Z> action)
        {
            //添加监听准备
            OnAddListener(eventType, action);
            // 再已有监听基础上，添加新的监听
            allEvents[eventType] = (Action<T, X, Y, Z>)allEvents[eventType] + action;
        }
        #endregion

        #region EventCenter RemoveListener

        public void OnRemoveListener(EventType eventType, Delegate action)
        {
            if (!allEvents.ContainsKey(eventType))
            {
                Debug.LogError($"没有该类型的事件存在{eventType}");
            }
            else if (allEvents[eventType] == null)
            {
                Debug.LogError($"该类型事件为空，无法移除{eventType}");
            }
            else if (allEvents[eventType].GetType() != action.GetType())
            {
                Debug.LogError($"传入事件类型{allEvents[eventType].GetType()}  " +
                    $" 与消息类型不匹配{action.GetType()}");
            }
        }

        public void RemoveListener(EventType eventType, Action action)
        {
            OnRemoveListener(eventType, action);
            allEvents[eventType] = (Action)allEvents[eventType] - action;
        }
        public void RemoveListener<T>(EventType eventType, Action<T> action)
        {
            OnRemoveListener(eventType, action);
            allEvents[eventType] = (Action<T>)allEvents[eventType] - action;
        }
        public void RemoveListener<T, X>(EventType eventType, Action<T, X> action)
        {
            OnRemoveListener(eventType, action);
            allEvents[eventType] = (Action<T, X>)allEvents[eventType] - action;
        }
        public void RemoveListener<T, X, Y>(EventType eventType, Action<T, X, Y> action)
        {
            OnRemoveListener(eventType, action);
            allEvents[eventType] = (Action<T, X, Y>)allEvents[eventType] - action;
        }
        public void RemoveListener<T, X, Y, Z>(EventType eventType, Action<T, X, Y, Z> action)
        {
            OnRemoveListener(eventType, action);
            allEvents[eventType] = (Action<T, X, Y, Z>)allEvents[eventType] - action;
        }
        #endregion

        #region EventCenter RemoveAllListeners

        public void RemoveAllListeners(EventType eventType)
        {
            if (!allEvents.ContainsKey(eventType))
            {
                Debug.LogError("移除监听的事件不存在");
            }
            else
            {
                //从字典移除该监听类型
                allEvents.Remove(eventType);
            }
        }

        #endregion

        #region EventCenter CallEvent

        private void OnCall(EventType eventType)
        {
            if (allEvents.ContainsKey(eventType) || allEvents[eventType] == null)
            {
                Debug.LogError("事件类型不存在或为空，无法调用");
            }
        }
        /// <summary>
        /// 调用无参事件
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name=""></param>
        public void Call(EventType eventType)
        {
            OnCall(eventType);
            Action action = (Action)allEvents[eventType];
            action();
        }
        public void Call<T>(EventType eventType,T arg1)
        {
            OnCall(eventType);
            Action<T> action = (Action<T>)allEvents[eventType];
            action(arg1);
        }
        public void Call<T,X>(EventType eventType, T arg1,X arg2)
        {
            OnCall(eventType);
            Action<T,X> action = (Action<T,X>)allEvents[eventType];
            action(arg1, arg2);
        }
        public void Call<T, X,Y>(EventType eventType, T arg1, X arg2,Y arg3)
        {
            OnCall(eventType);
            Action<T, X,Y> action = (Action<T, X,Y>)allEvents[eventType];
            action(arg1, arg2, arg3);
        }
        public void Call<T, X, Y,Z>(EventType eventType, T arg1, X arg2, Y arg3,Z arg4)
        {
            OnCall(eventType);
            Action<T, X, Y,Z> action = (Action<T, X, Y,Z>)allEvents[eventType];
            action(arg1, arg2, arg3,arg4);
        }
        #endregion
    }
}
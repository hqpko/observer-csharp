using System;
using System.Collections.Generic;

namespace com.haiswork.observer
{
    public class Observer
    {
        private readonly Dictionary<Action<Observer>,bool> _dic = new Dictionary<Action<Observer>,bool>();
        public void Watch(Action<Observer> handlerWatch)
        {
            _dic[handlerWatch] = true;
        }

        public void UnWatch(Action<Observer> handlerWatch)
        {
            _dic.Remove(handlerWatch);
        }

        protected void Notify()
        {
            foreach (var watcher in _dic.Keys)
            {
                watcher(this);
            }
        }
    }
}
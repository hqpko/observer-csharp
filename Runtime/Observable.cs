using System;
using System.Collections.Generic;

namespace com.haiswork.observer
{
    public class Observable
    {
        private readonly Dictionary<Action<Observable>,bool> _dic = new Dictionary<Action<Observable>,bool>();
        public void OnWatch(Action<Observable> handlerWatch)
        {
            _dic[handlerWatch] = true;
        }

        public void UnWatch(Action<Observable> handlerWatch)
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
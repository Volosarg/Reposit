using System;
using System.Collections.Generic;
using System.Threading;

namespace CustomQueue
{
    class CustomQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();
        Object locker = new Object();

        /// <summary>
        /// Извлекает объект из очереди. Если очередь пуста, ждет
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            lock (locker)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(locker);
                }

                return _queue.Dequeue();
            }
        }

        /// <summary>
        /// Добавляет объект в очередь
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            lock (locker)
            {
                _queue.Enqueue(item);
                Monitor.Pulse(locker);
            }
        }
    }
}

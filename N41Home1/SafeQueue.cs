using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N41Home1
{
    internal class SafeQueue<T> : List<T>
    {
        public void Enqueue(T item)
        {
            lock (this)
            {
                Add(item);
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException("There is no elemets");
            }
            T deletedElement = default;
            lock (this)
            {
                if (!IsEmpty())
                {
                    deletedElement = this[0];
                    Remove(deletedElement);
                }
            }
            return deletedElement;
        }

        private bool IsEmpty()
        {
            return this.Count == 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace JustSomeExperiments
    {
    class CustomCollection<T>: IEnumerable<T>
        {
        protected List<T> _someList;

        public CustomCollection()
            {
            _someList = new List<T>();
            }

        public CustomCollection<T> Add (T item) 
            {
            _someList.Add(item);
            return this;
            }

        public IEnumerator<T> GetEnumerator()
            {
            foreach (var item in _someList)
                {
                yield return item;
                }
            }

        IEnumerator IEnumerable.GetEnumerator()
            {
            foreach (var item in _someList)
                {
                yield return item;
                }
            }
        }
    }

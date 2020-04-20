using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _20200410_HashtableVsDictionary
{
    class CollectionAnalyzer<TKey, TValue>
    {
        #region ===--- Date ---===

        protected IDictionary<TKey, TValue> _collect;

        #endregion

        #region ===--- Constructor ---===

        public CollectionAnalyzer(IDictionary<TKey, TValue> collect)
        {
            _collect = collect;
        }

        #endregion     

        #region ===--- Methods ---===        

        public long AddToCollection(TKey[] createKey, TValue[] createValue, Random rnd)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < createKey.Length; i++)
            {
                _collect.Add(createKey[i], createValue[i]);
            }

            timer.Stop();

            return timer.ElapsedMilliseconds;
        }

        public long RemoveByKey(TKey[] arrayKey)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int index = 0; index < arrayKey.Length; index++)
            {
                _collect.Remove(arrayKey[index]);
            }

            timer.Stop();

            return timer.ElapsedMilliseconds;
        }

        public long GetByKey(TKey[] arrayKey, int numKey, Random rnd)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int index = 0; index <= numKey; index++)
            {
                object temp = _collect[arrayKey[rnd.Next(0, (arrayKey.Length - 1))]];
            }

            timer.Stop();

            return timer.ElapsedMilliseconds;
        }

        public void ClearCollection()
        {
            _collect.Clear();
        }

        #endregion        
    }
}

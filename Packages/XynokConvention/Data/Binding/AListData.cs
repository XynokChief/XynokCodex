using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XynokConvention.Data.Binding
{
    public class AListData<T>
    {
        [SerializeField] protected List<T> elements;

        #region Bindable

        public event Action<T> OnAdd;
        public event Action<T> OnRemove;

        public event Action<T> OnChanged;
        public event Action OnClear;

        /// <summary>
        /// T1 is base value, T2 is last value, T3 is current value
        /// </summary>
        public event Action<T, T, int> OnDeepChanged;

        #endregion

        #region contructors

        public AListData()
        {
            elements = new List<T>();
        }

        public AListData(IEnumerable<T> arr)
        {
            elements = new List<T>(arr);
        }

        public AListData(T[] arr)
        {
            elements = new List<T>(arr);
        }

        public AListData(int capacity)
        {
            elements = new List<T>(capacity);
        }

        #endregion


        public int Capacity => elements.Capacity;
        public int Count => elements.Count;

        public T this[int index]
        {
            get => elements[index];
            set
            {
                OnDeepChanged?.Invoke(elements[index], value, index);
                OnChanged?.Invoke(value);
                elements[index] = value;
            }
        }

        public T Find(Predicate<T> match) => elements.Find(match);
        public bool Exists(Predicate<T> match) => elements.Exists(match);
        public T FirstOrDefault(Func<T, bool> func) => elements.FirstOrDefault(func);
        public IEnumerable<T> Where(Func<T, bool> func) => elements.Where(func);
        public List<T> GetRange(int index, int count) => elements.GetRange(index, count);
        public int IndexOf(T item) => elements.IndexOf(item);
        public bool Contains(T item) => elements.Contains(item);

        public void Clear()
        {
            OnClear?.Invoke();
            elements.Clear();
        }

        public virtual bool Remove(T item)
        {
            if (elements == null) return false;
            if (!elements.Contains(item)) return false;

            elements.Remove(item);
            OnRemove?.Invoke(item);
            return true;
        }

        public virtual void Add(T item)
        {
            elements ??= new List<T>();
            if (elements.Contains(item))
            {
                Debug.LogWarning(
                    $"[{GetType().Name} - Add()]: duplicated element <color=cyan>{item.GetType().Name}</color> !");
                return;
            }

            elements.Add(item);
            OnAdd?.Invoke(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
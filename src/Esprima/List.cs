﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Esprima
{
    // This structure is like List<> from the BCL except it is designed
    // to be modifiable by this library during the construction of the AST
    // but publicly read-only thereafter. The only allocation required on the
    // heap is the backing array storage for the element. An empty list,
    // however causes no heap allocation; that is, the array is allocated
    // on first addition.

    public struct List<T> : IReadOnlyList<T>
    {
        T[] _items;

        public List(int capacity)
        {
            _items = new T[capacity];
            Count = 0;
        }

        public List(List<T> list) : this()
        {
            if (list.Count <= 0)
            {
                return;
            }

            _items = new T[list.Count];
            list._items.CopyTo(_items, 0);
            Count = list.Count;
        }

        int Capacity => _items?.Length ?? 0;

        public int Count { get; private set; }

        internal List<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            var list = new List<TResult>
            {
                Count  = Count,
                _items = new TResult[Count]
            };

            for (var i = 0; i < Count; i++)
            {
                list._items[i] = selector(_items[i]);
            }

            return list;
        }

        internal void AddRange<TSource>(List<TSource> list) where TSource : T
        {
            if (list.Count == 0)
            {
                return;
            }

            var newCount = Count + list.Count;

            if (Capacity < newCount)
            {
                Array.Resize(ref _items, newCount);
            }

            Debug.Assert(_items != null);
            Array.Copy(list._items, 0, _items, Count, list.Count);
            Count = newCount;
        }

        internal void Add(T item)
        {
            var capacity = Capacity;

            if (Count == capacity)
            {
                Array.Resize(ref _items, Math.Max(capacity * 2, 4));
            }

            Debug.Assert(_items != null);
            _items[Count] = item;
            Count++;
        }

        internal void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, null);
            }

            _items[index] = default;
            Count--;

            if (index == Count)
            {
                return;
            }

            Array.Copy(_items, index + 1, _items, index, Count - index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T this[int index]
        {
            get => index >= 0 && index < Count
                 ? _items[index]
                 : throw new IndexOutOfRangeException();

            internal set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                _items[index] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Push(T item) => Add(item);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T Pop()
        {
            var lastIndex = Count - 1;
            var last = this[lastIndex];
            RemoveAt(lastIndex);
            return last;
        }
    }
}
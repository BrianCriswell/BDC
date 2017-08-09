//MIT License

//Copyright(c) 2017 Brian Criswell

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This Heap implementation is inspired and adapted from the Java implementation featured at
// https://www.hackerrank.com/topics/heaps
// It contains an abstract base class that implements most of the heap logic.
// Further down the file, MinHeap and MaxHeap implement HeapifyUp and HeapifyDown
// in the correct directions for their heap types.

namespace BDC.CSharp_Objects
{
    /// <summary>
    /// Absstract base class that provides functionality for a MaxHeap or MinHeap.
    /// </summary>
    /// <typeparam name="T">Any type that implements IComparable<T>.</typeparam>
    abstract public class Heap<T> where T : IComparable<T>
    {
        private int _size;  // Current number of elements in Heap
        private T[] _items; // Array of Heap elements
        private const int DEFAULT_CAPACITY = 10;

        /// <summary>
        /// Creates a new instance of a Heap and initializes storage to the default capacity.
        /// </summary>
        protected Heap() : this(DEFAULT_CAPACITY)
        {
        }

        /// <summary>
        /// Creates a new instance of a Heap and initializes storage to the given capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the new heat.</param>
        protected Heap(int capacity)
        {
            _size = 0;
            _items = new T[capacity];
        }

        /// <summary>
        /// Gets the number of elements in the heap.
        /// </summary>
        public int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>The element at the given index.</returns>
        protected T GetValue(int index) {
            return _items[index];
        }
        
        /// <summary>
        /// Calculates the left child index for a given parent index.
        /// </summary>
        /// <param name="parentIndex">The index of the element you are checking.</param>
        /// <returns>The calculated left child index.</returns>
        protected int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        
        /// <summary>
        /// Calculates the right child index for a given parent index.
        /// </summary>
        /// <param name="parentIndex">The index of the element you are checking.</param>
        /// <returns>The calculated right child index.</returns>
        protected int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
        
        /// <summary>
        /// Calculates the parent index for a given child index.
        /// </summary>
        /// <param name="childIndex">The index of the element you are checking.</param>
        /// <returns>The calculated parent index.</returns>
        protected int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
        
        /// <summary>
        /// Checks whether an element has a child on the left side.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>
        /// true if the calculated left child index exists within array bounds; false otherwise
        /// </returns>
        protected bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < _size;
        }
        
        /// <summary>
        /// Checks whether an element has a child on the right side.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>
        /// true if the calculated right child index exists within array bounds; false otherwise
        /// </returns>
        protected bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < _size;
        }
        
        /// <summary>
        /// Checks whether an element has a parent.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>
        /// true if the calculated parent index exists within array bounds; false otherwise
        /// </returns>
        protected bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }
        
        /// <summary>
        /// Gets the left child element of an element.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>The left child element.</returns>
        protected T LeftChild(int index)
        {
            return _items[GetLeftChildIndex(index)];
        }
        
        /// <summary>
        /// Gets the right child element of an element.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>The right child element.</returns>
        protected T RightChild(int index)
        {
            return _items[GetRightChildIndex(index)];
        }
        
        /// <summary>
        /// Gets the parent element of an element.
        /// </summary>
        /// <param name="index">The index of the element you are checking.</param>
        /// <returns>The parent element.</returns>
        protected T Parent(int index)
        {
            return _items[GetParentIndex(index)];
        }
        
        /// <summary>
        /// Swaps two elements given their indexes.
        /// </summary>
        /// <param name="indexOne">Index of the first element.</param>
        /// <param name="indexTwo">Index of the second element.</param>
        protected void Swap(int indexOne, int indexTwo)
        {
            T temp = _items[indexOne];
            _items[indexOne] = _items[indexTwo];
            _items[indexTwo] = temp;
        }
        
        /// <summary>
        /// Doubles underlying array if capacity is reached.
        /// </summary>
        private void EnsureCapacity()
        {
            if (_size == _items.Length)
            {
                int capacity = _items.Length << 1;
                T[] newItems = new T[capacity];
                _items.CopyTo(newItems, 0);
                _items = newItems;
            }
        }
        
        /// <summary>
        /// Returns the element at the top of the heap without removing it.
        /// Throws InvalidOperationException if Heap is empty.
        /// </summary>
        /// <returns>The value at the top of the Heap.</returns>
        public T Peek()
        {
            IsEmpty("Peek");

            return _items[0];
        }

        /// <summary>
        /// Throws InvalidOperationException if Heap is empty.
        /// </summary>
        /// <param name="methodName">Name of calling method.</param>
        private void IsEmpty(String methodName)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException(
                    "You cannot perform '" + methodName + "' on an empty Heap."
                );
            }
        }

        /// <summary>
        /// Extracts root element from Heap.
        /// Throws InvalidOperationException if Heap is empty.
        /// </summary>
        /// <returns>The value at the top of the heat.</returns>
        public T Poll()
        {
            // Throws an exception if empty.
            IsEmpty("Poll");

            // Else, not empty
            T item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            return item;
        }
        
        /// <summary>
        /// Inserts an item into the heap.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            // Resize underlying array if it's not large enough for insertion
            EnsureCapacity();

            // Insert value at the next open location in heap
            _items[_size] = item;
            _size++;

            // Correct order property
            HeapifyUp();
        }
        
        /// <summary>
        /// Swap values down the Heap.
        /// </summary>
        protected abstract void HeapifyDown();
        
        /// <summary>
        /// Swap values up the Heap.
        /// </summary>
        protected abstract void HeapifyUp();
    }
    
    /// <summary>
    /// Heap that places the maximum element at the top.
    /// </summary>
    /// <typeparam name="T">Any type that implements IComparable<T>.</typeparam>
    public class MaxHeap<T> : Heap<T> where T : IComparable<T>
    {
        /// <summary>
        /// Creates a new instance of a MaxHeap and initializes storage to the default capacity.
        /// </summary>
        public MaxHeap()
        {
        }
        
        /// <summary>
        /// Creates a new instance of a MaxHeap and initializes storage to the given capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the new heat.</param>
        public MaxHeap(int capacity) : base(capacity)
        {
        }
        
        /// <summary>
        /// Swap values down the Heap.
        /// </summary>
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && RightChild(index).CompareTo(LeftChild(index)) > 0)
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (GetValue(index).CompareTo(GetValue(smallerChildIndex)) > 0)
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }
        
        /// <summary>
        /// Swap values up the Heap.
        /// </summary>
        protected override void HeapifyUp()
        {
            int index = Count - 1;

            while (HasParent(index) && Parent(index).CompareTo(GetValue(index)) < 0)
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }
    
    /// <summary>
    /// Heap that places the minimum element at the top.
    /// </summary>
    /// <typeparam name="T">Any type that implements IComparable<T>.</typeparam>
    public class MinHeap<T> : Heap<T> where T : IComparable<T>
    {
        /// <summary>
        /// Creates a new instance of a MinHeap and initializes storage to the default capacity.
        /// </summary>
        public MinHeap()
        {
        }
        
        /// <summary>
        /// Creates a new instance of a MinHeap and initializes storage to the given capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the new heat.</param>
        public MinHeap(int capacity) : base(capacity)
        {
        }
        
        /// <summary>
        /// Swap values down the Heap.
        /// </summary>
        protected override void HeapifyDown()
        {
            int index = 0;

            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && RightChild(index).CompareTo(LeftChild(index)) < 0)
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (GetValue(index).CompareTo(GetValue(smallerChildIndex)) < 0)
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }
        
        /// <summary>
        /// Swap values up the Heap.
        /// </summary>
        protected override void HeapifyUp()
        {
            int index = Count - 1;

            while (HasParent(index) && Parent(index).CompareTo(GetValue(index)) > 0)
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }
}

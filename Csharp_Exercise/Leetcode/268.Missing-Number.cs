using System;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int MissingNumber(int[] nums) //time O(N) space O(1)
        {
            /*
              To find the missing no. in array, 
              we have :- 
                 Natural no. range

              case 1:
                 since it is natural no. , we use total natural - nums[n]
                 formula = n(n+1)/2

              case 2:
                 For loop and check contains.

              case 3:
                  while sorting find. 
            */
            int total = (nums.Length * (nums.Length + 1)) / 2;
            int i = nums.Length - 1;
            while (i >= 0)
            {
                total = total - nums[i];
                i--;
            }
            return total;
        }

        public int MissingNumber2(int[] nums)
        {

            for (int i = 0; i <= nums.Length; i++)
            {
                if (!nums.Contains(i))
                {
                    return i;
                }
            }

            return 0;
        }
        public int MissingNumber3(int[] nums)
        {
            Array.Sort(nums);
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i])
                {
                    missing = i;
                    break;
                }
            }
            return missing;
        }
        public int MissingNumber4(int[] nums)
        {

            OwnSet<int> set = new OwnSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            for (int i = 0; i <= nums.Length; i++)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }

            return 0;
        }
    }

    public class OwnPair<TKey, TValue>
    {
        public TKey _key;
        public TValue _value;
        public OwnPair(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public override bool Equals(object? obj)
        {
            OwnPair<TKey, TValue> other = obj as OwnPair<TKey, TValue>;
            return other._key.Equals(_key);
        }

        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }
    }

    public class OwnDictionary<TKey, TValue>
    {
        public OwnSet<OwnPair<TKey, TValue>> _data;

        public OwnDictionary()
        {
            _data = new OwnSet<OwnPair<TKey, TValue>>();
        }

        public TValue this[TKey key]
        {
            get
            {
                OwnPair<TKey, TValue> dummy = new OwnPair<TKey, TValue>(key, default);
                if (ContainsKey(key))
                {
                    return _data.GetByKey(dummy)._value;
                }
                return default;
            }
            set
            {
                OwnPair<TKey, TValue> dummy = new OwnPair<TKey, TValue>(key, default);
                if (ContainsKey(key))
                {
                    _data.GetByKey(dummy)._value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public bool ContainsKey(TKey key)
        {
            return _data.Contains(new OwnPair<TKey, TValue>(key, default));
        }

        public void Add(TKey key, TValue value)
        {
            _data.Add(new OwnPair<TKey, TValue>(key, value));
        }

        public void Remove(TKey key)
        {
            _data.Remove(new OwnPair<TKey, TValue>(key, default));
        }
    }

    public class OwnSet<T>
    {
        // List of List
        private OwnList<OwnList<T>> _data;

        public OwnSet()
        {
            _data = new OwnList<OwnList<T>>(1000);
            for (int i = 0; i < 1000; i++)
            {
                _data[i] = new OwnList<T>();
            }
        }

        public void Add(T value)
        {
            // посчитать индекс
            int index = CalculateIndex(value);
            // проверка на уникальность
            if (!Contains(value))
            {
                _data[index].Add(value);
            }
        }

        public int CalculateIndex(T value)
        {
            int hash = Math.Abs(value.GetHashCode());
            int index = hash % _data.Capacity;
            return index;
        }

        public bool Contains(T value)
        {
            int index = CalculateIndex(value);
            int indexFound = _data[index].FindIndex(value);
            return indexFound != -1;
        }

        public T GetByKey(T value)
        {
            int index = CalculateIndex(value);
            int indexFound = _data[index].FindIndex(value);
            return _data[index][indexFound];
        }


        public void Remove(T value)
        {
            int index = CalculateIndex(value);
            if (Contains(value)) // O(N)
            {
                _data[index].Remove(value); // O(N)
            }
        }
    }

    public class OwnList<T>
    {
        private T[] _data;
        private int _lastAvailableIndex;

        public int Count => _lastAvailableIndex;
        public int Capacity => _data.Length;

        public OwnList()
        {
            _lastAvailableIndex = 0;
            _data = new T[1];
        }

        public OwnList(int capacity)
        {
            _lastAvailableIndex = 0;
            _data = new T[capacity];
        }

        public T this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }

        public int FindIndex(T value)
        {
            for (int i = 0; i < _lastAvailableIndex; i++)
            {
                if (_data[i].Equals(value))
                    return i;
            }

            return -1;
        }

        public void Add(T value)
        {
            if (_lastAvailableIndex == _data.Length)
            {
                T[] temporaryArray = new T[_data.Length * 2];
                for (int i = 0; i < _data.Length; i++)
                {
                    temporaryArray[i] = _data[i];
                }
                _data = temporaryArray;
            }
            _data[_lastAvailableIndex] = value;
            _lastAvailableIndex++;
        }

        public void RemoveIdx(int idx)
        {
            for (int i = idx; i < _lastAvailableIndex - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            _lastAvailableIndex--;
        }

        public void Remove(T value)
        {
            for (int i = 0; i < _lastAvailableIndex; i++)
            {
                if (value.Equals(_data[i]))
                {
                    RemoveIdx(i);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < _lastAvailableIndex; i++)
            {
                Console.Write(_data[i] + " ");
            }
        }

        public void ReversePrint()
        {
            for (int i = _lastAvailableIndex - 1; i >= 0; i--)
            {
                Console.Write(_data[i] + " ");
            }
        }
    }
}

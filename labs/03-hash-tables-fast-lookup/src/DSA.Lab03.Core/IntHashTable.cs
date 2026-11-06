using System;
using System.Collections.Generic;

namespace DSA.Lab03
{
    public sealed class IntHashTable<TValue>
    {
        private readonly List<Entry<TValue>>[] _buckets;
        private int _count;

        public IntHashTable(int bucketCount)
        {
            if (bucketCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bucketCount));
            }

            _buckets = new List<Entry<TValue>>[bucketCount];
            for (int i = 0; i < _buckets.Length; ++i)
            {
                _buckets[i] = new List<Entry<TValue>>();
            }
        }

        public int Count => _count;
        public int BucketCount => _buckets.Length;

        public void Set(int key, TValue value)
        {
            // TODO: search only the correct bucket, replace or append.
            List<Entry<TValue>> bucket = _buckets[key % _buckets.Length];

            for (int i = 0; i < bucket.Count; i++)
            {
                if (key == bucket[i].Key)
                {
                    bucket[i] = new(key, value);
                    return;
                }
            }
            _count++;
            bucket.Add(new(key, value));
        }

        public bool TryGetValue(int key, out TValue value)
        {
            // TODO: search only the correct bucket.
            value = default;

            List<Entry<TValue>> bucket = _buckets[key % _buckets.Length];

            for (int i = 0; i < bucket.Count; i++)
            {
                if (key == bucket[i].Key)
                {
                    value = bucket[i].Value;
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(int key)
        {
            // TODO: reuse the lookup behavior if useful.

            List<Entry<TValue>> bucket = _buckets[key % _buckets.Length];

            if (bucket.Count == 0) return false;
            else return true;
        }

        private int GetBucketIndex(int key)
        {
            if (key < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "This learning implementation uses non-negative integer keys.");
            }

            return key % _buckets.Length;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// Represents a single entry into a hash table (a key/value pair)
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Entry<K, V>
    {
        public K Key { get; private set; }
        public V Value { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Entry(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }

    /// <summary>
    /// Represents a hash table of key/value pairs with key of type K and value of type V.
    /// Uses linear probing to resolve hash collisions.
    /// Uses dynamic resizing if the table is loaded beyond a specified factor.
    /// 
    /// Run time analysis:
    ///                 Average         Worst
    ///                 ---------------------
    ///     Space       O(n)            O(n)
    ///     Search      O(1)            O(n)
    ///     Insert      O(1)            O(n)
    ///     Delete      O(1)            O(n)
    ///     
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Hashtable<K, V>
    {
        private const long multiplier = -1664117991;    // used in hash calculation
        private const double loadFactor = 0.75;         // when the table is loaded beyond this factor, resize is necessary
        private const int stepSize = 3;                 // the amount to step when collisions occur
        private int entryCount = 0;

        private Entry<K, V>[] table;

        private int Size { get { return table.Length; } }

        /// <summary>
        /// Default constructor defaults to 50 size
        /// </summary>
        /// <param name="size"></param>
        public Hashtable()
            : this(50)
        {
        }

        /// <summary>
        /// Default constructor with allowable size initialization
        /// </summary>
        /// <param name="size"></param>
        public Hashtable(int size)
        {
            table = new Entry<K, V>[size];
        }

        /// <summary>
        /// A relatively simplistic hash function to generate the index into the tabel based on the passed key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Hash(K key)
        {
            int hashCode = (int)(key.GetHashCode() * multiplier);
            return Math.Abs(hashCode % Size);
        }

        /// <summary>
        /// Steps to the next table index based on our step size in case of hash collisions
        /// </summary>
        /// <param name="hashCode"></param>
        /// <returns></returns>
        private int Step(int hashCode)
        {
            return (hashCode + stepSize) % Size;
        }

        /// <summary>
        /// Creates a key/value pair from the parameters and adds it to the table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            // the entry count is beyond the desired load so we need to resize the table
            if (entryCount > (Size * loadFactor))
            {
                Resize();
            }

            int index = Hash(key);
            Entry<K, V> entry = new Entry<K, V>(key, value);

            // if there's a spot open in the table at the calculated hash, put the entry there
            if (table[index] == null)
            {
                table[index] = entry;
                entryCount++;
            }
            // otherwise, we've collided and need to find the next open spot
            else
            {
                // loop forever until we find an empty slot for the entry
                while (true)
                {
                    Entry<K, V> collidedEntry = table[index];

                    // get the next stepped index
                    index = Step(Hash(key));

                    // if that spot is empty, put the entry there
                    if(table[index] == null)
                    {
                        table[index] = entry;
                        entryCount++;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Given the key parameter, returns the associated value stored in the hash table. Returns the default value of V if no key is found in the table.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            int index = Hash(key);
            
            // if nothing exists at the calculated index, return the default value of V
            if(table[index] == null)
            {
                return default(V);
            }
            else
            {
                // loop until we find a value
                while (true)
                {
                    Entry<K, V> currentEntry = table[index];

                    // if nothing exists at the calculated index, return the default value of V
                    if (table[index] == null)
                    {
                        return default(V);
                    }
                    // if we find the key match, return the value
                    else if (currentEntry.Key.Equals(key))
                    {
                        return currentEntry.Value;
                    }
                    // if there's a value at the index but it isn't the key we want, step to the next index
                    else
                    {
                        index = Step(Hash(key));
                        currentEntry = table[index];
                    }
                }
            }
        }

        /// <summary>
        /// Increases the table size by 50% and copies all key/value pairs to the new table.
        /// </summary>
        private void Resize()
        {
            int newSize = (int)(Size * 1.5);

            Entry<K, V>[] newTable = new Entry<K, V>[newSize];

            for (int i = 0; i < Size; i++)
            {
                newTable[i] = table[i];
            }

            table = newTable;
        }
    }
}

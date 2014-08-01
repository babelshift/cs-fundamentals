using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public static class Utility
    {
        /// <summary>
        /// Uses the default compare method between two IComparables. If the first value is greater the second other, true is returned. Otherwise, false.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsGreaterThan<T>(T value, T other)
            where T : IComparable
        {
            return value.CompareTo(other) > 0;
        }

        /// <summary>
        /// Uses the default compare method between two IComparables. If the first value is less the second other, true is returned. Otherwise, false.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsLessThan<T>(T value, T other)
            where T : IComparable
        {
            return value.CompareTo(other) < 0;
        }
    }
}

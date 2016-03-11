using System;
using System.Collections.Generic;
using System.Linq;

namespace Korean_Flash_Cards
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns a random element in the list excluding the item at index exclusionIndex.
        /// </summary>
        /// <typeparam name="T">The object type of the return value and list.</typeparam>
        /// <param name="list">The random element is returned from this list.</param>
        /// <param name="elementIndex">The index of the element returned.</param>
        /// <param name="exclusionIndex">Ensures the return value is not at the specified Int index.</param>
        /// <returns>A random T object from list.</returns>
        public static T GetRandomExc<T>(this List<T> list, out int elementIndex, int exclusionIndex)
        {
            Random rnd = new Random();
            do
            {
                elementIndex = rnd.Next(0, list.Count);
            } while (elementIndex == exclusionIndex);
            return list.ElementAt(elementIndex);

        }
    }
}

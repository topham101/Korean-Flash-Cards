using System;
using System.Collections.Generic;
using System.Linq;

namespace Korean_Flash_Cards
{
    public static class ExtensionMethods
    {
        public static T GetRandom<T>(this List<T> list, out int x)
        {
            Random rnd = new Random();
            x = rnd.Next(0, list.Count);
            return list.ElementAt(x);

        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BreweryDB.Helpers
{
    public static class ExtensionMethods
    {
        public static int Remove<T>(
            this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);
            }

            return itemsToRemove.Count;
        }

        public static void RemoveAll<T>(this ObservableCollection<T> collection,
            Func<T, bool> condition)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (condition(collection[i]))
                {
                    collection.RemoveAt(i);
                }
            }
        }

        public static string BuildParametersList(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            var stringBuilder = new StringBuilder();

            foreach (var parameter in parameters)
            {
                stringBuilder.Append(string.Concat("&", parameter.Key, "=", parameter.Value));
            }

            stringBuilder.Append(string.Concat("&", "key", "=", BreweryDBClient.ApplicationKey));
            stringBuilder.Append(string.Concat("&", "format", "=", "json"));

            return stringBuilder.ToString();
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._4CS
{
    class TestCollections<TKey, TValue>
    {
        private List<TKey> listtkey = new List<TKey>();
        private List<string> liststring = new List<string>();
        private Dictionary<TKey, TValue> dictionarytkey = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> dictionarystring = new Dictionary<string, TValue>();
        private GenerateElement<TKey, TValue> generateElement;

        public TestCollections(int count, GenerateElement<TKey, TValue> j)
        {
            if (count <= 0) 
                throw new ArgumentException("Нельзя инициализировать <=0 элементов коллекций");

            generateElement = j;

            for (int i = 0; i < count; i++)
            {
                var element = generateElement(i);
                listtkey.Add(element.Key);
                liststring.Add(element.Value.ToString());
                dictionarytkey.Add(element.Key, element.Value);
                dictionarystring.Add(element.Key.ToString(), element.Value);
            }
        }

        public void Search_In_TKeyList()
        {
            var first = listtkey[0];
            var center = listtkey[listtkey.Count / 2];
            var last = listtkey[listtkey.Count - 1];
            var another = generateElement(listtkey.Count + 10).Key;


            listtkey.Contains(first);
            listtkey.Contains(center);
            listtkey.Contains(last);
            listtkey.Contains(another);

        }

        public void Search_In_StringList()
        {
            var first = liststring[0];
            var center = liststring[liststring.Count / 2];
            var last = liststring[liststring.Count - 1];
            var another = generateElement(liststring.Count + 10).Key.ToString();

            liststring.Contains(first);
            liststring.Contains(center);
            liststring.Contains(last);
            liststring.Contains(another);
        }

        public void Search_In_TKeyDictionary()
        {
            var first = dictionarytkey.ElementAt(0).Key;
            var center = dictionarytkey.ElementAt(dictionarytkey.Count / 2).Key;
            var last = dictionarytkey.ElementAt(dictionarytkey.Count - 1).Key;
            var another = generateElement(dictionarytkey.Count + 10).Key;

            dictionarytkey.ContainsKey(first);
            dictionarytkey.ContainsKey(center);
            dictionarytkey.ContainsKey(last);
            dictionarytkey.ContainsKey(another);
        }

        public void Search_In_StringDictionary()
        {
            var first = dictionarystring.ElementAt(0).Key;
            var center = dictionarystring.ElementAt(dictionarystring.Count / 2).Key;
            var last = dictionarystring.ElementAt(dictionarystring.Count - 1).Key;
            var another = generateElement(dictionarystring.Count + 10).Key.ToString();

            dictionarystring.ContainsKey(first);
            dictionarystring.ContainsKey(center);
            dictionarystring.ContainsKey(last);
            dictionarystring.ContainsKey(another);
        }

        public void Search_In_TKeyDictionary_by_Value()
        {
            var first = dictionarytkey.ElementAt(0).Value;
            var center = dictionarytkey.ElementAt(dictionarytkey.Count / 2).Value;
            var last = dictionarytkey.ElementAt(dictionarytkey.Count - 1).Value;
            var another = generateElement(dictionarytkey.Count + 10).Value;

            dictionarytkey.ContainsValue(first);
            dictionarytkey.ContainsValue(center);
            dictionarytkey.ContainsValue(last);
            dictionarytkey.ContainsValue(another);
        }

        public void Search_In_StringDictionary_by_Value()
        {
            var first = dictionarystring.ElementAt(0).Value;
            var center = dictionarystring.ElementAt(dictionarystring.Count / 2).Value;
            var last = dictionarystring.ElementAt(dictionarystring.Count - 1).Value;
            var another = generateElement(dictionarystring.Count + 10).Value;

            dictionarystring.ContainsValue(first);
            dictionarystring.ContainsValue(center);
            dictionarystring.ContainsValue(last);
            dictionarystring.ContainsValue(another);
        }
    }

}


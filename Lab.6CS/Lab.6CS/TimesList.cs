using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab._6CS
{
    [Serializable]
    class TimesList
    {

        private List<TimeItem> _timeItems = new List<TimeItem>();

        public void Add(TimeItem newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException("TimeItem shouldn't be null");
            _timeItems.Add(newItem);
        }

        public void Save(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(filename, FileMode.Create);
                using (fileStream)
                {
                    formatter.Serialize(fileStream, _timeItems);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void Load(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(filename, FileMode.Open);
                using (fileStream)
                {
                    List<TimeItem> deserializeTimeItems = formatter.Deserialize(fileStream) as List<TimeItem>;
                    if (deserializeTimeItems == null) throw new ArgumentNullException();

                    _timeItems = deserializeTimeItems;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var element in _timeItems)
            {
                builder.AppendLine(element.ToString());
            }

            return builder.ToString();
        }
    }
}

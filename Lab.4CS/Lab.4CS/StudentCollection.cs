using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._4CS
{
    delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    public enum Action { Add, Remove, Property }
    delegate TKey KeySelector<TKey>(Student st);
    class StudentCollection<TKey>
    {
        private Dictionary<TKey, Student> studentcollection = new Dictionary<TKey, Student>();
        private KeySelector<TKey> ks;
        public string CollectionName { get; set; }
        public event StudentsChangedHandler<TKey> StudentsChanged;


        public StudentCollection(KeySelector<TKey> ks)
        {
            this.ks = ks;
            studentcollection = new Dictionary<TKey, Student>();
        }

        public void AddDefaults()
        {
            Student student = new Student();
            TKey key = ks(student);

            studentcollection.Add(key, student);

            StudentPropertyChanged(Action.Add, "StudentCollectionAdd", key);
            student.PropertyChanged += Event;
        }
        public void AddStudents(params Student[] students)
        {
            foreach (Student temp in students)
            {
                TKey key = ks(temp);
                studentcollection.Add(key, temp);

                StudentPropertyChanged(Action.Add, "StudentCollectionAdd", key);
                temp.PropertyChanged += Event;
            }
        }
        public override string ToString()
        {
            string str = "Студенты в коллекции: \n";

            foreach (var stud in studentcollection.Values)
            {
                str += stud.ToString() + "\n";
            }

            return str;
        }
        public virtual string ToShortString()
        {
            string str = "Студенты в коллекции: \n";
            foreach (var stud in studentcollection.Values)
            {
                str += stud.ToShortString() + "\n";
            }

            return str;
        }
        public double Max_Middle
        {
            get
            {
                if (studentcollection.Count > 0)
                {
                    return studentcollection.Values.Max(m => m.Get_middle);
                }
                else
                    return -1;
            }
        }
        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education e)
        {
                return studentcollection.Where(educ => educ.Value.getseteducation == e);
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> Group_by_Education
        {
            get
            {
                return studentcollection.GroupBy(educ => educ.Value.getseteducation);
            }
        }

        public void Event(object st, EventArgs ev)
        {
            var e = (PropertyChangedEventArgs)ev;
            var student = (Student)st;
            TKey key = ks(student);

            StudentPropertyChanged(Action.Property, e.PropertyName.ToString(), key);
        }

        public bool Remove(Student student)
        {
            TKey key = ks(student);
            if (studentcollection.ContainsKey(key) == true)
            {
                studentcollection.Remove(key);

                StudentPropertyChanged(Action.Remove, "StudentCollectionRemove", key);
                student.PropertyChanged -= Event;

                return true;
            }
            return false;
        }



        private void StudentPropertyChanged(Action action, string name, TKey key)
        {
                StudentsChanged(this, new StudentsChangedEventArgs<TKey>(CollectionName, action, name, key));
        }

    }

}

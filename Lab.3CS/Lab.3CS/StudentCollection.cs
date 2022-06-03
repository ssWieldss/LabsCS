using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._3CS
{
    class StudentCollection<TKey>
    {
        private Dictionary<TKey, Student> studentcollection = new Dictionary<TKey, Student>();
        private KeySelector<TKey> ks;

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
        }
        public void AddStudents(params Student[] students)
        {
            foreach (Student temp in students)
            {
                TKey key = ks(temp);
                studentcollection.Add(key, temp);
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
    }
}

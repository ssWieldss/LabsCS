using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._2CS
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected DateTime birthday;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }

        public Person() : this("Иван", "Иванов", new DateTime(2000, 1, 1))
        {
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        public int Year
        {
            get
            {
                return Birthday.Year;
            }
            set
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + Birthday.ToShortDateString();
        }

        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }
        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (person.surname == surname && person.name == name && person.birthday == birthday) return true;
            else return false;
        }
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);
        public object DeepCopy()
        {
            return new Person { birthday = this.birthday, surname = this.surname, name = this.name };
        }
        public DateTime Date { get; set; }

        public override int GetHashCode()
        {
            return name.GetHashCode() + surname.GetHashCode() + birthday.GetHashCode();
        }
    }
}

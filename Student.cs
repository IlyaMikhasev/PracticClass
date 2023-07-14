using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticClass
{
    [Serializable]
    internal class Student
    {
        [XmlAttribute]
        int _id_student = 0;
        [XmlAttribute]
        string _name;
        [XmlAttribute]
        string _surname;
        [XmlAttribute]
        string _patr;
        [XmlAttribute]
        string _birthday;
        public Student() { }
        public Student(string name, string surname, string patr, DateTime birth_d) {
            _name= name;
            _surname= surname;
            _patr= patr;
            _birthday= birth_d.ToString();
        }
        public override string ToString()
        {
            return $"{this.ID} {this.Surname} {this.Name} {this.Patr}";
        }
        public string PrintStudent() {
            return ID.ToString()+_name+" "+ _surname+" "+ _patr+" "+ _birthday;
        }
        static public void Serealize_it(List<Student> objectGrath, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (Stream fStream = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(fStream, objectGrath);
            }
        }
        static public void Deserealize_it(string filename, out List<Student> lst)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (Stream fStream = new FileStream(filename, FileMode.OpenOrCreate,
                FileAccess.Read))
            {
                lst = (List<Student>)xmlSerializer.Deserialize(fStream);
            }
        }
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Patr { get { return _patr; } set { _patr = value; } }
        public int ID { get { return _id_student; } set { _id_student = value; } }

    }
}

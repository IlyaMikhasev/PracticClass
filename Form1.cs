using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PracticClass
{
    public partial class Form1 : Form
    {
        Student student;
        List<Student> students = new List<Student>();
        List<string> surname = new List<string>();
        public Form1()
        {
            InitializeComponent();
            refreshList();
        }
        private void updateSurnameList() {
            surname.Clear();
            foreach (var s in students) {
                surname.Add(s._surname);
            }
            surname.Sort();
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            lb_listStudent.Items.Clear();
            student = new Student(tb_name.Text,tb_surname.Text,tb_patr.Text,dateTimePicker1.Value);
            students.Add(student);         
            saveToXml();
        }
        private void saveToXml(string path = "Students.xml")
        {
            Student.Serealize_it( path, students);
            refreshList();
        }
        private void refreshList(string path = "Students.xml")
        {
            Student.Deserealize_it(path, out students);
            lb_listStudent.Items.Clear();
            updateSurnameList();
            updateNumericStudent();
        }
        private void updateNumericStudent()
        {
            int id = 1;
            foreach (var famaly in surname)
            {                
                for (int i = 0; i < students.Count; i++)
                {
                    if (famaly == students[i]._surname)
                    {
                        students[i]._id_student = id;
                        lb_listStudent.Items.Add(students[i].PrintStudent());
                    }
                }
                id++;
            }
        }

        private void b_del_Click(object sender, EventArgs e)
        {
            foreach (var stud in lb_listStudent.SelectedItems) {
                int id_student = int.Parse(stud.ToString()[0].ToString());
                foreach (Student s in students) {
                    if (s._id_student == id_student)
                    {
                        students.Remove(s); break;
                    }
                }
            }
            File.Delete("Students.xml");
            saveToXml();
        }
    }
}

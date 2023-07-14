using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            updateNumericStudent();
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            lb_listStudent.Items.Clear();
            student = new Student(tb_name.Text,tb_surname.Text,tb_patr.Text,dateTimePicker1.Value);
            students.Add(student);
            surname.Add(student._surname);
            surname.Sort();
            updateNumericStudent();
            saveToXml();
        }
        private void saveToXml(string path = "Students.xml")
        {
            Student.Serealize_it(students, path);
            refreshList();
        }
        private void refreshList(string path = "Students.xml")
        {
            Student.Deserealize_it(path, out students);
            lb_listStudent.Items.Clear();
            updateNumericStudent();
        }
        private void updateNumericStudent()
        {
            foreach (var famaly in surname)
            {
                int id = 1;
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
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Json;
            Question question = new Question();
            question.question = textBox4.Text;
            question.answer = textBox3.Text;
            Json = JsonConvert.SerializeObject(question);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\frankhuang\TestProject\Json.txt", true))
            {
                file.WriteLine(Json + ",");                
            }
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataTable source;
            DataTable source = new DataTable ();

            string text = System.IO.File.ReadAllText(@"C:\Users\frankhuang\TestProject\Json.txt");
            text = "[" + text + "]";
            List<Question> deserializedProduct = JsonConvert.DeserializeObject<List<Question>>(text);

            source .Columns .Add("question",typeof(string));
            source .Columns .Add("answer",typeof(string));
            foreach (Question match in deserializedProduct)
            {
                if (match.question .Contains (textBox1.Text))
                {
                    source.Rows.Add(match.question, match.answer);
                }
            }

           // dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;

            dataGridView1.DataSource = source;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 200;
            }
        }



    }

    public struct Question
    {
        public string question;
        public string answer;
    }


}

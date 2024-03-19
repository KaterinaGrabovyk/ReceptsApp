using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReceptsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(dataFilePath))
            {
                File.CreateText(dataFilePath);
                
            }

        }
        string dataFilePath = "ReceptsDataIMPORTANT.txt";

        private void button1_Click(object sender, EventArgs e)
        {
            string cookType1 = $"Тип страви:{listBox1.SelectedItem}";
            string cookType2 = $"Спосіб приготування:{listBox2.SelectedItem}";
            string cookType3 = $"Кухонний регіон:{listBox3.SelectedItem}";
            string check = "Сировинний склад:";
            foreach (var i in checkedListBox1.CheckedItems)
            {
                check += i.ToString() + ".";
            }
            string cookType4 = $"Харчові вподобання:{listBox4.SelectedItem}";
            string time1 = $"{numericUpDown1.Value}:{numericUpDown2.Value}";
            string time2 = $"{numericUpDown3.Value}:{numericUpDown4.Value}";

            string ing = textBox4.Text;
            string rec = textBox5.Text;
            if (textBox1.Text == "") { MessageBox.Show("Не введені потрібні дані."); }
            else
            {
                using (StreamReader sr = new StreamReader(dataFilePath))
                {
                        sr.Close();
                        string data = $"{textBox1.Text}@{cookType1}@{cookType2}@{cookType3}@{check}@{cookType4}@{time1}@{time2}@{ing}@{rec};\n";
                        File.AppendAllText(dataFilePath, data);
                        textBox1.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, false);
                            checkedListBox1.SelectedItem = null;
                        }
                        listBox1.SelectedItem = null;
                        listBox2.SelectedItem = null;
                        listBox3.SelectedItem = null;
                        listBox4.SelectedItem = null;
                        numericUpDown1.Value = 0;
                        numericUpDown2.Value = 0;
                        numericUpDown3.Value = 0;
                        numericUpDown4.Value = 0;

                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<object> list = new List<object>();
            list.Clear();
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                listBox9.Items.Clear();
                foreach (string l in sr.ReadToEnd().Split(";"))
                {
                    string choose1 = $"Тип страви:{listBox5.SelectedItem}";
                    string choose2 = $"Спосіб приготування:{listBox6.SelectedItem}";
                    string choose3 = $"Кухонний регіон:{listBox7.SelectedItem}";
                    string choose4 = "Сировинний склад:";
                    foreach (var i in checkedListBox2.CheckedItems)
                    {
                        choose4 += i.ToString() + ".";
                    }
                    string choose5 = $"Харчові вподобання:{listBox8.SelectedItem}";
                    
                    if (l.Contains(choose1))
                    {        
                        string[] mas = l.Split('@');
                        list.Add(mas[0]);
                    }
                    if (l.Contains(choose2))
                    {
                        string[] mas = l.Split('@');
                        list.Add(mas[0]);
                    }
                    if (l.Contains(choose3))
                    {
                        string[] mas = l.Split('@');
                        list.Add(mas[0]);
                    }
                    if (l.Contains(choose4))
                    {
                        string[] mas = l.Split('@');
                        list.Add(mas[0]);
                    }
                    if (l.Contains(choose5))
                    {
                        string[] mas = l.Split('@');
                        list.Add(mas[0]);
                    }
                    listBox9.Items.AddRange(list.ToArray());
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox9.Items.Clear();
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                foreach (string l in sr.ReadToEnd().Split(";"))
                {
                    string[] mas = l.Split('@');
                    string n = mas[0];
                    listBox9.Items.Add(n);
                }
                Class1.Instance.AddHash(listBox9);
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
                checkedListBox2.SelectedItem = null;
            }
            listBox5.SelectedItem = null;
            listBox6.SelectedItem = null;
            listBox7.SelectedItem = null;
            listBox8.SelectedItem = null;
        }
    }
}

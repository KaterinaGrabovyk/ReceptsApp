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
        private void Find_Click(object sender, EventArgs e)
        {
        }//nothing 
        private void button1_Click(object sender, EventArgs e)
        {
            string cookType1;
            string cookType2;
            string cookType3;
            string check;
            string cookType4;
            string time1;
            string time2;
            string ing;
            string rec;
            if (listBox1.SelectedItem == null)
            {
                cookType1 = "Nothing";
            }
            else
            {
                cookType1 = $"Тип страви:{listBox1.SelectedItem}";
            }
            if (listBox2.SelectedItem == null)
            {
                cookType2 = $"Спосіб приготування:Nothing";
            }
            else
            {
                cookType2 = $"Тип страви:{listBox2.SelectedItem}";
            }
            if (listBox3.SelectedItem == null)
            {
                cookType3 = "Nothing";
            }
            else
            {
                cookType3 = $"Кухонний регіон:{listBox3.SelectedItem}";
            }
            if (listBox4.SelectedItem == null)
            {
                cookType4 = "Nothing";
            }
            else
            {
                cookType4 = $"Харчові вподобання:{listBox4.SelectedItem}"; ;
            }
            if (checkedListBox1.SelectedItems.Count == 0)
            {
                check = "Nothing";
            }
            else
            {
                check = "Сировинний склад:";
                foreach (var i in checkedListBox1.CheckedItems)
                {
                    check += i.ToString() + ".";
                }
            }
            time1 = $"{numericUpDown1.Value}:{numericUpDown2.Value}";
            time2 = $"{numericUpDown3.Value}:{numericUpDown4.Value}";

            ing = textBox4.Text;
            rec = textBox5.Text;
            if (textBox1.Text == "") { MessageBox.Show("Не введені потрібні дані.","Attention",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            else
            {
                using (StreamReader sr = new StreamReader(dataFilePath))
                {
                    sr.Close();
                    string data = $"{textBox1.Text}@{cookType1}@{cookType2}@{cookType3}@{check}@{cookType4}@{time1}@{time2}@{ing}@{rec};\n";
                    File.AppendAllText(dataFilePath, data);
                    MessageBox.Show("Рецепт додано. Поля будуть очищщені","Information");
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
            List<object> res = new List<object>();
            list.Clear();
            res.Clear();
            listBox9.Items.Clear();
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                string choose1 = $"Тип страви:{listBox5.SelectedItem}";
                string choose2 = $"Спосіб приготування:{listBox6.SelectedItem}";
                string choose3 = $"Кухонний регіон:{listBox7.SelectedItem}";
                string choose5 = "Сировинний склад:";
                foreach (var i in checkedListBox2.CheckedItems)
                {
                    choose5 += i.ToString() + ".";
                }
                string choose4 = $"Харчові вподобання:{listBox8.SelectedItem}";
                foreach (string l in sr.ReadToEnd().Split(";"))
                {

                    if (listBox5.SelectedItem != null)
                    {
                        if (l.Contains(choose1))
                        {
                            list.Add(l);
                        }
                    }
                    if (listBox6.SelectedItem != null)
                    {
                        if (l.Contains(choose2))
                        {
                            list.Add(l);
                        }
                    }
                    if (listBox7.SelectedItem != null)
                    {
                        if (l.Contains(choose3))
                        {
                            list.Add(l);
                        }
                    }
                    if (listBox8.SelectedItem != null)
                    {
                        if (l.Contains(choose4))
                        {
                            list.Add(l);
                        }
                    }
                    if (checkedListBox2.SelectedItems.Count != 0)
                    {
                        if (l.Contains(choose5))
                        {
                            list.Add(l);
                        }
                    }

                }
                res=list.Distinct().ToList();
                listBox9.Items.AddRange(res.ToArray());

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

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox6.SelectedItem != null)
            {
                listBox5.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
            }
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox7.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox5.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
            }
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox8.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox5.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox2.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                listBox5.SelectionMode = SelectionMode.None;
            }
        }
    }
}

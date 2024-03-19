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
                cookType2 = $"Спосіб приготування:{listBox2.SelectedItem}";
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
            if (checkedListBox1.CheckedItems.Count == 0)
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
            if (textBox1.Text == "") { MessageBox.Show("Не введені потрібні дані.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                using (StreamReader sr = new StreamReader(dataFilePath))
                {
                    sr.Close();
                    string data = $"{textBox1.Text}@{cookType1}@{cookType2}@{cookType3}@{check}@{cookType4}@{time1}@{time2}@{ing}@{rec};\n";
                    File.AppendAllText(dataFilePath, data);
                    MessageBox.Show("Рецепт додано. Поля будуть очищщені", "Information");
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
            info.Visible = false;
            label25.Location = new Point(519, 47);
            label25.Text = "";
            List<object> list = new List<object>();
            List<object> res = new List<object>();
            list.Clear();
            res.Clear();
            listBox9.Items.Clear();
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                string choose1 = $"{listBox5.SelectedItem}";
                string choose2 = $"{listBox6.SelectedItem}";
                string choose3 = $"{listBox7.SelectedItem}";
                string choose5 = "";
                foreach (var i in checkedListBox2.CheckedItems)
                {
                    choose5 += i.ToString() + ".";
                }
                string choose4 = $"{listBox8.SelectedItem}";
                foreach (string l in sr.ReadToEnd().Split(";"))
                {
                    string[]mas=l.Split('@');
                    if (listBox5.SelectedItem != null)
                    {
                        if (l.Contains(choose1))
                        {
                            list.Add(mas[0]);
                        }
                        info.Visible = true;
                        label25.Location = new Point(348, 14);
                        label25.Text = "Тип страви:";
                        info.Text=choose1;
                    }
                    if (listBox6.SelectedItem != null)
                    {
                        if (l.Contains(choose2))
                        {
                            list.Add(mas[0]);
                        }
                        info.Visible = true;
                        label25.Location = new Point(348, 14);
                        label25.Text = "Спосіб приготування:";
                        info.Text = choose2;
                    }
                    if (listBox7.SelectedItem != null)
                    {
                        if (l.Contains(choose3))
                        {
                            list.Add(mas[0]);
                        }
                        info.Visible = true;
                        label25.Location = new Point(348, 14);
                        label25.Text = "Кухонний регіон:";
                        info.Text = choose3;
                    }
                    if (listBox8.SelectedItem != null)
                    {
                        if (l.Contains(choose4))
                        {
                            list.Add(mas[0]);
                        }
                        info.Visible = true;
                        label25.Location = new Point(348, 14);
                        label25.Text = "Харчові вподобання:";
                        info.Text = choose4;
                    }
                    if (checkedListBox2.CheckedItems.Count != 0)
                    {
                        if (l.Contains(choose5))
                        {
                            list.Add(mas[0]);

                        }
                        info.Visible = true;
                        label25.Location = new Point(348, 14);
                        label25.Text = "Сировинний склад:";
                        info.Text = choose5;
                    }

                }
                listBox9.Items.AddRange(list.ToArray());
            }      
            listBox5.SelectionMode = SelectionMode.One;
            listBox6.SelectionMode = SelectionMode.One;
            listBox7.SelectionMode = SelectionMode.One;
            listBox8.SelectionMode = SelectionMode.One;
            checkedListBox2.SelectionMode = SelectionMode.One;
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
                checkedListBox2.SelectedItem = null;
            }

            listBox5.SelectedItem = null;
            listBox6.SelectedItem = null;
            listBox7.SelectedItem = null;
            listBox8.SelectedItem = null;
            listBox5.Cursor = Cursors.Hand;
            listBox6.Cursor = Cursors.Hand;
            listBox7.Cursor = Cursors.Hand;
            listBox8.Cursor = Cursors.Hand;
            checkedListBox2.Cursor = Cursors.Hand;
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
            label25.Location = new Point(519, 47);
            info.Visible = false;
            label25.Text = "Всі рецепти";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            info.Visible = false;
            label25.Text = "";
            listBox9.Items.Clear();
            listBox5.SelectionMode = SelectionMode.One;
            listBox6.SelectionMode = SelectionMode.One;
            listBox7.SelectionMode = SelectionMode.One;
            listBox8.SelectionMode = SelectionMode.One;
            checkedListBox2.SelectionMode = SelectionMode.One;
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
                checkedListBox2.SelectedItem = null;
            }

            listBox5.SelectedItem = null;
            listBox6.SelectedItem = null;
            listBox7.SelectedItem = null;
            listBox8.SelectedItem = null;
            listBox5.Cursor = Cursors.Hand;
            listBox6.Cursor = Cursors.Hand;
            listBox7.Cursor = Cursors.Hand;
            listBox8.Cursor = Cursors.Hand;
            checkedListBox2.Cursor = Cursors.Hand;
        }


        private void listBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
                listBox6.Cursor = Cursors.No;
                listBox7.Cursor = Cursors.No;
                listBox8.Cursor = Cursors.No;
                checkedListBox2.Cursor= Cursors.No;
            }
        }

        private void listBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox6.SelectedItem != null)
            {
                listBox5.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
                listBox5.Cursor = Cursors.No;
                listBox7.Cursor = Cursors.No;
                listBox8.Cursor = Cursors.No;
                checkedListBox2.Cursor = Cursors.No;
            }
        }

        private void listBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox7.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox5.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
                listBox5.Cursor = Cursors.No;
                listBox6.Cursor = Cursors.No;
                listBox8.Cursor = Cursors.No;
                checkedListBox2.Cursor = Cursors.No;
            }
        }

        private void listBox8_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox8.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox5.SelectionMode = SelectionMode.None;
                checkedListBox2.SelectionMode = SelectionMode.None;
                listBox5.Cursor = Cursors.No;
                listBox6.Cursor = Cursors.No;
                listBox7.Cursor = Cursors.No;
                checkedListBox2.Cursor = Cursors.No;
            }
        }

        private void checkedListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (checkedListBox2.SelectedItem != null)
            {
                listBox6.SelectionMode = SelectionMode.None;
                listBox7.SelectionMode = SelectionMode.None;
                listBox8.SelectionMode = SelectionMode.None;
                listBox5.SelectionMode = SelectionMode.None;
                listBox5.Cursor = Cursors.No;
                listBox6.Cursor = Cursors.No;
                listBox7.Cursor = Cursors.No;
                listBox8.Cursor = Cursors.No;
            }
        }
    }
}

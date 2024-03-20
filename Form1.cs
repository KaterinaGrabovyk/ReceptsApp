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
                    MessageBox.Show("Рецепт додано. Поля будуть очищені", "Information");
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
            info.Visible = true;
            string text = "";
            label25.Location = new Point(519, 47);
            label25.Text = "";
            List<object> list = new List<object>();
            list.Clear();
            listBox9.Items.Clear();
            bool isHas=false;
            string[] mas = new string[5];
            string[] mas2;
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
                    if (listBox5.SelectedItem != null)
                    {
                    mas[0] = choose1;
                    text += choose1+"; ";
                    }
                    else
                    {
                    mas[0] = "";
                    }
                    if (listBox6.SelectedItem != null)
                    {
                        mas[1]=choose2;
                    text += choose2 + "; ";
                }
                    else
                    {
                    mas[1] = "";
                    }
                    if (listBox7.SelectedItem != null)
                    {
                        mas[2]=choose3;
                    text += choose3 + "; ";
                }
                    else
                    {
                    mas[2] = "";
                }
                    if (listBox8.SelectedItem != null)
                    {
                        mas[3]=choose4;
                    text += choose4 + "; ";
                }
                    else
                    {
                    mas[3] = "";
                }
                    if (checkedListBox2.CheckedItems.Count != 0)
                    {
                    mas[4] = choose5;
                    text += choose5 + "; ";
                }
                    else
                    {
                    mas[4] = "";
                }
                int count = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] == "")
                    {
                        count += 0;
                    }
                    else
                    {
                        count++;
                    }
                    
                }
                mas2 = new string[count];
                for (int j = 0; j < mas2.Length;)
                {
                    for (int i = 0; i < mas.Length;)
                    {

                        if (mas[i] == "")
                        {
                            i++;
                        }
                        else
                        {
                            mas2[j] = mas[i];
                            j++;
                            i++;
                        }
                    }
                }
                if (text == "")
                {
                    info.Text = "Не обрано категорію";
                }
                else
                {
                    info.Text = text;
                }
                foreach(string l in sr.ReadToEnd().Split(";"))
                {
                    string[]res=l.Split("@");
                    for(int i = 0;i<mas2.Length;i++)
                    {
                        if (l.Contains(mas2[i]))
                        {
                            isHas = true;
                        }
                        else
                        {
                            isHas=false;
                            break;
                        }
                    }
                    if (isHas == true)
                    {
                        listBox9.Items.Add(res[0]);
                    }
                }
            }
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

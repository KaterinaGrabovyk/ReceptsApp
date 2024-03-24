using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReceptsApp
{
    public partial class Form1 : Form
    {
        public Hashtable myHashTable=new Hashtable();
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
         //------Add_Button-------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            string cookType1;
            string cookType2;
            string cookType3;
            string check;
            string cookType4;
            string time1;
            string time2;
            if (listBox1.SelectedItem == null)
            {
                cookType1 = "Тип страви:Nothing";
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
                cookType3 = "Кухонний регіон:Nothing";
            }
            else
            {
                cookType3 = $"Кухонний регіон:{listBox3.SelectedItem}";
            }
            if (listBox4.SelectedItem == null)
            {
                cookType4 = "Харчові вподобання:Nothing";
            }
            else
            {
                cookType4 = $"Харчові вподобання:{listBox4.SelectedItem}"; ;
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                check = "Сировинний склад:Nothing";
            }
            else
            {
                check = "Сировинний склад:";
                foreach (var i in checkedListBox1.CheckedItems)
                {
                    check += i.ToString() + ".";
                }
            }
            time1 = $"Час підготовки: {numericUpDown1.Value}:{numericUpDown2.Value}";
            time2 = $"Час приготування: {numericUpDown3.Value}:{numericUpDown4.Value}";
            if (textBox1.Text == ""||textBox4.Text==""||textBox5.Text=="") { MessageBox.Show("Не введені потрібні дані.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                using (StreamReader sr = new StreamReader(dataFilePath))
                {
                    sr.Close();
                    string data = $"{textBox1.Text}@{cookType1}@{cookType2}@{cookType3}@{check}@{cookType4}@{time1}@{time2}@{textBox4.Text}@{textBox5.Text};\n";
                    File.AppendAllText(dataFilePath, data);
                    MessageBox.Show("Рецепт додано. Поля будуть очищені", "Information");
                    textBox1.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    Class1.Instance.Clear(listBox1, listBox2, listBox3, listBox4, checkedListBox1);
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    numericUpDown3.Value = 0;
                    numericUpDown4.Value = 0;

                }
            }

        }
        //-----------------------------------------------------
        //------Show_List_Button-------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            info.Visible = true;
            string text = "";
            label25.Location = new Point(519, 47);
            label25.Text = "";
            List<object> list = new List<object>();
            list.Clear();
            listBox9.Items.Clear();
            bool isHas = false;
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
                    text += choose1 + "; ";
                }
                else
                {
                    mas[0] = "";
                }
                if (listBox6.SelectedItem != null)
                {
                    mas[1] = choose2;
                    text += choose2 + "; ";
                }
                else
                {
                    mas[1] = "";
                }
                if (listBox7.SelectedItem != null)
                {
                    mas[2] = choose3;
                    text += choose3 + "; ";
                }
                else
                {
                    mas[2] = "";
                }
                if (listBox8.SelectedItem != null)
                {
                    mas[3] = choose4;
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
                    label25.Text = "Не обрано категорію";
                    info.Visible = false;
                }
                else
                {
                    info.Text = text;
                }
                foreach (string l in sr.ReadToEnd().Split(";"))
                {
                    string[] res = l.Split("@");
                    for (int i = 0; i < mas2.Length; i++)
                    {
                        if (l.Contains(mas2[i]))
                        {
                            isHas = true;
                        }
                        else
                        {
                            isHas = false;
                            break;
                        }
                    }
                    if (isHas == true)
                    {
                        listBox9.Items.Add(res[0]);
                    }
                }
            }
            /* for (int i = 0; i < checkedListBox2.Items.Count; i++)
             {
                 checkedListBox2.SetItemChecked(i, false);
                 checkedListBox2.SelectedItem = null;
             }

             listBox5.SelectedItem = null;
             listBox6.SelectedItem = null;
             listBox7.SelectedItem = null;
             listBox8.SelectedItem = null;*/
        }
        //-----------------------------------------------------
        //------Add_To_Hash_And_Show_Button--------------------
        private void button2_Click(object sender, EventArgs e)
        {
            listBox9.Items.Clear();
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                foreach (string l in sr.ReadToEnd().Split(";"))
                {
                    string[] mas = l.Split('@');
                    listBox9.Items.Add(mas[0]);
                    if (l == null|| l=="") { label25.Text = "Рецептів немає"; }
                    else
                    {
                        label25.Text = "Всі рецепти";
                    }
                } 
            }
            Class1.Instance.AddHash(myHashTable, dataFilePath);
            label25.Location = new Point(519, 47);
            info.Visible = false;
            
        }
        //-----------------------------------------------------
        //------Clear_Buttons----------------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            info.Visible = false;
            label25.Text = "";
            listBox9.Items.Clear();
            Class1.Instance.Clear(listBox5, listBox6, listBox7, listBox8, checkedListBox2);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            numericUpDown1.Value= 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            Class1.Instance.Clear(listBox1, listBox2, listBox3, listBox4, checkedListBox1);
        }
        //-----------------------------------------------------
        //------Show_one_recept--------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox9.SelectedItem != null&&listBox9.SelectedItem!="")
            {
                Form2 form2 = new Form2();
                form2.MaximumSize=new Size(1085, 774);
                form2.MinimumSize = new Size(1085, 774);
                Label text1=new Label();
                Label text2=new Label();

                text1.Text = "Інгредієнти";
                text1.Location = new Point(3, 202);
                text1.Size = new Size(148,26);
                text2.Text = "Рецепт приготування";
                text2.Location = new Point(603, 202);
                text2.Size = new Size(262, 26);
                ListBox lf2=new ListBox();
                lf2.Size = new Size(1052, 186);
                lf2.Location = new Point(3,4);
                lf2.ScrollAlwaysVisible = true;
                lf2.SelectionMode = SelectionMode.None;
                TextBox receptText=new TextBox();
                TextBox ingredients=new TextBox();
                receptText.Size = new Size(591, 481);
                receptText.Location=new Point(464, 234);
                receptText.ScrollBars = ScrollBars.Vertical;
                receptText.Multiline = true;
                receptText.ReadOnly = true;
                ingredients.Size = new Size(450, 481);
                ingredients.Location = new Point(3, 234);
                ingredients.ScrollBars = ScrollBars.Vertical;
                ingredients.Multiline = true;
                ingredients.ReadOnly = true;
                form2.Controls.Add(lf2);
                form2.Controls.Add(receptText);
                form2.Controls.Add(ingredients);
                form2.Controls.Add(text1);
                form2.Controls.Add(text2);
                string selected = $"{listBox9.SelectedItem}";

                Class1.Instance.ShowFromHash(myHashTable,selected, receptText,ingredients, lf2,form2);
            }
            else
            {
                MessageBox.Show("Ви не обрали рецепт");
                return;
            }
        }
        //-----------------------------------------------------
    }
}

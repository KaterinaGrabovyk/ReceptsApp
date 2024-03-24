using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceptsApp
{
    internal class Class1
    {
        private static Class1 instance;
        public static Class1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Class1();
                }
                return instance;
            }
        }
        public void AddHash(Hashtable myHashTable, string dataFilePath)
        {
            myHashTable.Clear();
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                foreach (string line in sr.ReadToEnd().Split(";"))
                {
                    if (line == null)
                    {
                        break;
                    }
                    else
                    {
                        string Bs = "";
                        string[] a = line.Split("@");
                        for (int i = 0; i < a.Length - 1;)
                        {
                            if (i == a.Length - 1)
                            {
                                break;
                            }
                            else
                            {
                                Bs += a[i] + "@";

                                i++;
                            }
                        }
                        if (Bs != "")
                        {
                            myHashTable.Add(Bs, a[a.Length - 1]);
                        }
                    }
                }
            }
            
        }
        public void ShowFromHash(Hashtable myHashTable,string chose,TextBox info, TextBox ing,ListBox listBox,Form2 f)
        {
            foreach(DictionaryEntry d in myHashTable)
            {
                string to = $"{d.Key}";
                string text = $"{d.Value}";
                string[] mas = to.Split("@");
                if (mas[0] == chose)
                {
                    for(int i = 0;i < mas.Length;i++) 
                    {
                        if (i == 0)
                        {
                            f.Text = mas[i];
                        }
                        else if (i == mas.Length-2)
                        {
                            ing.Text += mas[i];
                            break;
                        }
                        else
                        {
                            listBox.Items.Add(mas[i]);
                        }
                    }
                    info.Text+=text;
                }
            }
            f.ShowDialog();
        }
        public void Clear(ListBox l1,ListBox l2,ListBox l3,ListBox l4,CheckedListBox ch1)
        {
            for (int i = 0; i < ch1.Items.Count; i++)
            {
                ch1.SetItemChecked(i, false);
                ch1.SelectedItem = null;
            }
            l1.SelectedItem = null;
            l2.SelectedItem = null;
            l3.SelectedItem = null;
            l4.SelectedItem = null;
        }
       
    }
}

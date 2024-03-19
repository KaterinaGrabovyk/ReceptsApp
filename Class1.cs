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
        string dataFilePath = "ReceptsDataIMPORTANT.txt";
        private Hashtable myHashTable;
        public void AddHash(ListBox l)
        {
            if (myHashTable != null)
            {
                myHashTable.Clear();

                using (StreamReader sr = new StreamReader(dataFilePath))
                {
                    foreach (string line in sr.ReadToEnd().Split(";"))
                    {
                        if (line != "")
                        {
                            string Bs = "";
                            string[] a = line.Split("@");
                            for (int i = 0; i < a.Length - 1;)
                            {
                                if (i == a.Length - 2)
                                {
                                    Bs += a[a.Length - 2];
                                    break;
                                }
                                else
                                {
                                    Bs += a[i] + ",";

                                    i++;
                                }
                            }

                            myHashTable.Add(Bs, a[a.Length - 1]);
                        }
                    }
                }
            }
        }
    }
}

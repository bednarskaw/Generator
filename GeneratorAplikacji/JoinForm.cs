using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneratorAplikacji
{
    public partial class JoinForm : Form
    {
        Tuple<string, string> selected;
        private List<Tuple<string, string>> items { get; set; }
        public string itemName;
        public string command;
        private List<Tuple<string, string>> addedToSelect { get; set; }
        public JoinForm(List<Tuple<string, string>> p, Tuple<string, string> s)
        {
            InitializeComponent();
            addedToSelect = new List<Tuple<string, string>>();
            items = p;
            selected = s;
            RefreshTable();
            command = "SELECT ";
            itemName = "";

        }

        private void RefreshTable()
        {
            itemName = "";
            NameTextBox.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            string txt;
            items.ForEach(el => {
                txt = el.Item1 + " from " + el.Item2;
                comboBox1.Items.Add(txt);

                comboBox2.Items.Add(txt);
            }
            );
            comboBox1.SelectedItem = selected.Item1 + " from " + selected.Item2;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            itemName = NameTextBox.Text;

            this.Close();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {

            if (items.Count >= 2 && comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {
                if (items[comboBox1.SelectedIndex].Item2 != items[comboBox2.SelectedIndex].Item2 && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    string additionalTables = "";
                    if (command.Length == 7)
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            command += items[i].Item2 + "." + items[i].Item1;
                            if (i < items.Count - 1)
                            {
                                command += ", ";
                            }
                        }
                    }
                    else
                    {
                        int idxFROM = command.IndexOf("FROM");
                        int idxJOIN = command.IndexOf("JOIN");
                        if (idxJOIN != -1)
                        {
                            command += ", " + items[comboBox1.SelectedIndex].Item2 + " JOIN " + items[comboBox2.SelectedIndex].Item2 +
                            "ON" + items[comboBox1.SelectedIndex].Item2 + "." + items[comboBox1.SelectedIndex].Item1 + "=" +
                            items[comboBox2.SelectedIndex].Item2 + "." + items[comboBox2.SelectedIndex].Item1;
                        }
                        else if (idxFROM != -1)
                        {
                            command = command.Substring(0, idxFROM - 1);
                            addedToSelect.ForEach(el => {
                                if (el.Item2 != items[comboBox1.SelectedIndex].Item2 && el.Item2 != items[comboBox2.SelectedIndex].Item2)
                                {
                                    additionalTables += ", " + el.Item2;
                                }
                            }
                            );
                        }

                    }

                    command += " FROM " + items[comboBox1.SelectedIndex].Item2 + " JOIN " + items[comboBox2.SelectedIndex].Item2 + " ON ";
                    command += items[comboBox1.SelectedIndex].Item2 + "." + items[comboBox1.SelectedIndex].Item1 + "=" +
                    items[comboBox2.SelectedIndex].Item2 + "." + items[comboBox2.SelectedIndex].Item1 + additionalTables;
                    textBox.Text = command;
                }
            }


            //CreateSelect();
            //List<Tuple<string, string>> tmp_items = new List<Tuple<string, string>>(items);
            //items.Remove(tmp_items[comboBox1.SelectedIndex]);
            //items.Remove(tmp_items[comboBox2.SelectedIndex]);


            //RefreshTable();
        }



        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (!addedToSelect.Contains(items[comboBox1.SelectedIndex]))
            {
                addedToSelect.Add(items[comboBox1.SelectedIndex]);
                if (!command.Contains("FROM"))
                {
                    command += items[comboBox1.SelectedIndex].Item2 + "." + items[comboBox1.SelectedIndex].Item1;
                    command += " FROM " + items[comboBox1.SelectedIndex].Item2;
                }
                else
                {
                    int idxFROM = command.IndexOf("FROM");
                    string code = command.Substring(idxFROM + 4);
                    string toBeSearched = items[comboBox1.SelectedIndex].Item2;
                    //int ix = code.IndexOf(toBeSearched);
                    //if (ix != -1)
                    //{
                    //    string first = code.Substring(0, ix);
                    //    string first2 = code.Substring(ix - 1, 1);
                    //    string last = "";
                    //    if (code.Length > toBeSearched.Length + 1)
                    //    {
                    //        last = code.Substring(toBeSearched.Length + 1, 1);
                    //    }
                    //}
                    if (!code.Contains(toBeSearched))
                    {
                        //int ix = command.IndexOf(toBeSearched);
                        command = command.Insert(idxFROM + 5, items[comboBox1.SelectedIndex].Item2 + ", ");
                    }
                    //if (textVar.All(c => Char.IsLetterOrDigit(c)))
                    //{
                    //    // String contains only letters & numbers
                    //}

                    command = command.Insert(idxFROM - 1, ", " + items[comboBox1.SelectedIndex].Item2 + "." + items[comboBox1.SelectedIndex].Item1);


                    //if (ix == -1)
                    //{
                    //    command.Insert(ix, items[comboBox1.SelectedIndex].Item2);
                    //    //string code = command.Substring(ix + toBeSearched.Length);
                    //    // do something here
                    //}
                }
                textBox.Text = command;
            }
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            int idxFROM = command.IndexOf("FROM");
            if (idxFROM != -1)
            {
                command = command.Insert(idxFROM - 1, ", SUM(" + items[comboBox1.SelectedIndex].Item2 + "." + items[comboBox1.SelectedIndex].Item1 + ")");
            }
            else
            {
                command += "SUM(" + items[comboBox1.SelectedIndex].Item2 + "." + items[comboBox1.SelectedIndex].Item1 + ") FROM " + items[comboBox1.SelectedIndex].Item2;
            }
            textBox.Text = command;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            command = "SELECT ";
            textBox.Text = "";
            addedToSelect.Clear();
        }
    }
}

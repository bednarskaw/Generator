using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorAplikacji
{
    public partial class Generator : Form
    {
        protected SqlConnection connectionString = new SqlConnection();
        List<CheckBox> checkboxes { get; set; }
        public Table SelectedTable { get; set; }
        public string SelectedRow { get; set; }

        List<Table> listOfTables = new List<Table>();

        List<Tuple<string,string>> items = new List<Tuple<string, string>>();
        GeneratedData generatedData = new GeneratedData();

        //List<Setting> list = new List<Setting>();

        //List<Tuple<string, string>> table = new List<Tuple<string, string>>();
        public Generator()
        {
            InitializeComponent();
            SelectedTable = new Table();
            //var a = new Setting<int> { Name = "Timeout", Value = 1000 };
            //var b = new Setting<string> { Name = "T", Value = "TEST" };
            //list.Add(a);
            //list.Add(b);
        }

        private void Generator_Load(object sender, EventArgs e)
        {
            ConnectionStringDropDown.Items.Add("Data Source =.; " +
                      "Initial Catalog=Invoices-light;" +
                      "Integrated Security=True;");
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if(connectionString.State != ConnectionState.Open)
            {
                try
                {
                    Tables.Items.Clear();
                    connectionString.ConnectionString = ConnectionStringDropDown.Text;
                    connectionString.Open();
                    DataTable schema = connectionString.GetSchema("Tables");
                    foreach (DataRow row in schema.Rows)
                    {

                        if (row[2].ToString() != "sysdiagrams")
                            Tables.Items.Add(row[2].ToString());
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                    return;
                }
            }
            if (connectionString.State == ConnectionState.Open)
            {
                connectionLabel.Text = "Połączono";
                ConnectionStringDropDown.Enabled = false;
                Columns.Enabled = true;
                Columns.Enabled = true;
                Columns.Enabled = true;
            }
            else
            {
                connectionLabel.Text = "-";
                ConnectionStringDropDown.Enabled = true;
                Columns.Enabled = false;
                Tables.Enabled = false;
                Values.Enabled = false;
            }
        }

        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        static private string GetConnectionString()
        {
            return "Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
                + "Integrated Security=true;";
        }

        private void Tables_Click(object sender, EventArgs e)
        {
            Columns.Items.Clear();
            string[] restrictionsColumns = new string[4];
            restrictionsColumns[2] = SelectedTable.Name = (string)Tables.Text;
            DataTable schemaColumns = connectionString.GetSchema("Columns", restrictionsColumns);
            foreach (System.Data.DataRow rowColumn in schemaColumns.Rows)
            {
                Columns.Items.Add(rowColumn[3].ToString());
            }
        }

        private void Columns_Click(object sender, EventArgs e)
        {
            var SelectedColumn = (string)Columns.SelectedItem;
            if (SelectedColumn == null)
                return;
            var Type = SelectedColumn.GetType().ToString();
            var pozycja = Tuple.Create(SelectedColumn, Type);
            if (!SelectedTable.item.Contains(pozycja))
            {
                SelectedTable.item.Add(pozycja);
                if (!listOfTables.Contains(SelectedTable))
                    listOfTables.Add(SelectedTable);       
            }
            
            string position = SelectedColumn + " from " + SelectedTable.Name;

            if (!Values.Items.Contains(position))
            {
                Values.Items.Add(position);
                items.Add(Tuple.Create(SelectedColumn, SelectedTable.Name));
            }
           
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (Values.SelectedItem != null)
            {
                JoinForm jf = new JoinForm(items, items[Values.SelectedIndex]);
                jf.ShowDialog();
                if (jf.command != "SELECT ")
                {
                    Commands.Items.Add(jf.command);
                    Tuple<string, string> command = new Tuple<string, string>(jf.command, jf.itemName);
                    generatedData.sqlCommands.Add(command);
                }
            }

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var filebox = new SaveFileDialog
            {
                AddExtension = true,
                AutoUpgradeEnabled = true,
                CheckPathExists = true,
                DefaultExt = ".db.exe",
                Filter = "Pliki generatora|*.exe",
                OverwritePrompt = true,
                SupportMultiDottedExtensions = true,
            };
            //GeneratedData gd = new GeneratedData();
            generatedData.ConnectionString = connectionString.ConnectionString;
            generatedData.CompanyName = NameTextBox.Text;
            var importDll = Directory.GetCurrentDirectory()+ "\\Guna.UI.dll";
            if (filebox.ShowDialog() != DialogResult.OK)
                return;
            Kreator.MakeExe(
                System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName,
                filebox.FileName,
                generatedData,
                importDll
            );
            AplikacjaWynikowa aw = new AplikacjaWynikowa(generatedData);
            aw.Show();
            //this.Close();
            //MessageBox.Show("Plik EXE został wygenerowany!");
        }
    }
}

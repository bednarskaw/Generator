using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Guna.UI;

namespace GeneratorAplikacji
{
    public partial class AplikacjaWynikowa : Form
    {
        GeneratedData generatedData;
        SqlConnection sqlConnection;
        List<Panel> listOfPanels;
        List<Guna.UI.WinForms.GunaButton> listOfButtons;
        bool addedRow;
        bool originalData;
        public AplikacjaWynikowa(GeneratedData gd)
        {
            sqlConnection = new SqlConnection();
            listOfPanels = new List<Panel>();
            listOfButtons = new List<Guna.UI.WinForms.GunaButton>();
            sqlConnection.ConnectionString = gd.ConnectionString;
            InitializeComponent();
            generatedData = gd;
            CompanyLabel.Text = gd.CompanyName;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DaneButton.Controls.Add(ArrowDown);
            DaneButton.Controls.Add(ArrowRight);
            ArrowDown.BackColor = Color.Transparent;
            ArrowDown.Location = new Point(150, 15);
            ArrowRight.BackColor = Color.Transparent;
            ArrowRight.Location = new Point(150, 15);
            listOfPanels.Add(Data0GridPanel);
            listOfButtons.Add(DaneButton0);
            addedRow = false;
            originalData = true;
        }
        private void AplikacjaWynikowa_Load_1(object sender, EventArgs e)
        {
            Point p = new Point(0, 0);
            sqlConnection.Open();
            var sqlData = new SqlDataAdapter(generatedData.sqlCommands[0].Item1, sqlConnection);
            var commandBuilder = new SqlCommandBuilder(sqlData);
            var dataSet = new DataSet();
            sqlData.Fill(dataSet);
            DaneButton0.Text = generatedData.sqlCommands[0].Item2;
            gunaDataGridView0.DataSource = dataSet.Tables[0];
            gunaDataGridView0.Name = generatedData.sqlCommands[0].Item2;

            CreateViews();


            for (int i = 1; i < generatedData.sqlCommands.Count; i++)
            {
                var sql = new SqlDataAdapter(generatedData.sqlCommands[i].Item1, sqlConnection);
                var cb = new SqlCommandBuilder(sql);
                var dt = new DataSet();
                sql.Fill(dt);

                Guna.UI.WinForms.GunaButton gunaButton = (Guna.UI.WinForms.GunaButton)DaneButton0.Clone();
                gunaButton.Name = "DaneButton" + i;
                gunaButton.Text = generatedData.sqlCommands[i].Item2;
                gunaButton.Click += new System.EventHandler(this.DaneButton0_Click);
                p.Y += 51;
                gunaButton.Location = p;
                panel10.Controls.Add(gunaButton);
                listOfButtons.Add(gunaButton);

                Panel panel = (Panel)Data0GridPanel.Clone();
                panel.Name = "Data" + i + "GridPanel";

                Guna.UI.WinForms.GunaDataGridView dataGrid = new Guna.UI.WinForms.GunaDataGridView { BackgroundColor = Color.White, Size = new Size(691, 536), Location = new Point(3, 44) };
 

                CreateDataGrid(dataGrid);
                dataGrid.DataSource = dt.Tables[0];
                dataGrid.Name = generatedData.sqlCommands[i].Item2;
                panel.Controls.Add(dataGrid);
                listOfPanels.Add(panel);
                this.Controls.Add(panel);
                //listOfPairs.Add(new Tuple<Guna.UI.WinForms.GunaButton, Panel>(gunaButton, panel));

            }


           
        }

        private void CreateDataGrid(Guna.UI.WinForms.GunaDataGridView dataGrid)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = System.Drawing.Color.White;
            dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(111)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(111)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            var zaznacz = (DataGridViewCheckBoxColumn)this.Zaznacz.Clone();
            dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            zaznacz});
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGrid.RowHeadersVisible = false;
            dataGrid.RowHeadersWidth = 62;
            dataGrid.RowTemplate.Height = 28;
            dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new System.Drawing.Size(791, 636);
            dataGrid.TabIndex = 1;
            dataGrid.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            dataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            dataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            dataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            dataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            dataGrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            dataGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(111)))), ((int)(((byte)(201)))));
            dataGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            dataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGrid.ThemeStyle.HeaderStyle.Height = 23;
            dataGrid.ThemeStyle.ReadOnly = false;
            dataGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            dataGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGrid.ThemeStyle.RowsStyle.Height = 28;
            dataGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
        }

        private void CreateViews()
        {
            for (int i = 0; i < generatedData.sqlCommands.Count; i++)
            {
                string strSQLCommand = "select count(*) from INFORMATION_SCHEMA.VIEWS where table_name = '" + generatedData.sqlCommands[i].Item2 + "'";
                SqlCommand command = new SqlCommand(strSQLCommand, sqlConnection);
                int returnvalue = (int)command.ExecuteScalar();
                if (returnvalue == 0)
                {
                    strSQLCommand = "CREATE VIEW " + generatedData.sqlCommands[i].Item2 + " AS " + generatedData.sqlCommands[i].Item1;
                    command = new SqlCommand(strSQLCommand, sqlConnection);
                    string response = (string)command.ExecuteScalar();
                    sqlConnection.Close();
                    sqlConnection.Open();
                }
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void VisibleMenu(bool visibility)
        {
            foreach (Control c in panel10.Controls)
            {
                if (c is Guna.UI.WinForms.GunaButton)
                {
                    (c as Guna.UI.WinForms.GunaButton).Visible = visibility;

                }
            }
        }
    
        private void ChangeColorMainButton(Guna.UI.WinForms.GunaButton clickedButton)
        {
            foreach (Control c in panel8.Controls)
            {
                if (c is Guna.UI.WinForms.GunaButton)
                {
                    (c as Guna.UI.WinForms.GunaButton).BaseColor = Color.FromArgb(214, 200, 234);
                }
            }
            if (clickedButton.Name != "DaneButton")
            {
                ArrowDown.Visible = false;
                ArrowRight.Visible = true;
                VisibleMenu(false);
            }
            clickedButton.BaseColor = Color.FromArgb(149, 111, 201);
        }
        private void ChangeColorDataButton(Guna.UI.WinForms.GunaButton clickedButton)
        {
            for (int i = 0; i < listOfButtons.Count; i++)
            {
                if (listOfButtons[i] is Guna.UI.WinForms.GunaButton)
                {
                    listOfButtons[i].Visible = true;
                    if (listOfButtons[i] == clickedButton)
                    {

                        listOfPanels[i].Visible = true;
                        clickedButton.BaseColor = Color.FromArgb(186, 163, 220);
                    }
                    else
                    {
                        listOfPanels[i].Visible = false;
                        listOfButtons[i].BaseColor = Color.FromArgb(214, 200, 234);
                    }
                }
            }
        }

        private void DaneButton_Click(object sender, EventArgs e)
        {
            ChangeColorMainButton(DaneButton);
            DaneButton0_Click(sender, e);
            ArrowRight.Visible = false;
            ArrowDown.Visible = true;
        }

        private void DaneButton0_Click(object sender, EventArgs e)
        {
            ChangeColorDataButton((Guna.UI.WinForms.GunaButton)sender);
        }

        private void OverviewButton_Click(object sender, EventArgs e)
        {
            ChangeColorMainButton(OverviewButton);
        }

        private void StatisticButton_Click(object sender, EventArgs e)
        {
            ChangeColorMainButton(StatisticButton);
        }

        private void gunaDataGridView0_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            addedRow = true;
        }

        private void gunaDataGridView0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("CellValueChanged");
            if (addedRow)
            {
                if (originalData)
                {
                    var dataGrid = (Guna.UI.WinForms.GunaDataGridView)sender;
                    string sqlCommand = "select distinct o.name from sys.views v join sys.sql_expression_dependencies d on d.referencing_id = v.object_id and d.referenced_id is not null join sys.objects o on o.object_id = d.referenced_id where v.name = '" + dataGrid.Name + "'";
                    List<String> columnData = new List<String>();
                    using (SqlCommand command = new SqlCommand(sqlCommand, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                columnData.Add(reader.GetString(0));
                            }
                        }
                    }
                    foreach (string data in columnData)
                    {
                       // OriginalDataForm of = new OriginalDataForm();
                        sqlCommand = "SELECT c.name 'Column Name', UPPER(LEFT(t.Name,1))+LOWER(SUBSTRING(t.Name,2,LEN(t.Name))) 'Data type', ISNULL(i.is_primary_key, 0) 'Primary Key' FROM sys.columns c INNER JOIN sys.types t ON c.user_type_id = t.user_type_id LEFT OUTER JOIN sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id LEFT OUTER JOIN sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id WHERE c.object_id = OBJECT_ID('" + data + "')";
                        List<Tuple<string, SqlDbType, bool>> columns = new List<Tuple<string, SqlDbType, bool>>();
                        using (SqlCommand command = new SqlCommand(sqlCommand, sqlConnection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string name = reader[0].ToString();
                                    SqlDbType convtype = (SqlDbType)Enum.Parse(typeof(SqlDbType), reader[1].ToString(), true);
                                    bool primary = (bool)reader[2];
                                    columns.Add(new Tuple<string, SqlDbType, bool>(name, convtype, primary));
                                }
                            }
                        }
                    }
                    //OriginalDataForm of = new OriginalDataForm();
                    //of.Show();
                    addedRow = false;
                }
            }
        }
    }
    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }
    }
}

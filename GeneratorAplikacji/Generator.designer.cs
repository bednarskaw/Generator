
namespace GeneratorAplikacji
{
    partial class Generator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectionStringLabel = new System.Windows.Forms.Label();
            this.ConnectionStringDropDown = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.Tables = new System.Windows.Forms.ListBox();
            this.Columns = new System.Windows.Forms.ListBox();
            this.Values = new System.Windows.Forms.ListBox();
            this.Commands = new System.Windows.Forms.ListBox();
            this.JoinButton = new System.Windows.Forms.Button();
            this.OperationLabel = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.labelChosen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectionStringLabel
            // 
            this.ConnectionStringLabel.AutoSize = true;
            this.ConnectionStringLabel.Location = new System.Drawing.Point(11, 12);
            this.ConnectionStringLabel.Name = "ConnectionStringLabel";
            this.ConnectionStringLabel.Size = new System.Drawing.Size(184, 20);
            this.ConnectionStringLabel.TabIndex = 0;
            this.ConnectionStringLabel.Text = "Podaj Connection String:";
            // 
            // ConnectionStringDropDown
            // 
            this.ConnectionStringDropDown.FormattingEnabled = true;
            this.ConnectionStringDropDown.Location = new System.Drawing.Point(206, 10);
            this.ConnectionStringDropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnectionStringDropDown.Name = "ConnectionStringDropDown";
            this.ConnectionStringDropDown.Size = new System.Drawing.Size(694, 28);
            this.ConnectionStringDropDown.TabIndex = 2;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(206, 41);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(273, 27);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Połącz z bazą";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(638, 41);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(262, 27);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Eksportuj program";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // Tables
            // 
            this.Tables.FormattingEnabled = true;
            this.Tables.ItemHeight = 20;
            this.Tables.Location = new System.Drawing.Point(11, 89);
            this.Tables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tables.Name = "Tables";
            this.Tables.Size = new System.Drawing.Size(186, 224);
            this.Tables.TabIndex = 5;
            this.Tables.Click += new System.EventHandler(this.Tables_Click);
            // 
            // Columns
            // 
            this.Columns.FormattingEnabled = true;
            this.Columns.ItemHeight = 20;
            this.Columns.Location = new System.Drawing.Point(228, 89);
            this.Columns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Columns.Name = "Columns";
            this.Columns.Size = new System.Drawing.Size(186, 224);
            this.Columns.TabIndex = 6;
            this.Columns.Click += new System.EventHandler(this.Columns_Click);
            // 
            // Values
            // 
            this.Values.FormattingEnabled = true;
            this.Values.ItemHeight = 20;
            this.Values.Location = new System.Drawing.Point(431, 93);
            this.Values.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Values.Name = "Values";
            this.Values.Size = new System.Drawing.Size(620, 104);
            this.Values.TabIndex = 7;
            // 
            // Commands
            // 
            this.Commands.FormattingEnabled = true;
            this.Commands.ItemHeight = 20;
            this.Commands.Location = new System.Drawing.Point(12, 411);
            this.Commands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(1041, 144);
            this.Commands.TabIndex = 9;
            // 
            // JoinButton
            // 
            this.JoinButton.Location = new System.Drawing.Point(859, 365);
            this.JoinButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(185, 30);
            this.JoinButton.TabIndex = 10;
            this.JoinButton.Text = "Wykonaj SELECT/JOIN";
            this.JoinButton.UseVisualStyleBackColor = true;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // OperationLabel
            // 
            this.OperationLabel.AutoSize = true;
            this.OperationLabel.Location = new System.Drawing.Point(431, 209);
            this.OperationLabel.Name = "OperationLabel";
            this.OperationLabel.Size = new System.Drawing.Size(227, 20);
            this.OperationLabel.TabIndex = 11;
            this.OperationLabel.Text = "Wybierz wykonywane operacje:";
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(11, 45);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(123, 20);
            this.connectionLabel.TabIndex = 13;
            this.connectionLabel.Text = "Brak połączenia";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(522, 244);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 24);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Dodawanie";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(698, 244);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(105, 24);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Usuwanie";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(859, 244);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(82, 24);
            this.checkBox3.TabIndex = 19;
            this.checkBox3.Text = "Edycja";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // labelChosen
            // 
            this.labelChosen.AutoSize = true;
            this.labelChosen.Location = new System.Drawing.Point(431, 70);
            this.labelChosen.Name = "labelChosen";
            this.labelChosen.Size = new System.Drawing.Size(153, 20);
            this.labelChosen.TabIndex = 20;
            this.labelChosen.Text = "Wybrane do selecta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Podaj nazwę firmy:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(157, 337);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(257, 26);
            this.NameTextBox.TabIndex = 22;
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1062, 559);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelChosen);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.OperationLabel);
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.Commands);
            this.Controls.Add(this.Values);
            this.Controls.Add(this.Columns);
            this.Controls.Add(this.Tables);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.ConnectionStringDropDown);
            this.Controls.Add(this.ConnectionStringLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Generator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator";
            this.Load += new System.EventHandler(this.Generator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConnectionStringLabel;
        private System.Windows.Forms.ComboBox ConnectionStringDropDown;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.ListBox Tables;
        private System.Windows.Forms.ListBox Columns;
        private System.Windows.Forms.ListBox Values;
        private System.Windows.Forms.ListBox Commands;
        private System.Windows.Forms.Button JoinButton;
        private System.Windows.Forms.Label OperationLabel;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label labelChosen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}


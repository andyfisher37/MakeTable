
namespace MakeTable
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.conn_text = new System.Windows.Forms.TextBox();
			this.check_button = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.gridView = new System.Windows.Forms.DataGridView();
			this.fAMILIYADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iMYADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.oTCHECTVODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.KEY_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aaqqBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.iASDataSet = new MakeTable.IASDataSet();
			this.get_data_button = new System.Windows.Forms.Button();
			this.make_list_button1 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.aaqqTableAdapter = new MakeTable.IASDataSetTableAdapters.AaqqTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.aaqqBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iASDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// conn_text
			// 
			this.conn_text.Enabled = false;
			this.conn_text.Location = new System.Drawing.Point(16, 27);
			this.conn_text.Margin = new System.Windows.Forms.Padding(4);
			this.conn_text.Name = "conn_text";
			this.conn_text.Size = new System.Drawing.Size(724, 22);
			this.conn_text.TabIndex = 0;
			this.conn_text.Text = "Data Source=URLS_SERVER\\SQL2008;Initial Catalog=IAS;Persist Security Info=True;Us" +
    "er ID=sa;Password=******";
			// 
			// check_button
			// 
			this.check_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.check_button.Location = new System.Drawing.Point(772, 25);
			this.check_button.Margin = new System.Windows.Forms.Padding(4);
			this.check_button.Name = "check_button";
			this.check_button.Size = new System.Drawing.Size(268, 28);
			this.check_button.TabIndex = 1;
			this.check_button.Text = "Проверить...";
			this.check_button.UseVisualStyleBackColor = false;
			this.check_button.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(236, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Проверка соединения с БД КАДРЫ:";
			// 
			// gridView
			// 
			this.gridView.AllowUserToAddRows = false;
			this.gridView.AllowUserToDeleteRows = false;
			this.gridView.AutoGenerateColumns = false;
			this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fAMILIYADataGridViewTextBoxColumn,
            this.iMYADataGridViewTextBoxColumn,
            this.oTCHECTVODataGridViewTextBoxColumn,
            this.KEY_1});
			this.gridView.DataSource = this.aaqqBindingSource;
			this.gridView.Location = new System.Drawing.Point(15, 85);
			this.gridView.Margin = new System.Windows.Forms.Padding(4);
			this.gridView.Name = "gridView";
			this.gridView.ReadOnly = true;
			this.gridView.RowHeadersWidth = 51;
			this.gridView.Size = new System.Drawing.Size(724, 145);
			this.gridView.TabIndex = 3;
			// 
			// fAMILIYADataGridViewTextBoxColumn
			// 
			this.fAMILIYADataGridViewTextBoxColumn.DataPropertyName = "FAMILIYA";
			this.fAMILIYADataGridViewTextBoxColumn.HeaderText = "FAMILIYA";
			this.fAMILIYADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fAMILIYADataGridViewTextBoxColumn.Name = "fAMILIYADataGridViewTextBoxColumn";
			this.fAMILIYADataGridViewTextBoxColumn.ReadOnly = true;
			this.fAMILIYADataGridViewTextBoxColumn.Width = 125;
			// 
			// iMYADataGridViewTextBoxColumn
			// 
			this.iMYADataGridViewTextBoxColumn.DataPropertyName = "IMYA";
			this.iMYADataGridViewTextBoxColumn.HeaderText = "IMYA";
			this.iMYADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iMYADataGridViewTextBoxColumn.Name = "iMYADataGridViewTextBoxColumn";
			this.iMYADataGridViewTextBoxColumn.ReadOnly = true;
			this.iMYADataGridViewTextBoxColumn.Width = 125;
			// 
			// oTCHECTVODataGridViewTextBoxColumn
			// 
			this.oTCHECTVODataGridViewTextBoxColumn.DataPropertyName = "OTCHECTVO";
			this.oTCHECTVODataGridViewTextBoxColumn.HeaderText = "OTCHECTVO";
			this.oTCHECTVODataGridViewTextBoxColumn.MinimumWidth = 6;
			this.oTCHECTVODataGridViewTextBoxColumn.Name = "oTCHECTVODataGridViewTextBoxColumn";
			this.oTCHECTVODataGridViewTextBoxColumn.ReadOnly = true;
			this.oTCHECTVODataGridViewTextBoxColumn.Width = 125;
			// 
			// KEY_1
			// 
			this.KEY_1.DataPropertyName = "KEY_1";
			this.KEY_1.HeaderText = "KEY_1";
			this.KEY_1.MinimumWidth = 6;
			this.KEY_1.Name = "KEY_1";
			this.KEY_1.ReadOnly = true;
			this.KEY_1.Width = 125;
			// 
			// aaqqBindingSource
			// 
			this.aaqqBindingSource.DataMember = "Aaqq";
			this.aaqqBindingSource.DataSource = this.iASDataSet;
			// 
			// iASDataSet
			// 
			this.iASDataSet.DataSetName = "IASDataSet";
			this.iASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// get_data_button
			// 
			this.get_data_button.Enabled = false;
			this.get_data_button.Location = new System.Drawing.Point(772, 60);
			this.get_data_button.Margin = new System.Windows.Forms.Padding(4);
			this.get_data_button.Name = "get_data_button";
			this.get_data_button.Size = new System.Drawing.Size(268, 28);
			this.get_data_button.TabIndex = 4;
			this.get_data_button.Text = "Выбрать данные для таблицы";
			this.get_data_button.UseVisualStyleBackColor = true;
			this.get_data_button.Click += new System.EventHandler(this.button2_Click);
			// 
			// make_list_button1
			// 
			this.make_list_button1.Enabled = false;
			this.make_list_button1.Location = new System.Drawing.Point(772, 96);
			this.make_list_button1.Margin = new System.Windows.Forms.Padding(4);
			this.make_list_button1.Name = "make_list_button1";
			this.make_list_button1.Size = new System.Drawing.Size(268, 52);
			this.make_list_button1.TabIndex = 5;
			this.make_list_button1.Text = "Сформировать таблицу в Excel";
			this.make_list_button1.UseVisualStyleBackColor = true;
			this.make_list_button1.Click += new System.EventHandler(this.make_list_button1_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.CornflowerBlue;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button6.Location = new System.Drawing.Point(772, 209);
			this.button6.Margin = new System.Windows.Forms.Padding(4);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(268, 41);
			this.button6.TabIndex = 8;
			this.button6.Text = "В ы х о д";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(747, 32);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(22, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "1.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label3.Location = new System.Drawing.Point(747, 66);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "2.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label4.Location = new System.Drawing.Point(747, 114);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(22, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "3.";
			// 
			// folderBrowser
			// 
			this.folderBrowser.Description = "Выберите папку для сохранения результата";
			// 
			// openFile
			// 
			this.openFile.Title = "Выберите файл ответа ЦАФАП";
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(15, 238);
			this.progress.Margin = new System.Windows.Forms.Padding(4);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(723, 12);
			this.progress.Step = 1;
			this.progress.TabIndex = 18;
			// 
			// aaqqTableAdapter
			// 
			this.aaqqTableAdapter.ClearBeforeFill = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 267);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.make_list_button1);
			this.Controls.Add(this.get_data_button);
			this.Controls.Add(this.gridView);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.check_button);
			this.Controls.Add(this.conn_text);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Формирование контрольной таблицы со званиями и должностями";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.aaqqBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iASDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox conn_text;
        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button get_data_button;
        private System.Windows.Forms.Button make_list_button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ProgressBar progress;
		private IASDataSet iASDataSet;
		private System.Windows.Forms.BindingSource aaqqBindingSource;
		private IASDataSetTableAdapters.AaqqTableAdapter aaqqTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn fAMILIYADataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iMYADataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn oTCHECTVODataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn KEY_1;
	}
}


using System;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace MakeTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          


        private void button1_Click(object sender, EventArgs e)
        {
            if (DataProvider._getDataSQLs(conn_text.Text, "SELECT COUNT(KEY_1) FROM AAQQ") > 0)
            {
                MessageBox.Show("Все OK!");
                this.aaqqTableAdapter.Connection.ConnectionString = conn_text.Text;
                get_data_button.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ошибка подключения к БД!\nИсправьте строку подключения и попробуйте снова");
                conn_text.Enabled = true;
                conn_text.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			// TODO: This line of code loads data into the 'iASDataSet.Aaqq' table. You can move, or remove it, as needed.
			// this.aaqqTableAdapter.Fill(this.iASDataSet.Aaqq);
			// TODO: This line of code loads data into the 'iASDataSet1.getList4IC' table. You can move, or remove it, as needed.
			// this.getList4ICTableAdapter.Fill(this.iASDataSet1.getList4IC);
			// TODO: This line of code loads data into the 'iASDataSet.getList4ILS' table. You can move, or remove it, as needed.
			//this.getList4ILSTableAdapter.Fill(this.iASDataSet.getList4ILS);

		}

		private void button2_Click(object sender, EventArgs e)
        {
            int cnt = this.aaqqTableAdapter.Fill(this.iASDataSet.Aaqq);
            
            if ( cnt > 0)
            {
                MessageBox.Show($"Данные на {cnt} сотрудников выбраны!");
                make_list_button1.Enabled = true;
                
            }
            else MessageBox.Show("Ошибка получения даных!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don`t worry! Be happy!");
            Close();
        }

        private void make_list_button1_Click(object sender, EventArgs e)
        {
            DataRowCollection rc = aaqqTableAdapter.GetData().Rows;
            
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelApp.Workbooks.Add();
            Excel._Worksheet ws = (Excel.Worksheet)excelApp.ActiveSheet;
            excelApp.ActiveWindow.Zoom = 85;
            excelApp.ScreenUpdating = false;
            int row = 2;
            int col = 1;

			ws.Cells[1, 1] = "Ключ";
			ws.Cells[1, 2] = "ФИО";
			ws.Cells[1, 3] = "Текущее звание";
			ws.Cells[1, 4] = "Дата присвоения";
            ws.Cells[1, 5] = "Предыдущее звание";
            ws.Cells[1, 6] = "Дата присвоения";
            ws.Cells[1, 7] = "Действующая должность";
            ws.Cells[1, 8] = "Тарифный разряд";
            ws.Cells[1, 9] = "Дата назначения";
            ws.Cells[1, 10] = "Предыдущая должность 1";
            ws.Cells[1, 11] = "Тарифный разряд";
            ws.Cells[1, 12] = "Дата назначени";
            ws.Cells[1, 13] = "Предыдущая должность 2";
            ws.Cells[1, 14] = "Тарифный разряд";
            ws.Cells[1, 15] = "Дата назначения";
            

			progress.Maximum = rc.Count;
            for (int i = 0; i < rc.Count; i++)
            {
                DataTable prev_zv = DataProvider._getDataSQL(conn_text.Text, $"SELECT VOIN_ZVAN, DATA_PRSV FROM PERSZVAN, ZVANIE WHERE" +
                    $" KEY_1 = {rc[i]["KEY_1"]} AND ZVANIE = KEY_ZVAN" +
                    $" ORDER BY DATA_PRSV DESC");
                DataRowCollection zv = prev_zv.Rows;

                DataTable prev_dol = DataProvider._getDataSQL(conn_text.Text, $"SELECT DATA_OT, OKLAD, NAM_OF_DOL FROM POSL_SPI, OFIC_DOL WHERE" +
                    $" KEY_POSL = {rc[i]["KEY_1"]} AND DOLZNOST = P3 AND DOLZNOST < '800000' " +
                    $" ORDER BY DATA_OT DESC");
                DataRowCollection dl = prev_dol.Rows;

                ws.Cells[row, col] = rc[i]["KEY_1"].ToString();
				ws.Cells[row, col + 1] = rc[i]["FAMILIYA"].ToString() + " " + rc[i]["IMYA"].ToString() + " " + rc[i]["OTCHECTVO"].ToString();
                ws.Cells[row, col + 2] = rc[i]["VOIN_ZVAN"].ToString();
                
                if (rc[i]["DATA_PRSV"] != DBNull.Value) ws.Cells[row, col + 3] = Convert.ToDateTime(rc[i]["DATA_PRSV"]).ToShortDateString();
                else ws.Cells[row, col + 3] = Convert.ToDateTime(zv[0]["DATA_PRSV"]).ToShortDateString(); 

				// Если званий больше 1
				if (zv.Count > 1)
                {
                    ws.Cells[row, col + 4] = zv[1]["VOIN_ZVAN"].ToString();
                    ws.Cells[row, col + 5] = Convert.ToDateTime(zv[1]["DATA_PRSV"]).ToShortDateString();
                }
                else
                {
					ws.Cells[row, col + 4] = "-";
					ws.Cells[row, col + 5] = "-";
				}

                // Текущая должность
				ws.Cells[row, col + 6] = rc[i]["NAM_OF_DOL"].ToString();
				ws.Cells[row, col + 7] = rc[i]["OKLAD"].ToString();
                ws.Cells[row, col + 8] = Convert.ToDateTime(rc[i]["DATA_VDOLZ"]).ToShortDateString();

                // Предыдущие если есть
                if (dl.Count > 1)
                {
                    ws.Cells[row, col + 9] = dl[1]["NAM_OF_DOL"].ToString();
					ws.Cells[row, col + 10] = dl[1]["OKLAD"].ToString();
					ws.Cells[row, col + 11] = Convert.ToDateTime(dl[1]["DATA_OT"]).ToShortDateString();
                }
                else
                {
					ws.Cells[row, col + 9] = "-";
					ws.Cells[row, col + 10] = "-";
					ws.Cells[row, col + 11] = "-";
				}
                if (dl.Count > 2)
                {
					ws.Cells[row, col + 12] = dl[2]["NAM_OF_DOL"].ToString();
					ws.Cells[row, col + 13] = dl[2]["OKLAD"].ToString();
					ws.Cells[row, col + 14] = Convert.ToDateTime(dl[2]["DATA_OT"]).ToShortDateString();
				}
                else
                {
					ws.Cells[row, col + 12] = "-";
					ws.Cells[row, col + 13] = "-";
					ws.Cells[row, col + 14] = "-";
				}

				row++;
                progress.Value++;
                Application.DoEvents();
                zv.Clear();
                dl.Clear();
            }
            progress.Value = 0;

            MessageBox.Show("Файл со списком создан!\nНе забудьте его сохранить...");
            excelApp.ScreenUpdating = true;
            excelApp.Visible = true;
            rc.Clear();            
        }

        //private void make_list_button2_Click(object sender, EventArgs e)
        //{
        //    DataRowCollection rc = getList4ILSTableAdapter.GetData().Rows;

        //    folderBrowser.ShowDialog();
        //    string path = folderBrowser.SelectedPath;
        //    string month = "";
        //    if (DateTime.Now.Month < 10) month = String.Format("0{0}", DateTime.Now.Month);
        //    else month = DateTime.Now.Month.ToString();
        //    string filename = String.Format("{0}\\{1}_{2}.txt", path, month, DateTime.Now.Year);

        //    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        //    {
        //        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                
        //        for (int i = 0; i < rc.Count; i++)
        //        {
        //            sw.WriteLine(String.Format("{0};{1};{2};{3}", Convert.ToDateTime(rc[i]["DATA_ROZD"]).ToShortDateString(),
        //                rc[i]["FAMILIYA"],
        //                rc[i]["IMYA"],
        //                rc[i]["OTCHECTVO"]));
        //        }
        //        sw.Close();
        //    }
        //    MessageBox.Show(String.Format("Файл {0} со списком создан!\nЗагоняйте его в ФИС ГИБДД и привет...", filename));

        //}

        //private void make_list_button3_Click(object sender, EventArgs e)
        //{
        //    DataRowCollection rc = getList4ICTableAdapter.GetData().Rows;

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = false;
        //    excelApp.Workbooks.Open(Application.StartupPath + "\\template.xltx");
        //    Excel._Worksheet ws = (Excel.Worksheet)excelApp.ActiveSheet;
        //    excelApp.ActiveWindow.Zoom = 85;
        //    excelApp.ScreenUpdating = false;
        //    int row = 10;

        //    progress.Maximum = rc.Count;

        //    for (int i = 0; i < rc.Count; i++)
        //    {
        //        ws.Cells[row, 1] = (i+1).ToString();
        //        ws.Cells[row, 2] = String.Format("{0} {1} {2}", rc[i]["FAMILIYA"], rc[i]["IMYA"], rc[i]["OTCHECTVO"]);
        //        ws.Cells[row, 3] = Convert.ToDateTime(rc[i]["DATA_ROZD"]).ToShortDateString();
        //        ws.Cells[row, 4] = rc[i]["BORN_PLACE"].ToString();
        //        string cell = "";
        //        if (rc[i]["LEAV_PLACE"] != DBNull.Value) cell += String.Format("{0}", rc[i]["LEAV_PLACE"]);
        //        if (rc[i]["STREET"] != DBNull.Value) cell += String.Format(", {0}", rc[i]["STREET"]);
        //        if (rc[i]["HOUSE"] != DBNull.Value) cell += String.Format(", {0}", rc[i]["HOUSE"]);
        //        if (rc[i]["FLAT"] != DBNull.Value) cell += String.Format(", {0}", rc[i]["FLAT"]);
        //        ws.Cells[row, 5] = cell;
        //        row++;
        //        ws.Rows[row].Insert();
        //        Application.DoEvents();
        //        progress.Value++;
        //    }
        //    progress.Value = 0;
        //    ws.Range[ws.Cells[10, 1], ws.Cells[row - 1, 5]].Borders.Weight = Excel.XlBorderWeight.xlThin;
            
        //    MessageBox.Show("Файл со списком создан!\nНе забудьте его сохранить как Книгу Excel (НЕ ШАБЛОН) и направить в ИЦ...\n");
        //    excelApp.ScreenUpdating = true;
        //    excelApp.Visible = true;
        //}
                
        //private void convert_button_Click(object sender, EventArgs e)
        //{
        //    if (openFile.ShowDialog() == DialogResult.OK)
        //    {
        //        Excel.Application excelApp = new Excel.Application();
        //        excelApp.Visible = false;
        //        excelApp.Workbooks.Open(openFile.FileName);
        //        Excel._Worksheet ws = (Excel.Worksheet)excelApp.ActiveSheet;
        //        Excel.Range rng = (Excel.Range)ws.Cells[1, 1];
        //        rng.Select();
        //        ws.Columns[5].Insert();
        //        ws.Columns[5].Insert();
        //        ws.Columns[5].Insert();
        //        ws.Cells[1, 5] = "Подразделение";
        //        ws.Cells[1, 6] = "Служба";
        //        ws.Cells[1, 7] = "Должность";
        //        rng = (Excel.Range)ws.Cells[1, 15];
        //        rng.Select();
        //        excelApp.ScreenUpdating = false;
        //        progress.Maximum = ws.UsedRange.Rows.Count;

        //        for (int i = 2; i < ws.UsedRange.Rows.Count+1; i++)
        //        {
        //            string key = ws.Cells[i, 15].Value.ToString();

        //            DataTable dt = DataProvider._getDataSQL(conn_text.Text,
        //                    String.Format("SELECT PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL FROM AAQQ INNER JOIN PODRAZD ON AAQQ.PODRAZD = PODRAZD.KEY_OF_POD INNER JOIN SLUZBA ON AAQQ.SLUZBA = SLUZBA.KEY_OF_SLU INNER JOIN OFIC_DOL ON AAQQ.REAL_DOLZN = OFIC_DOL.P3 WHERE (AAQQ.KEY_1 ={0})", key));
        //            if (dt.Rows.Count < 1)
        //                dt = DataProvider._getDataSQL(conn_text.Text,
        //                    String.Format("SELECT PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL FROM ARCHIVE INNER JOIN PODRAZD ON ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD INNER JOIN SLUZBA ON ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU INNER JOIN OFIC_DOL ON ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 WHERE (ARCHIVE.KEY_1 ={0})", key));
        //            if (dt.Rows.Count < 1)
        //                dt = DataProvider._getDataSQL(conn_text.Text,
        //                    String.Format("SELECT PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL FROM RESERV INNER JOIN PODRAZD ON RESERV.PODRAZD = PODRAZD.KEY_OF_POD INNER JOIN SLUZBA ON RESERV.SLUZBA = SLUZBA.KEY_OF_SLU INNER JOIN OFIC_DOL ON RESERV.REAL_DOLZN = OFIC_DOL.P3 WHERE (RESERV.KEY_1 ={0})", key));
        //            if (dt.Rows.Count < 1)
        //                dt = DataProvider._getDataSQL(conn_text.Text,
        //                    String.Format("SELECT PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL FROM VYEZD INNER JOIN PODRAZD ON VYEZD.PODRAZD = PODRAZD.KEY_OF_POD INNER JOIN SLUZBA ON VYEZD.SLUZBA = SLUZBA.KEY_OF_SLU INNER JOIN OFIC_DOL ON VYEZD.REAL_DOLZN = OFIC_DOL.P3 WHERE (VYEZD.KEY_1 ={0})", key));

        //            ws.Cells[i, 5] = dt.Rows[0]["PODRAZDEL"].ToString();
        //            ws.Cells[i, 6] = dt.Rows[0]["NAM_OF_SLU"].ToString();
        //            ws.Cells[i, 7] = dt.Rows[0]["NAM_OF_DOL"].ToString();
        //            dt.Clear();
        //            progress.Value++;
        //            Application.DoEvents();
        //        }
        //        progress.Value = 0;
        //        ws.Columns[15].Delete();
        //        ws.Range[ws.Cells[1, 1], ws.Cells[ws.UsedRange.Rows.Count + 1, 14]].Borders.Weight = Excel.XlBorderWeight.xlThin;
        //        ws.Range[ws.Cells[1, 1], ws.Cells[ws.UsedRange.Rows.Count + 1, 14]].Columns.AutoFit();
                
        //        Application.DoEvents();
        //        MessageBox.Show("Данные обработаны!\nНе забудьте его сохранить под другим именем...");
        //        excelApp.ScreenUpdating = true;
        //        excelApp.Visible = true;
        //    }
        //}
	}
}


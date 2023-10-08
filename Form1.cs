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

        
	}
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.X509;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace engineer
{
    public partial class maintenancework: UserControl
    {
        private readonly string connectionString = "server=localhost;user id=root;password=;database=engineer";
        public maintenancework()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM maintenance_work";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Capitalize header text
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.HeaderText = col.HeaderText.ToUpper();
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Adjust column width
                    }

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Make it fill the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(request_by.Text) || string.IsNullOrWhiteSpace(office.Text) ||
                string.IsNullOrWhiteSpace(work.Text) || string.IsNullOrWhiteSpace(remark.Text))
            {
                MessageBox.Show("Please fill all fields before saving.");
                return;
            }

            string query = "INSERT INTO maintenance_work (request_by, office, work, date_request, remark, date_complete) VALUES (@request_by, @office, @work, @date_request, @remark, @date_complete)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@request_by", request_by.Text);
                cmd.Parameters.AddWithValue("@office", office.Text);
                cmd.Parameters.AddWithValue("@work", work.Text);
                cmd.Parameters.AddWithValue("@date_request", date_request.Value);
                cmd.Parameters.AddWithValue("@remark", remark.Text);
                cmd.Parameters.AddWithValue("@date_complete", date_complete.Value);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully saved.");
                    LoadData();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            string query = "UPDATE maintenance_work SET request_by=@request_by, office=@office, work=@work, date_request=@date_request, remark=@remark, date_complete=@date_complete WHERE id=@id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@request_by", request_by.Text);
                cmd.Parameters.AddWithValue("@office", office.Text);
                cmd.Parameters.AddWithValue("@work", work.Text);
                cmd.Parameters.AddWithValue("@date_request", date_request.Value);
                cmd.Parameters.AddWithValue("@remark", remark.Text);
                cmd.Parameters.AddWithValue("@date_complete", date_complete.Value);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfully.");
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            request_by.Clear();
            office.Clear();
            work.Clear();
            remark.Clear();
            date_request.Value = DateTime.Today;
            date_complete.Value = DateTime.Today;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM maintenance_work WHERE id=@id";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record deleted successfully.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM maintenance_work WHERE request_by LIKE @search OR office LIKE @search OR work LIKE @search OR remark LIKE @search";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
            {
                try
                {
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Certificates";

                int excelColIndex = 1; // To track Excel columns excluding ID

                // Add column headers (skip ID)
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].HeaderText.ToLower() != "id")
                    {
                        Excel.Range headerCell = worksheet.Cells[1, excelColIndex];
                        headerCell.Value = dataGridView1.Columns[i].HeaderText;
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);
                        headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        excelColIndex++;
                    }
                }

                // Add data rows (skip ID)
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    excelColIndex = 1;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Columns[j].HeaderText.ToLower() != "id")
                        {
                            Excel.Range dataCell = worksheet.Cells[i + 2, excelColIndex];
                            dataCell.Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                            dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelColIndex++;
                        }
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                // Freeze top row
                worksheet.Application.ActiveWindow.SplitRow = 1;
                worksheet.Application.ActiveWindow.FreezePanes = true;

                // Show Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                request_by.Text = row.Cells["request_by"].Value.ToString();
                office.Text = row.Cells["office"].Value.ToString();
                work.Text = row.Cells["work"].Value.ToString();
                remark.Text = row.Cells["remark"].Value.ToString();
                date_request.Value = Convert.ToDateTime(row.Cells["date_request"].Value);
                date_complete.Value = Convert.ToDateTime(row.Cells["date_complete"].Value);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        
        }

        private void work_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

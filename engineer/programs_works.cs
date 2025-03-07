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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.X509;
using Excel = Microsoft.Office.Interop.Excel;

namespace engineer
{
    public partial class programs_works: UserControl
    {
        private readonly string connectionString = "server=localhost;user id=root;password=;database=engineer";
        public programs_works()
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
                    string query = "SELECT * FROM barangay_program_work";
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
            {
                if (string.IsNullOrWhiteSpace(endorsed_by.Text) ||
                    string.IsNullOrWhiteSpace(title_of_project.Text) || string.IsNullOrWhiteSpace(amount_of_project.Text))
                {
                    MessageBox.Show("Please fill all fields before saving.");
                    return;
                }

                string query = "INSERT INTO barangay_program_work (barangay, endorsed_by, title_of_project, date_endorsed, amount_of_project, source_of_funds, pow, ded, status, target_date_completion) VALUES (@barangay, @endorsed_by, @title_of_project, @date_endorsed, @amount_of_project, @source_of_funds, @pow, @ded, @status, @target_date_completion)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barangay", barangay.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@endorsed_by", endorsed_by.Text);
                    cmd.Parameters.AddWithValue("@title_of_project", title_of_project.Text);
                    cmd.Parameters.AddWithValue("@date_endorsed", date_endorsed.Value);
                    cmd.Parameters.AddWithValue("@amount_of_project", amount_of_project.Text);
                    cmd.Parameters.AddWithValue("@source_of_funds", source_of_funds.Text);
                    cmd.Parameters.AddWithValue("@pow", pow.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@ded", ded.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@status", status.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@target_date_completion", target_date_completion.Value);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                string query = "UPDATE barangay_program_work SET barangay=@barangay, endorsed_by=@endorsed_by, title_of_project=@title_of_project, date_endorsed=@date_endorsed, amount_of_project=@amount_of_project, source_of_funds=@source_of_funds, pow=@pow, ded=@ded, status=@status, target_date_completion=@target_date_completion WHERE id=@id";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barangay", barangay.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@endorsed_by", endorsed_by.Text);
                    cmd.Parameters.AddWithValue("@title_of_project", title_of_project.Text);
                    cmd.Parameters.AddWithValue("@date_endorsed", date_endorsed.Value);
                    cmd.Parameters.AddWithValue("@amount_of_project", amount_of_project.Text);
                    cmd.Parameters.AddWithValue("@source_of_funds", source_of_funds.Text);
                    cmd.Parameters.AddWithValue("@pow", pow.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@ded", ded.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@status", status.SelectedItem?.ToString() ?? ""); ;
                    cmd.Parameters.AddWithValue("@target_date_completion", target_date_completion.Value);
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
                string query = "DELETE FROM barangay_program_work WHERE id=@id";

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

        private void ClearFields()
        {
            
            endorsed_by.Clear();
            title_of_project.Clear();
            amount_of_project.Clear();
            source_of_funds.Clear();
            date_endorsed.Value = DateTime.Today;
            target_date_completion.Value = DateTime.Today;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                endorsed_by.Text = row.Cells["endorsed_by"].Value.ToString();
                title_of_project.Text = row.Cells["title_of_project"].Value.ToString();
                amount_of_project.Text = row.Cells["amount_of_project"].Value.ToString();
                source_of_funds.Text = row.Cells["source_of_funds"].Value.ToString();
                date_endorsed.Value = Convert.ToDateTime(row.Cells["date_endorsed"].Value);
                target_date_completion.Value = Convert.ToDateTime(row.Cells["target_date_completion"].Value);
            }
        }

        private void date_complete_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM barangay_program_work WHERE barangay LIKE @search OR endorsed_by LIKE @search OR title_of_project LIKE @search OR pow LIKE @search OR ded LIKE @search OR status LIKE @search";

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

        private void programs_works_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

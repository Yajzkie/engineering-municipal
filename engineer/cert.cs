using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Printing;

namespace engineer
{
    public partial class cert : UserControl
    {
        public cert()
        {
            InitializeComponent();
            LoadData();
        }

        string connection = "server=localhost;user id=root;password=;database=engineer";

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string query = "SELECT * FROM certificate";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
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
            string query = "INSERT INTO certificate (name, company, date, purpose) VALUES (@name, @company, @date, @purpose)";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", this.name.Text);
                    cmd.Parameters.AddWithValue("@company", this.company.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@purpose", this.purpose.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully saved");
                        LoadData();
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
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                string query = "UPDATE certificate SET name=@name, company=@company, date=@date, purpose=@purpose WHERE id=@id";

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", this.name.Text);
                        cmd.Parameters.AddWithValue("@company", this.company.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@purpose", this.purpose.Text);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record updated successfully");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to update.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM certificate WHERE id=@id";
                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Record deleted successfully");
                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                this.name.Text = row.Cells["name"].Value.ToString();
                this.company.Text = row.Cells["company"].Value.ToString();
                this.date.Text = row.Cells["date"].Value.ToString();
                this.purpose.Text = row.Cells["purpose"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM certificate WHERE name LIKE @search";
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");
                    DataTable dt = new DataTable();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string name = row.Cells["name"].Value?.ToString();
                    string address = row.Cells["company"].Value?.ToString();
                    DateTime parsedDate;
                    string date = DateTime.TryParse(row.Cells["date"].Value?.ToString(), out parsedDate)
                                  ? parsedDate.ToString("dd' day of 'MMMM, yyyy")
                                  : row.Cells["date"].Value?.ToString();
                    string item = row.Cells["purpose"].Value?.ToString();

                    string dates = DateTime.TryParse(row.Cells["date"].Value?.ToString(), out parsedDate)
                                  ? parsedDate.ToString("MMMM dd, yyyy")
                                  : row.Cells["date"].Value?.ToString();

                    Word.Application wordApp = new Word.Application();
                    Word.Document doc = wordApp.Documents.Open(@"C:\\Users\\user\\Documents\\template.docx");

                    ReplaceWordText("{NAME}", name, doc, true);
                    ReplaceWordText("{COMPANY}", address, doc, true);
                    ReplaceWordText("{DATE}", date, doc, true);
                    ReplaceWordText("{DATES}", dates, doc, true);
                    ReplaceWordText("{PURPOSE}", item, doc, true);

                    doc.SaveAs2(@"C:\\Users\\user\\Documents\\Certificate.docx");
                    wordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error populating Word document: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to print.");
            }
        }

        private void ReplaceWordText(string placeholder, string replacement, Word.Document doc, bool bold = false)
        {
            Word.Find findObject = doc.Content.Find;
            findObject.ClearFormatting();
            findObject.Text = placeholder;

            object replaceAll = Word.WdReplace.wdReplaceAll;

            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = replacement;

            if (bold)
            {
                findObject.Replacement.Font.Bold = 1; // Apply bold formatting
            }

            findObject.Execute(Replace: replaceAll);
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void sdfsd_Click(object sender, EventArgs e)
        {

        }
    }
}

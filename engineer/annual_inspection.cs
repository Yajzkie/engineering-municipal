using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace engineer
{
    public partial class annual_inspection : UserControl
    {
        private readonly string connectionString = "server=localhost;user id=root;password=;database=engineer";

        public annual_inspection()
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
                    string query = "SELECT * FROM annual_inspection";
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
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(structure.Text) ||
                string.IsNullOrWhiteSpace(barangay.Text) || string.IsNullOrWhiteSpace(or_number.Text))
            {
                MessageBox.Show("Please fill all fields before saving.");
                return;
            }

            string query = "INSERT INTO annual_inspection (name, structure, barangay, date, or_number, date_paid, amount) VALUES (@name, @structure, @barangay, @date, @or_number, @date_paid, @amount)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@structure", structure.Text);
                cmd.Parameters.AddWithValue("@barangay", barangay.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@date", date.Value);
                cmd.Parameters.AddWithValue("@or_number", or_number.Text);
                cmd.Parameters.AddWithValue("@date_paid", date_paid.Value);
                cmd.Parameters.AddWithValue("@amount", amount.Text);
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
            string query = "UPDATE annual_inspection SET name=@name, structure=@structure, barangay=@barangay, date=@date, or_number=@or_number, date_paid=@date_paid, amount=@amount WHERE id=@id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@structure", structure.Text);
                cmd.Parameters.AddWithValue("@barangay", barangay.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@date", date.Value);
                cmd.Parameters.AddWithValue("@or_number", or_number.Text);
                cmd.Parameters.AddWithValue("@amount", amount.Text);
                cmd.Parameters.AddWithValue("@date_paid", date_paid.Value);
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
                string query = "DELETE FROM annual_inspection WHERE id=@id";

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
            string query = "SELECT * FROM annual_inspection WHERE name LIKE @search";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
            {
                try
                {
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
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to print.");
                return;
            }

            try
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Open(@"C:\\Users\\user\\Documents\\1.docx");

                ReplaceWordText("{NAME}", row.Cells["name"].Value?.ToString(), doc);
                ReplaceWordText("{STRUCTURE}", row.Cells["structure"].Value?.ToString(), doc);
                ReplaceWordText("{BARANGAY}", row.Cells["barangay"].Value?.ToString(), doc);
                ReplaceWordText("{DATE}", Convert.ToDateTime(row.Cells["date"].Value).ToString("dd' day of 'MMMM, yyyy"), doc);
                ReplaceWordText("{OR_NUMBER}", row.Cells["or_number"].Value?.ToString(), doc);
                ReplaceWordText("{AMOUNT}", row.Cells["amount"].Value?.ToString(), doc);
                ReplaceWordText("{DATE_PAID}", Convert.ToDateTime(row.Cells["date_paid"].Value).ToString("dd/MM/yyyy"), doc);

                doc.SaveAs2(@"C:\\Users\\user\\Documents\\engineer office\\certificate of annual inspection\\Certificate.docx");
                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ReplaceWordText(string placeholder, string replacement, Word.Document doc, bool bold = true)
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                name.Text = row.Cells["name"].Value.ToString();
                structure.Text = row.Cells["structure"].Value.ToString();
                barangay.Text = row.Cells["barangay"].Value.ToString();
                or_number.Text = row.Cells["or_number"].Value.ToString();
                amount.Text = row.Cells["amount"].Value.ToString();
                date.Value = Convert.ToDateTime(row.Cells["date"].Value);
                date_paid.Value = Convert.ToDateTime(row.Cells["date_paid"].Value);
            }
        }

        private void ClearFields()
        {
            name.Clear();
            structure.Clear();
            or_number.Clear();
            date.Value = DateTime.Today;
            date_paid.Value = DateTime.Today;
        }

        
        private void barangay_TextChanged(object sender, EventArgs e)
        {

        }

        private void structure_TextChanged(object sender, EventArgs e)
        {

        }

        private void or_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

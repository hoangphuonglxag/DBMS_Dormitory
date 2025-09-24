using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace project
{
    public partial class fMyBill : Form
    {
        private readonly int _userId;
        private readonly DataProvider _dataProvider;

        public fMyBill(int userId, DataProvider dataProvider)
        {
            InitializeComponent();
            _userId = userId;
            _dataProvider = dataProvider;
        }

        private void fMyBill_Load(object sender, EventArgs e)
        {
            // Cài đặt giá trị mặc định cho tháng/năm là tháng trước
            var lastMonth = DateTime.Now.AddMonths(-1);
            numMonth.Value = lastMonth.Month;
            numYear.Value = lastMonth.Year;

            StyleDataGridView(dgvBillDetails);
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            int month = (int)numMonth.Value;
            int year = (int)numYear.Value;

            try
            {
                DataTable dt = _dataProvider.GetUserBill(_userId, month, year);
                dgvBillDetails.DataSource = dt;

                // Tính tổng tiền
                decimal totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["Thành tiền"]);
                }

                // Định dạng và hiển thị tổng tiền
                CultureInfo culture = new CultureInfo("vi-VN");
                lblTotalAmount.Text = totalAmount.ToString("c0", culture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 52, 98);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(75, 135, 185);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }
    }
}
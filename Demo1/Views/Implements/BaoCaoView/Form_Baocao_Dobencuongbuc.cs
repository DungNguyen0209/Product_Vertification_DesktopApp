using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.BaoCaoViews
{
    public partial class Form_Baocao_Dobencuongbuc : UserControl
    {
        public Form_Baocao_Dobencuongbuc()
        {
            InitializeComponent();
        }

        private void Form_Baocao_Dobencuongbuc_Load(object sender, EventArgs e)
        {
            dataGridView_dobencuongbuc.BorderStyle = BorderStyle.None;
            dataGridView_dobencuongbuc.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 243, 250);
            dataGridView_dobencuongbuc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(193, 218, 240);
            dataGridView_dobencuongbuc.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_dobencuongbuc.BackgroundColor = Color.White;
            dataGridView_dobencuongbuc.EnableHeadersVisualStyles = false;
            dataGridView_dobencuongbuc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_dobencuongbuc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
            dataGridView_dobencuongbuc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}

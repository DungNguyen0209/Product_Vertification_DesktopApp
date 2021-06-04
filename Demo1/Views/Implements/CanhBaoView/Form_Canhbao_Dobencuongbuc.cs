using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views. Implements.CanhBaoView
{
    public partial class Form_Canhbao_Dobencuongbuc : UserControl
    {
        public Form_Canhbao_Dobencuongbuc()
        {
            InitializeComponent();
        }

        private void Form_Canhbao_Dobencuongbuc_Load(object sender, EventArgs e)
        {
            dataGridView_dobencuongbuc.ColumnHeadersHeight = 50;
            dataGridView_dobencuongbuc.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_dobencuongbuc.BackgroundColor = Color.White;
            dataGridView_dobencuongbuc.EnableHeadersVisualStyles = false;
            //dataGridView_doben.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_dobencuongbuc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
            dataGridView_dobencuongbuc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}

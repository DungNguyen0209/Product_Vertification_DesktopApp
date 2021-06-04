using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.BaoCaoView
{
    public partial class Form_Baocao_Doben : UserControl
    {
        public Form_Baocao_Doben()
        {
            InitializeComponent();
        }

        private void Form_Baocao_Doben_Load(object sender, EventArgs e)
        {
            dataGridView_doben.BorderStyle = BorderStyle.None;
            dataGridView_doben.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 243, 250);
            dataGridView_doben.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(193, 218, 240);
            dataGridView_doben.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_doben.BackgroundColor = Color.White;
            dataGridView_doben.EnableHeadersVisualStyles = false;
            dataGridView_doben.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_doben.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
            dataGridView_doben.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}

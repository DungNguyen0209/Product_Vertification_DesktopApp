using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.LichSuView
{
    public partial class Form_Lichsu_Dobiendang : UserControl
    {
        public Form_Lichsu_Dobiendang()
        {
            InitializeComponent();
        }

        private void Form_Lichsu_Dobiendang_Load(object sender, EventArgs e)
        {
            dataGridView_dobiendang.ColumnHeadersHeight = 50;
            dataGridView_dobiendang.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_dobiendang.BackgroundColor = Color.White;
            dataGridView_dobiendang.EnableHeadersVisualStyles = false;
            //dataGridView_doben.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_dobiendang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
            dataGridView_dobiendang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}

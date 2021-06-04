using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.BaoCaoView.BaoCaoMKTDoBienDangView
{
    public partial class Form_Baocao_Chiulucuon : UserControl
    {

        public Form_Baocao_Chiulucuon()
        {
            InitializeComponent();

        }

        private void Form_Baocao_Chiulucuon_Load(object sender, EventArgs e)
        {

            // dataGridView_chiulucuon.Rows[0].Height = 40;
            dataGridView_chiulucuon.ColumnHeadersHeight = 50;
            dataGridView_chiulucuon.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_chiulucuon.BackgroundColor = Color.White;
            dataGridView_chiulucuon.EnableHeadersVisualStyles = false;
            //dataGridView_chiulucuon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_chiulucuon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
            dataGridView_chiulucuon.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

    }
}

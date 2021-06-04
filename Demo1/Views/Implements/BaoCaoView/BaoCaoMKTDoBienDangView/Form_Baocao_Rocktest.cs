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
    public partial class Form_Baocao_Rocktest : UserControl
    {
        public Form_Baocao_Rocktest()
        {
            InitializeComponent();
        }

        private void Form_Baocao_Rocktest_Load(object sender, EventArgs e)
        {
            //dataGridView_rocktest.Rows[0].Height = 40;
            dataGridView_rocktest.ColumnHeadersHeight = 50;
            dataGridView_rocktest.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_rocktest.BackgroundColor = Color.White;
            dataGridView_rocktest.EnableHeadersVisualStyles = false;
            //dataGridView_rocktest.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_rocktest.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
            dataGridView_rocktest.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            
        }
       
    }
}

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
    public partial class Form_Baocao_Chiuvadap : UserControl
    {
       
        public Form_Baocao_Chiuvadap()
        {
            InitializeComponent();

            
        }

        

        private void Form_Baocao_Chiuvadap_Load(object sender, EventArgs e)
        {
            
                
                //dataGridView_chiuvadap.Rows[0].Height = 40;
                dataGridView_chiuvadap.ColumnHeadersHeight = 50;
                dataGridView_chiuvadap.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView_chiuvadap.BackgroundColor = Color.White;
                dataGridView_chiuvadap.EnableHeadersVisualStyles = false;
                //dataGridView_chiuvadap.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView_chiuvadap.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 29, 55);
                dataGridView_chiuvadap.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }

        
    
}

using ProductVertificationDesktopApp.Views.BaoCaoView.BaoCaoMKTDoBienDangView; 
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
    public partial class Form_Baocao_Dobiendang : UserControl
    {
        private readonly Form_Baocao_Chiulucuon _form_Baocao_Chiulucuon;
        private readonly Form_Baocao_Chiuvadap _form_Baocao_Chiuvadap;
        private readonly Form_Baocao_Rocktest _form_Baocao_Rocktest;

        public Form_Baocao_Dobiendang(Form_Baocao_Chiulucuon form_Baocao_Chiulucuon, Form_Baocao_Chiuvadap form_Baocao_Chiuvadap, Form_Baocao_Rocktest form_Baocao_Rocktest)
        {
            this._form_Baocao_Chiulucuon = form_Baocao_Chiulucuon;
            this._form_Baocao_Chiuvadap = form_Baocao_Chiuvadap;
            this._form_Baocao_Rocktest = form_Baocao_Rocktest;
            InitializeComponent();
            panel_dobiendang.Controls.Add(_form_Baocao_Chiulucuon);
            panel_dobiendang.Controls.Add(_form_Baocao_Chiuvadap);
            panel_dobiendang.Controls.Add(_form_Baocao_Rocktest);
            panel_dobiendang.Visible = false;
            panel_baocao_dobiendang.Visible = true;
        }
       
        private void btn_chiuvadap_Click(object sender, EventArgs e)
        {
            _form_Baocao_Chiuvadap.BringToFront();
            _form_Baocao_Chiuvadap.Visible = true;
        }

        private void btn_chiulucuon_Click(object sender, EventArgs e)
        {
            _form_Baocao_Chiulucuon.BringToFront();
            _form_Baocao_Chiulucuon.Visible = true;
        }

        private void btn_rocktest_Click(object sender, EventArgs e)
        {
            _form_Baocao_Rocktest.BringToFront();
            _form_Baocao_Rocktest.Visible = true;
        }

        
    }
}

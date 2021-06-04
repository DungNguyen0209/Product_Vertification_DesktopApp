using ProductVertificationDesktopApp.Views.BaoCaoView.BaoCaoMKTDoBienDangView;
using ProductVertificationDesktopApp.Views.BaoCaoViews;
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
    public partial class BaoCaoView : UserControl
    {
        private readonly Form_Baocao_Doben _form_Baocao_Doben;
        private readonly Form_Baocao_Dobencuongbuc _form_Baocao_Dobencuongbuc;
        private readonly Form_Baocao_Dobiendang _form_Baocao_Dobiendang;
        private Button selectedViewButton;
        private readonly Form_Baocao_Chiulucuon _form_Baocao_Chiulucuon;
        private readonly Form_Baocao_Chiuvadap _form_Baocao_Chiuvadap;
        private readonly Form_Baocao_Rocktest _form_Baocao_Rocktest;

        public BaoCaoView(Form_Baocao_Doben form_Baocao_Doben, Form_Baocao_Dobencuongbuc form_Baocao_Dobencuongbuc, Form_Baocao_Dobiendang form_Baocao_Dobiendang, Form_Baocao_Chiulucuon form_Baocao_Chiulucuon, Form_Baocao_Chiuvadap form_Baocao_Chiuvadap, Form_Baocao_Rocktest form_Baocao_Rocktest)
        {
            _form_Baocao_Doben = form_Baocao_Doben;
            _form_Baocao_Dobencuongbuc = form_Baocao_Dobencuongbuc;
            _form_Baocao_Dobiendang = form_Baocao_Dobiendang;
            _form_Baocao_Chiulucuon = form_Baocao_Chiulucuon;
            _form_Baocao_Chiuvadap = form_Baocao_Chiuvadap;
            _form_Baocao_Rocktest = form_Baocao_Rocktest;
            InitializeComponent();
            selectedViewButton = btn_mkt_doben;
            panelViewSelected.Visible = false;
            btn_mkt_doben.Click += OpenViewButton_Click;
            btn_mkt_doben_cuongbuc.Click += OpenViewButton_Click;
            btn_mkt_dobiendang.Click += OpenViewButton_Click;
            panel_baocao.Controls.Add(_form_Baocao_Dobiendang);
            panel_baocao.Controls.Add(_form_Baocao_Doben);
            panel_baocao.Controls.Add(_form_Baocao_Dobencuongbuc);
            _form_Baocao_Doben.Visible = false;
            _form_Baocao_Dobencuongbuc.Visible = false;
            _form_Baocao_Dobiendang.Visible = false;
        }

        private void HighlightButton(Button button)
        {
            //Remove highlight from previously selected button
            selectedViewButton.BackColor = Color.FromArgb(0, 41, 77);
            selectedViewButton.TextAlign = ContentAlignment.MiddleCenter;
            //Highlight this button
            selectedViewButton = button;
            selectedViewButton.BackColor = Color.FromArgb(0, 68, 128);
            panelViewSelected.Location = new Point(button.Location.X, button.Location.Y + button.Height - 10);
            panelViewSelected.Visible = true;
        }
        private void OpenViewButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            HighlightButton(button);
        }
        private void btn_mkt_doben_Click(object sender, EventArgs e)
        {
            _form_Baocao_Doben.BringToFront();
            _form_Baocao_Doben.Visible = true;

        }

        private void btn_mkt_doben_cuongbuc_Click(object sender, EventArgs e)
        {
            _form_Baocao_Dobencuongbuc.BringToFront();
            _form_Baocao_Dobencuongbuc.Visible = true;
        }

        private void btn_mkt_dobiendang_Click(object sender, EventArgs e)
        {
            _form_Baocao_Dobiendang.BringToFront();
            _form_Baocao_Dobiendang.Visible = true;
        }

        
    }
}

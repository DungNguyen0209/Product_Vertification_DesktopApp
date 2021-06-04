using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductVertificationDesktopApp.Views;
using ProductVertificationDesktopApp.Views.Implements.CanhBaoView;

namespace ProductVertificationDesktopApp.Views.Implements.CanhBaoView
{
    public partial class CanhBaoView : UserControl
    {
        private Button selectedViewButton;
        private readonly Form_Canhbao_Doben _form_Canhbao_Doben;
        private readonly Form_Canhbao_Dobencuongbuc _form_Canhbao_Dobencuongbuc;
        private readonly Form_Canhbao_Dobiendang _form_Canhbao_Dobiendang;

        public CanhBaoView(Form_Canhbao_Doben form_Canhbao_Doben, Form_Canhbao_Dobencuongbuc form_Canhbao_Dobencuongbuc, Form_Canhbao_Dobiendang form_Canhbao_Dobiendang)
        {
            _form_Canhbao_Doben = form_Canhbao_Doben ;
            _form_Canhbao_Dobencuongbuc = form_Canhbao_Dobencuongbuc;
            _form_Canhbao_Dobiendang = form_Canhbao_Dobiendang;
            InitializeComponent();
            btn_mkt_doben.Click += OpenViewButton_Click;
            btn_mkt_doben_cuongbuc.Click += OpenViewButton_Click;
            btn_mkt_dobiendang.Click += OpenViewButton_Click;
            selectedViewButton = btn_mkt_doben;
            _form_Canhbao_Doben.Visible = false;
            _form_Canhbao_Dobencuongbuc.Visible = false;
            _form_Canhbao_Dobiendang.Visible = false;
            panelCanhBao.Controls.Add(_form_Canhbao_Doben);
            panelCanhBao.Controls.Add(_form_Canhbao_Dobencuongbuc);
            panelCanhBao.Controls.Add(_form_Canhbao_Dobiendang);
            panelViewSelected.Visible = false;
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
            _form_Canhbao_Doben.BringToFront();
            _form_Canhbao_Doben.Visible = true;
        }

        private void btn_mkt_doben_cuongbuc_Click(object sender, EventArgs e)
        {
            _form_Canhbao_Dobencuongbuc.BringToFront();
            _form_Canhbao_Dobencuongbuc.Visible = true;
        }

        private void btn_mkt_dobiendang_Click(object sender, EventArgs e)
        {
            _form_Canhbao_Dobiendang.BringToFront();
            _form_Canhbao_Dobiendang.Visible = true;
        }
    }
}

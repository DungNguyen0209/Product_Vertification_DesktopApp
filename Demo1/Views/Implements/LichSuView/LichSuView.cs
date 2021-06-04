using ProductVertificationDesktopApp.Views.Implements.LichSuView;
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
    public partial class LichSuView : UserControl
    {
        private Button selectedViewButton;
        private readonly Form_Lichsu_Doben _form_Lichsu_Doben;
        private readonly Form_Lichsu_Dobencuongbuc _form_Lichsu_Dobencuongbuc;
        private readonly Form_Lichsu_Dobiendang _form_Lichsu_Dobiendang;

        public LichSuView(Form_Lichsu_Doben form_Lichsu_Doben, Form_Lichsu_Dobencuongbuc form_Lichsu_Dobencuongbuc, Form_Lichsu_Dobiendang form_Lichsu_Dobiendang)
        {
            _form_Lichsu_Doben = form_Lichsu_Doben;
            _form_Lichsu_Dobencuongbuc = form_Lichsu_Dobencuongbuc;
            _form_Lichsu_Dobiendang = form_Lichsu_Dobiendang;
            InitializeComponent();
            btn_mkt_doben.Click += OpenViewButton_Click;
            btn_mkt_doben_cuongbuc.Click += OpenViewButton_Click;
            btn_mkt_dobiendang.Click += OpenViewButton_Click;
            selectedViewButton = btn_mkt_doben;
            _form_Lichsu_Doben.Visible = false;
            _form_Lichsu_Dobencuongbuc.Visible = false;
            _form_Lichsu_Dobiendang.Visible = false;
            panel_lichsu.Controls.Add(_form_Lichsu_Dobiendang);
            panel_lichsu.Controls.Add(_form_Lichsu_Doben);
            panel_lichsu.Controls.Add(_form_Lichsu_Dobencuongbuc);
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
            _form_Lichsu_Doben.BringToFront();
            _form_Lichsu_Doben.Visible = true;
        }

        private void btn_mkt_doben_cuongbuc_Click(object sender, EventArgs e)
        {
            _form_Lichsu_Dobencuongbuc.BringToFront();
            _form_Lichsu_Dobiendang.Visible = true;
        }

        private void btn_mkt_dobiendang_Click(object sender, EventArgs e)
        {
            _form_Lichsu_Dobiendang.BringToFront();
            _form_Lichsu_Dobiendang.Visible = true;
        }
    }
}

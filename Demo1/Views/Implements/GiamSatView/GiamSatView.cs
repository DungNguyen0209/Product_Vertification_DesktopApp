using ProductVertificationDesktopApp.Views.Implements.GiamSatView;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.GiamSatView
{
    public partial class GiamSatView : UserControl
    {
        private Button selectedViewButton;
        private readonly Form_Giamsat_Doben _form_Giamsat_Doben;
        private readonly Form_Giamsat_Dobencuongbuc _form_Giamsat_Dobencuongbuc;
        private readonly Form_Giamsat_Dobiendang _form_Giamsat_Dobiendang;

        public GiamSatView(Form_Giamsat_Doben form_Giamsat_Doben, Form_Giamsat_Dobencuongbuc form_Giamsat_Dobencuongbuc, Form_Giamsat_Dobiendang form_Giamsat_Dobiendang)
        {
            this._form_Giamsat_Doben = form_Giamsat_Doben;
            this._form_Giamsat_Dobencuongbuc = form_Giamsat_Dobencuongbuc;
            this._form_Giamsat_Dobiendang = form_Giamsat_Dobiendang;
            InitializeComponent();
            btn_mkt_doben.Click += OpenViewButton_Click;
            btn_mkt_doben_cuongbuc.Click += OpenViewButton_Click;
            btn_mkt_dobiendang.Click += OpenViewButton_Click;
            selectedViewButton = btn_mkt_doben;
            _form_Giamsat_Doben.Visible = false;
            _form_Giamsat_Dobencuongbuc.Visible = false;
            _form_Giamsat_Dobiendang.Visible = false;
            panel_giamsat.Controls.Add(_form_Giamsat_Doben);
            panel_giamsat.Controls.Add(_form_Giamsat_Dobencuongbuc);
            panel_giamsat.Controls.Add(_form_Giamsat_Dobiendang);
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

            _form_Giamsat_Doben.BringToFront();
            _form_Giamsat_Doben.Visible = true;
        }

        private void btn_mkt_doben_cuongbuc_Click(object sender, EventArgs e)
        {
            _form_Giamsat_Dobencuongbuc.BringToFront();
            _form_Giamsat_Dobencuongbuc.Visible = true;
        }

        private void btn_mkt_dobiendang_Click(object sender, EventArgs e)
        {
            _form_Giamsat_Dobiendang.BringToFront();
            _form_Giamsat_Dobiendang.Visible = true;
        }
    }
}

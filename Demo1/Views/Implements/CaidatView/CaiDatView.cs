using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Newtonsoft.Json;
using System.Threading;
using ProductVertificationDesktopApp.Views.Implements.CaiDatView;

namespace ProductVertificationDesktopApp.Views.Implements.CaiDatView
{
    public partial class CaiDatView : UserControl
    {
        private Button selectedViewButton;
        private readonly Form_Caidat_Doben _form_Doben;
        private readonly Form_Caidat_Dobencuongbuc _form_Dobencuongbuc;
        private readonly Form_Caidat_Dobiendang _form_Dobiendang;
        private readonly Caidatthongso _caidattaptrung;
        private readonly Caidatthongso _caidatthongso1;
        private readonly Caidatthongso _caidatthongso2;
        private readonly Caidatthongso _caidatthongso3;
        private readonly Caidatthongso _khac;

        public CaiDatView(Form_Caidat_Doben form_Doben, Form_Caidat_Dobencuongbuc form_Dobencuongbuc, Form_Caidat_Dobiendang form_Dobiendang, Caidatthongso caidattaptrung, Caidatthongso caidatthongso1, Caidatthongso caidatthongso2, Caidatthongso caidatthongso3, Caidatthongso khac)
        {
            this._form_Doben = form_Doben;
            this._form_Dobencuongbuc = form_Dobencuongbuc;
            this._form_Dobiendang = form_Dobiendang;
            this._caidattaptrung = caidattaptrung;
            this._caidatthongso1 = caidatthongso1;
            this._caidatthongso2 = caidatthongso2;
            this._caidatthongso3 = caidatthongso3;
            this._khac = khac;
            InitializeComponent();
            btn_mkt_doben.Click += OpenViewButton_Click;
            btn_mkt_doben_cuongbuc.Click += OpenViewButton_Click;
            btn_mkt_dobiendang.Click += OpenViewButton_Click;
            selectedViewButton = btn_mkt_doben;
            _form_Doben.Visible = false;
            _form_Dobencuongbuc.Visible = false;
            _form_Dobiendang.Visible = false;
            panelMain.Controls.Add(_form_Doben);
            panelMain.Controls.Add(_form_Dobencuongbuc);
            panelMain.Controls.Add(_form_Dobiendang);
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
            _form_Doben.BringToFront();
            _form_Doben.Visible = true;
           
        }

        private void btn_mkt_doben_cuongbuc_Click(object sender, EventArgs e)
        {
            _form_Dobencuongbuc.BringToFront();
            _form_Dobencuongbuc.Visible = true;
          
        }

        private void btn_mkt_dobiendang_Click(object sender, EventArgs e)
        {

            _form_Dobiendang.BringToFront();
            _form_Dobiendang.Visible = true;
        }
    }
}

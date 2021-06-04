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
using ProductVertificationDesktopApp.Views;
using ProductVertificationDesktopApp.Views.Implements.BaoCaoView;
using ProductVertificationDesktopApp.Views.Implements.CaiDatView;
using ProductVertificationDesktopApp.Views.Implements.CanhBaoView;
using ProductVertificationDesktopApp.Views.Implements.DangNhapView;
using ProductVertificationDesktopApp.Views.Implements.GiamSatView;
using ProductVertificationDesktopApp.Views.Implements.LichSuView;
using ProductVertificationDesktopApp.Views.Implements.TroGiupView;

namespace ProductVertificationDesktopApp
{
    public partial class MainView : Form
    {
        private IconButton selectedViewButton;

        private readonly CaiDatView _caiDatView;
        private readonly DangNhapView _dangNhapView;
        private readonly CanhBaoView _canhBaoView;
        private readonly BaoCaoView _baoCaoView;
        private readonly TroGiupView _troGiupView;
        private readonly LichSuView _lichSuView;
        private readonly GiamSatView _giamSatView;

        public MainView(CaiDatView formCaidat, DangNhapView formDangnhap, CanhBaoView formCanhbao, BaoCaoView formBaocao, TroGiupView formTrogiup, LichSuView formLichsu, GiamSatView formGiamsat )
        {
            this._caiDatView = formCaidat;
            this._dangNhapView = formDangnhap;
            this._canhBaoView = formCanhbao;
            this._baoCaoView = formBaocao;
            this._troGiupView = formTrogiup;
            this._lichSuView = formLichsu;
            this._giamSatView = formGiamsat;
            InitializeComponent();
            selectedViewButton = buttonDangNhap;

            buttonBaoCao.Click += OpenViewButton_Click;
            buttonCaiDat.Click += OpenViewButton_Click;
            buttonCanhBao.Click += OpenViewButton_Click; 
            buttonDangNhap.Click  += OpenViewButton_Click;
            buttonGiamSat.Click += OpenViewButton_Click; 
            buttonLichSu.Click += OpenViewButton_Click; 
            buttonTroGiup.Click += OpenViewButton_Click;

            HighlightButton(buttonDangNhap);

            panelView.Controls.Add(_dangNhapView);
            panelView.Controls.Add(_giamSatView);
            panelView.Controls.Add(_caiDatView);
            panelView.Controls.Add(_canhBaoView);
            panelView.Controls.Add(_baoCaoView);
            panelView.Controls.Add(_troGiupView);
            panelView.Controls.Add(_lichSuView);
        }
        private void HighlightButton(IconButton button)
        {
            //Remove highlight from previous selected button
            selectedViewButton.BackColor = Color.FromArgb(0, 41, 77);
            selectedViewButton.ForeColor = Color.White;
            selectedViewButton.TextAlign = ContentAlignment.MiddleLeft;
            selectedViewButton.IconColor = Color.White;
            selectedViewButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            selectedViewButton.ImageAlign = ContentAlignment.MiddleLeft;
            //Highlight this button
            selectedViewButton = button;
            selectedViewButton.BackColor = Color.FromArgb(235, 243, 250);
            selectedViewButton.ForeColor = Color.FromArgb(0, 29, 55);
            selectedViewButton.TextAlign = ContentAlignment.MiddleCenter;
            selectedViewButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            selectedViewButton.IconColor = Color.FromArgb(0, 29, 55);
            selectedViewButton.ImageAlign = ContentAlignment.MiddleRight;
            panelViewSelected.Location = button.Location;
        }
        private void OpenViewButton_Click(object sender, EventArgs e)
        {
            var button = (IconButton)sender;
            HighlightButton(button);
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            _dangNhapView.BringToFront();
        }

        private void buttonCaiDat_Click(object sender, EventArgs e)
        {
            _caiDatView.BringToFront();
        }

        private void buttonGiamSat_Click(object sender, EventArgs e)
        {
            _giamSatView.BringToFront();
        }

        private void buttonBaoCao_Click(object sender, EventArgs e)
        {
            _baoCaoView.BringToFront();
        }

        private void buttonCanhBao_Click(object sender, EventArgs e)
        {
            _canhBaoView.BringToFront();
        }

        private void buttonLichSu_Click(object sender, EventArgs e)
        {
            _lichSuView.BringToFront();
        }

        private void buttonTroGiup_Click(object sender, EventArgs e)
        {
            _troGiupView.BringToFront();
        }
    }
}

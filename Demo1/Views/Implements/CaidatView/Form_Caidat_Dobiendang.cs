using ProductVertificationDesktopApp.Views.Implements.CaiDatView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FontAwesome.Sharp;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.CaiDatView
{
    public partial class Form_Caidat_Dobiendang : UserControl
    {
        private Button selectedViewButton;
        private readonly Caidatthongso _testtaptrung;
        private readonly Caidatthongso _luccheo1;
        private readonly Caidatthongso _luccheo2;
        private readonly Caidatthongso _luccheo3;
        private readonly Caidatthongso _khac;
        public Form_Caidat_Dobiendang(Caidatthongso testtaptrung, Caidatthongso luccheo1, Caidatthongso luccheo2, Caidatthongso luccheo3, Caidatthongso khac)
        {
            _testtaptrung = testtaptrung;
            _luccheo1 = luccheo1;
            _luccheo2 = luccheo2;
            _luccheo3 = luccheo3;
            _khac = khac;
            InitializeComponent();
            SettingParamDesign();
            btn_baitesttaptrung1.Click += OpenViewButton_Click;
            btn_testluccheo1.Click += OpenViewButton_Click;
            btn_testluccheo2.Click += OpenViewButton_Click;
            btn_testluccheo3.Click += OpenViewButton_Click;
            btn_khac.Click += OpenViewButton_Click;
            _testtaptrung.Visible = true;
            _luccheo1.Visible = false;
            _luccheo2.Visible = false;
            _luccheo3.Visible = false;
            _khac.Visible = false;
            //HighlightButton(btn_baitesttaptrung1);
            selectedViewButton = btn_baitesttaptrung1;
            panelSetting.Controls.Add(_testtaptrung);
            panelSetting.Controls.Add(_luccheo1);
            panelSetting.Controls.Add(_luccheo2);
            panelSetting.Controls.Add(_luccheo3);
            panelSetting.Controls.Add(_khac);

        }
        private void HighlightButton(Button button)
        {
            //Remove highlight from previously selected button
            selectedViewButton.BackColor = Color.FromArgb(0, 41, 77);
            //selectedViewButton.TextAlign = ContentAlignment.MiddleCenter;
            //Highlight this button
            selectedViewButton = button;
            selectedViewButton.BackColor = Color.FromArgb(0, 68, 128);
            panelViewSelected.Visible = true;
            panelViewSelected.Location = button.Location;
        }
        private void OpenViewButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            HighlightButton(button);
        }

        private void btn_baitesttaptrung1_Click(object sender, EventArgs e)
        {
            _testtaptrung.BringToFront();
            _testtaptrung.Visible = true;
        }

        private void btn_testluccheo1_Click(object sender, EventArgs e)
        {
            _luccheo1.BringToFront();
            _luccheo1.Visible = true;
        }

        private void btn_testluccheo2_Click(object sender, EventArgs e)
        {
            _luccheo2.BringToFront();
            _luccheo2.Visible = true;
        }

        private void btn_testluccheo3_Click(object sender, EventArgs e)
        {
            _luccheo3.BringToFront();
            _luccheo3.Visible = true;
        }

        private void btn_khac_Click(object sender, EventArgs e)
        {
            _khac.BringToFront();
            _khac.Visible = true;
        }

        private void SettingParamDesign ()
        {
            _testtaptrung.CompressionForceSettingsystem12 = 1500;
            _testtaptrung.CompressionForceSettingsystem3 = 1200;
            _testtaptrung.TimeOccupying12 = 5;
            _testtaptrung.TimeOccuping3 = 7;
            _testtaptrung.NumberClick12 = 15;
            _testtaptrung.NumberClick3 = 20;

            _luccheo1.CompressionForceSettingsystem12 = 1300;
            _luccheo1.CompressionForceSettingsystem3 = 1350;
            _luccheo1.TimeOccupying12 = 50;
            _luccheo1.TimeOccuping3 = 70;
            _luccheo1.NumberClick12 = 150;
            _luccheo1.NumberClick3 = 200;

            _luccheo2.CompressionForceSettingsystem12 = 13;
            _luccheo2.CompressionForceSettingsystem3 = 135;
            _luccheo2.TimeOccupying12 = 1;
            _luccheo2.TimeOccuping3 = 1;
            _luccheo2.NumberClick12 = 1;
            _luccheo2.NumberClick3 = 1;

            _luccheo3.CompressionForceSettingsystem12 = 1200;
            _luccheo3.CompressionForceSettingsystem3 = 1000;
            _luccheo3.TimeOccupying12 = 14;
            _luccheo3.TimeOccuping3 = 13;
            _luccheo3.NumberClick12 = 15;
            _luccheo3.NumberClick3 = 10;

            _testtaptrung.Controltextboxreadonly(true,false);
            _luccheo1.Controltextboxreadonly(true,true);
            _luccheo2.Controltextboxreadonly(false,true);
            _luccheo3.Controltextboxreadonly(true,false);
        }

    }
}

using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Views.Implements.CaiDatView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.GiamSatView
{
    public partial class Form_Giamsat_Dobiendang : UserControl, IViewSupervisorDeformation
    {
        private readonly GiamSatthongso _panelDeformationParameters1;
        private readonly GiamSatthongso _panelDeformationParameters2;
        private readonly Form_ConFirmRunning _form_ConFirmRunning;
        private readonly Form_ConFirmRunning _form_ConFirmStopping;
        private readonly Form_ConFirmRunning _form_ConfirmReset;
        private Button selectedViewButton;

        public bool StartStatus
        {
            set
            {
                switch (value)
                {
                    case true:
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ovalShape_Running.BackColor = Color.Green;
                            }));
                        }
                        catch
                        {
                            ovalShape_Running.BackColor = Color.Green;
                        }
                        break;
                    case false:
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ovalShape_Running.BackColor = Color.White;
                            }));
                        }
                        catch
                        { ovalShape_Running.BackColor = Color.White; }
                        break;
                }
            }
        }
        public bool ModeStatus {
            set
            {
                switch (value)
                {
                    case true:
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ovalShape_Mode.BackColor = Color.Green;
                            }));
                        }
                        catch
                        {
                            ovalShape_Mode.BackColor = Color.Green;
                        }
                        break;
                    case false:
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ovalShape_Mode.BackColor = Color.White;
                            }));
                        }
                        catch
                        {
                            ovalShape_Mode.BackColor = Color.White;
                        }
                        break;
                }
            }
        }
        public bool Warning {
            set
            {
                switch (value)
                {
                    case true:
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ovalShape_Warning.BackColor = Color.Red;
                            }));
                        }
                        catch
                        { ovalShape_Warning.BackColor = Color.Red; }
                        break;
                    case false:
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ovalShape_Warning.BackColor = Color.White;
                            }));
                        }
                        catch
                        { ovalShape_Warning.BackColor = Color.White; }
                        break;
                }
            }
        }

        public Form_Giamsat_Dobiendang(GiamSatthongso panelDeformationParameters1, GiamSatthongso panelDeformationParameters2,Form_ConFirmRunning form_ConFirmRunning, Form_ConFirmRunning form_ConFirmStopping,Form_ConFirmRunning form_ConFirmReset)
        {
            _form_ConFirmRunning = form_ConFirmRunning;
            _form_ConFirmStopping = form_ConFirmStopping;
            _form_ConfirmReset = form_ConFirmReset;
            _panelDeformationParameters1 = panelDeformationParameters1;
            _panelDeformationParameters2 = panelDeformationParameters2;
            InitializeComponent();
            selectedViewButton = btn_thongsocaidat;
            _form_ConFirmRunning.Visible = false;
            _form_ConFirmStopping.Visible = false;
            _form_ConfirmReset.Visible = false;
            _panelDeformationParameters1.Visible = true;
            _panelDeformationParameters2.Visible = false;
            panelConfirm.Visible = false;
            panelConfirm.SendToBack();
            panelViewSelected.Visible = false;
            btn_thongsocaidat.Click += OpenViewButton_Click;
            btn_thongsovanhanh.Click += OpenViewButton_Click;
            btn_Start.Click += ConFirmStart;
            btn_Stop.Click += ConFirmStop;
            btn_Reset.Click += ConFirmReset;
            _form_ConFirmRunning.Confirm.Add(ClosingCofirm);
            _form_ConFirmStopping.Confirm.Add(ClosingCofirm);
            _form_ConfirmReset.Confirm.Add(ResetCofirm);
            panelParammeters.Controls.Add(_panelDeformationParameters1);
            panelParammeters.Controls.Add(_panelDeformationParameters2);
            panelConfirm.Controls.Add(_form_ConFirmRunning);
            panelConfirm.Controls.Add(_form_ConFirmStopping);
            panelConfirm.Controls.Add(_form_ConfirmReset);
            HighlightButton(btn_thongsocaidat);
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

        private void btn_thongsocaidat_Click(object sender, EventArgs e)
        {
            _panelDeformationParameters1.BringToFront();
            _panelDeformationParameters1.Visible = true;
        }

        private void btn_thongsovanhanh_Click(object sender, EventArgs e)
        {
            _panelDeformationParameters2.BringToFront();
            _panelDeformationParameters2.Visible = true;
        }

        public event EventHandler Start
        {
            add => btn_Start.Click += value;
            remove => btn_Start.Click -= value;
        }
        public event EventHandler Stop
        {
            add => btn_Stop.Click += value;
            remove => btn_Stop.Click -= value;
        }
        public event EventHandler Reset
        {
            add => btn_Reset.Click += value;
            remove => btn_Reset.Click -= value;
        }
        private void ConFirmStart(object sender, EventArgs e)
        {
            
            panelConfirm.BringToFront();
            panelConfirm.Visible = true;
            panelConfirm.Show();
            _form_ConFirmRunning.BringToFront();
            _form_ConFirmRunning.Visible = true;
        }
        private void ConFirmStop(object sender, EventArgs e)
        {
            panelConfirm.Visible = true;
            panelConfirm.BringToFront();
            panelConfirm.Show();
            _form_ConFirmStopping.BringToFront();
            _form_ConFirmStopping.Visible = true;
        }
        private void ConFirmReset(object sender, EventArgs e)
        {
            panelConfirm.Visible = true;
            panelConfirm.BringToFront();
            panelConfirm.Show();
            _form_ConfirmReset.BringToFront();
            _form_ConfirmReset.Visible = true;
        }

        private void ClosingCofirm(bool data)
        {
            panelConfirm.Visible = false;
            panelConfirm.SendToBack();
        }

        private void ResetCofirm(bool data)
        {
            panelConfirm.Visible = false;
            panelConfirm.SendToBack();
        }
    }
}

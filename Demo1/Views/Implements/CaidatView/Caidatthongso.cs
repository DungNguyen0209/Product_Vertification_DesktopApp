using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Views.Implements.CaidatView.Dobiendang;
using ProductVertificationDesktopApp.Views.Implements.GiamSatView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.CaiDatView

{
    public partial class Caidatthongso : UserControl, IViewSettingDeformationParam
    {
        private bool system1 = false;
        private bool system2 = false;
        private readonly ViewConfirmSetting _form_ConFirmRunning;

        public Caidatthongso(ViewConfirmSetting form_ConFirmRunning)
        {
            _form_ConFirmRunning = form_ConFirmRunning;
            InitializeComponent();
            _form_ConFirmRunning.Visible = false;
            panelConfirm.Visible = false;
            panelConfirm.SendToBack();
            _form_ConFirmRunning.Confirm.Add(ClosingCofirm);
            panelConfirm.Controls.Add(_form_ConFirmRunning);
            btn_xacnhan.Click += ConFirmStart;
        }

        public Single CompressionForceSettingsystem12 
        { 
            get
            { return Convert.ToSingle(tb_CompressionForceSettingsystem1.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_CompressionForceSettingsystem1.Text = value.ToString();
                    }));
                }
                catch
                { tb_CompressionForceSettingsystem1.Text = value.ToString(); }
             } 
        }

        public Single CompressionForceSettingsystem3 
        {
            get
            { return Convert.ToSingle(tb_CompressionForceSettingsystem3.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_CompressionForceSettingsystem3.Text = value.ToString();
                    }));
                }
                catch
                { tb_CompressionForceSettingsystem3.Text = value.ToString(); }
            }
        }
        public int TimeOccupying12
        {
            get
            { return Convert.ToInt32(tb_TimeOccupying1.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeOccupying1.Text = value.ToString();
                    }));
                }
                catch
                { tb_TimeOccupying1.Text = value.ToString(); }
            }
         }

        public int TimeOccuping3 
        {
            get
            { return Convert.ToInt32(tb_TimeOccupying3.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeOccupying3.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_TimeOccupying3.Text = value.ToString();
                }
            }
         }
        public Int16 NumberClick12 
        {
            get
            { return Convert.ToInt16(tb_NumberClick1.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_NumberClick1.Text = value.ToString();
                    }));
                }
                catch
                { tb_NumberClick1.Text = value.ToString(); }
            }
            }

        public Int16 NumberClick3 
        {
            get
            { return Convert.ToInt16(tb_NumberClick3.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_NumberClick3.Text = value.ToString();
                    }));
                }
                catch
                { tb_NumberClick3.Text = value.ToString(); }
            }
        }

        public event EventHandler ConfirmSettingSystem1;
        public event EventHandler ConfirmSettingSystem2;


        private void button1_Click(object sender, EventArgs e)
        {
            if (system1 == false)
            {
                button1.Text = "✓";
                button1.ForeColor = Color.Green;
                system1 = true;
            }
            else
            {
                button1.Text = "";
                button1.ForeColor = Color.White;
                system1 = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (system2 == false)
            {
                button2.Text = "✓";
                button2.ForeColor = Color.Green;
                system2 = true;
            }
            else
            {
                button2.Text = "";
                button2.ForeColor = Color.White;
                system2 = false;
            }
        }


        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (system1 == true && system2 == false)
            {
                ConfirmSettingSystem1?.Invoke(this, e);
                _form_ConFirmRunning.SelectMode = 1;
            }
            if (system2 == true&&system1 == false)
            {
                ConfirmSettingSystem2?.Invoke(this, e);
                _form_ConFirmRunning.SelectMode = 2;
            }
            if(system1 == true && system2 == true)
            {
                ConfirmSettingSystem1?.Invoke(this, e);
                ConfirmSettingSystem2?.Invoke(this, e);
                _form_ConFirmRunning.SelectMode = 3;
            }
            if (system1 == false && system2 == false)
            {
                _form_ConFirmRunning.SelectMode = 4;
            }
        }
        private void ConFirmStart(object sender, EventArgs e)
        {
            btn_luu.Enabled = false;
            btn_xacnhan.Enabled = false;
            Thread.Sleep(1000);
            panelConfirm.BringToFront();
            panelConfirm.Visible = true;
            panelConfirm.Show();
            _form_ConFirmRunning.BringToFront();
            _form_ConFirmRunning.Visible = true;
        }

        private void ClosingCofirm(bool data)
        {
            panelConfirm.Visible = false;
            panelConfirm.SendToBack();
            btn_luu.Enabled = true;
            btn_xacnhan.Enabled = true;
        }

        public void Controltextboxreadonly(bool system12,bool system3)
        {
            if(system12 == true)
            {
                button1.Text = "✓";
                system1 = true;
            }    
            if(system3 == true)
            {
                button2.Text = "✓";
                system2 = true;
            }    
            tb_CompressionForceSettingsystem1.ReadOnly = true;
            tb_CompressionForceSettingsystem3.ReadOnly = true;
            tb_NumberClick1.ReadOnly = true;
            tb_NumberClick3.ReadOnly = true;
            tb_TimeOccupying1.ReadOnly = true;
            tb_TimeOccupying3.ReadOnly = true;
            button1.Enabled = false;
            button2.Enabled = false;
        }
    }
}

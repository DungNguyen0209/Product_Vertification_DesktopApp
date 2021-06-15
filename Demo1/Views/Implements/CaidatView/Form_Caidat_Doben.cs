
using ProductVertificationDesktopApp.IView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.CaiDatView
{
    public partial class Form_Caidat_Doben : UserControl, IViewSettingReliability
    {
        public Form_Caidat_Doben()
        {
            InitializeComponent();
        }

        public short TimeClose
        {
            get
            {
                return Convert.ToInt16(tb_TimeClose.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeClose.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_TimeClose.Text = value.ToString();
                }
            }
        }
        public short TimeStart
        {
            get
            {
                return Convert.ToInt16(tb_timeStart.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_timeStart.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_timeStart.Text = value.ToString();
                }
            }
        }
        public int TimeNumber
        {
            get
            {
                return Convert.ToInt32(tb_Time.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_Time.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_Time.Text = value.ToString();
                }
            }
        }

        public event EventHandler Confirm
        {
            add => btn_Confirm.Click += value;
            remove => btn_Confirm.Click -= value;
        }
        public async Task<bool> UpdateSetting(string Stop, string Start, string Time)
        {

            tb_TimeClose.Text = Stop;
            tb_timeStart.Text = Start;
            tb_Time.Text = Time;
            return true;
        }
    }
}

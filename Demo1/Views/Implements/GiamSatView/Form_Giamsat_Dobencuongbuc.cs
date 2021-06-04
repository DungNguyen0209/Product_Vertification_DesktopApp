
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

namespace ProductVertificationDesktopApp.Views.Implements.GiamSatView
{
    public partial class Form_Giamsat_Dobencuongbuc : UserControl, IViewSupervisorForcedEndurance
    {
        public Form_Giamsat_Dobencuongbuc()
        {
            InitializeComponent();
        }



        public bool SupervisorStatusRun
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
                        {
                            ovalShape_Running.BackColor = Color.White;
                        }
                        break;
                }
            }
        }
        public bool SupervisorStatusWarn
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
                                ovalShape_Warning.BackColor = Color.Yellow;
                            }));
                        }
                        catch
                        {
                            ovalShape_Warning.BackColor = Color.Yellow;
                        }
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
                        {
                            ovalShape_Warning.BackColor = Color.White;
                        }
                        break;
                }
            }
        }

        public int TimeClose
        {
            get
            {
                return Convert.ToInt32(tb_TimeStopUp.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeStopUp.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_TimeStopUp.Text = value.ToString();
                }
            }
        }
        public int TimeStart
        {
            get
            {
                return Convert.ToInt32(tb_TimeStopDown.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeStopDown.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_TimeStopDown.Text = value.ToString();
                }
            }
        }
        public int TimeCount
        {
            get
            {
                return Convert.ToInt32(tb_TimeCount.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeCount.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_TimeCount.Text = value.ToString();
                }
            }
        }
        public int TimeCurrent
        {
            get
            {
                return Convert.ToInt32(tb_TimeCurrent.Text);
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeCurrent.Text = value.ToString();
                    }));
                }
                catch
                { tb_TimeCurrent.Text = value.ToString(); }
            }
        }

        public event EventHandler Starting
        {
            add => btn_Starting.Click += value;
            remove => btn_Starting.Click -= value;
        }

        public event EventHandler Stopping
        {
            add => btn_Stopping.Click += value;
            remove => btn_Stopping.Click -= value;
        }

    }
}

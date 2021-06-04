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
    public partial class GiamSatthongso : UserControl, IViewParametersSetAndSup
    {
        public GiamSatthongso()
        {
            InitializeComponent();
            tb_CompressionForceSettingsystem1.ReadOnly =true;
            tb_CompressionForceSettingsystem2.ReadOnly = true;
            tb_CompressionForceSettingsystem3.ReadOnly = true;
            tb_NumberClick1.ReadOnly = true;
            tb_NumberClick2.ReadOnly = true;
            tb_NumberClick3.ReadOnly = true;
            tb_TimeOccupying1.ReadOnly = true;
            tb_TimeOccupying2.ReadOnly = true;
            tb_TimeOccupying3.ReadOnly = true;
        }
        public int CompressionForceSettingsystem1
        {
            get
            { return Convert.ToInt32(tb_CompressionForceSettingsystem1.Text); }
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
        public int CompressionForceSettingsystem2
        {
            get
            { return Convert.ToInt32(tb_CompressionForceSettingsystem2.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_CompressionForceSettingsystem2.Text = value.ToString();
                    }));
                }
                catch
                {
                    tb_CompressionForceSettingsystem2.Text = value.ToString();
                }
            }
        }
        public int CompressionForceSettingsystem3
        {
            get
            { return Convert.ToInt32(tb_CompressionForceSettingsystem3.Text); }
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
        public int TimeOccupying1
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
        public int TimeOccupying2
        {
            get
            { return Convert.ToInt32(tb_TimeOccupying2.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_TimeOccupying2.Text = value.ToString();
                    }));
                }
                catch
                { tb_TimeOccupying2.Text = value.ToString(); }
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
        public int NumberClick1
        {
            get
            { return Convert.ToInt32(tb_NumberClick1.Text); }
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
        public int NumberClick2
        {
            get
            { return Convert.ToInt32(tb_NumberClick2.Text); }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tb_NumberClick2.Text = value.ToString();
                    }));
                }
                catch
                { tb_NumberClick2.Text = value.ToString(); }
            }
        }
        public int NumberClick3
        {
            get
            { return Convert.ToInt32(tb_NumberClick3.Text); }
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
    }
}

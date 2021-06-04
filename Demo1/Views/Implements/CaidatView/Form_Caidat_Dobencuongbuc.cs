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
    public partial class Form_Caidat_Dobencuongbuc : UserControl,IViewSettingForcedEndurance
    {
        public Form_Caidat_Dobencuongbuc()
        {
            InitializeComponent();
        }

        public short TimeStopUp { get => Convert.ToInt16(tb_TimeStopUp.Text); set => tb_TimeStopUp.Text = value.ToString(); }
        public short TimeStopDown { get => Convert.ToInt16(tb_TimeStopDown.Text); set => tb_TimeStopDown.Text = value.ToString(); }
        public int TimeNumber { get => Convert.ToInt16(tb_TimeCount.Text); set => tb_TimeCount.Text = value.ToString(); }


        public event EventHandler Confirm
        {
            add => btn_Confirm.Click += value;

            remove => btn_Confirm.Click -= value;
        }

        private void panel_bangdieukhien_Paint(object sender, PaintEventArgs e)
        {
            Graphics circle = e.Graphics;
            Pen c1 = new Pen(Color.Black, 5);
            Pen c2 = new Pen(Color.Black, 5);
            circle.DrawEllipse(c1, 80, 230, 130, 130);
            circle.DrawEllipse(c2, 370, 230, 130, 130);
            circle.Dispose();
        }
    }
}

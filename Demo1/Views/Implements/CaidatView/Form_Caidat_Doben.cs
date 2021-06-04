
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

        public short TimeClose { get => Convert.ToInt16(tb_TimeClose.Text); set => tb_TimeClose.Text=value.ToString(); }
        public short TimeStart { get => Convert.ToInt16(tb_timeStart.Text); set => tb_timeStart.Text = value.ToString(); }
        public int TimeNumber { get => Convert.ToInt16(tb_Time.Text); set => tb_Time.Text = value.ToString(); }

        public event EventHandler Confirm
        {
            add => btn_Confirm.Click += value;
            remove => btn_Confirm.Click -= value;
        }
    }
}

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
    public partial class Form_ConFirmRunning : UserControl, IViewConfirmRunning
    {
        public List<Action<bool>> Confirm { get; set; }
        public int SelectMode { get ; set ; }

        public Form_ConFirmRunning()
        {
            InitializeComponent();
            this.SelectMode = SelectMode;
            Confirm = new List<Action<bool>>();
            btn_Starting.Click += ConFirm;
            btn_Stopping.Click += ConFirm;
        }

        public event EventHandler ConfirmAction
        {
            add => btn_Starting.Click += value;
            remove => btn_Starting.Click -= value;
        }

        public event EventHandler CancelAction
        {
            add => btn_Stopping.Click += value;
            remove => btn_Stopping.Click -= value;
        }

        private void ConFirm(object sender, EventArgs e)
        {
            foreach(var handlers in Confirm)
            { 
                handlers.Invoke(true); 
            }
        }

    }
}

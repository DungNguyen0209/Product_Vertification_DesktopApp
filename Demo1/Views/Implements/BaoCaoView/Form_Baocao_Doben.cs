using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.ViewModel;
using ProductVertificationDesktopApp.helps;
using ProductVertificationDesktopApp.Views.Interface.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.Implements.BaoCaoView
{
    public partial class Form_Baocao_Doben : UserControl, IViewReportRiliability
    {
        public Form_Baocao_Doben()
        {
            InitializeComponent();
            comboBoxTarget.DataSource = Constants.Targets;
            Report = new BindingList<ReportViewModel>();
            dataGridView_doben.DataSource = Report;

            dataGridView_doben.Columns[0].Width = 125;
            dataGridView_doben.Columns[1].Width = 180;
            dataGridView_doben.Columns[2].Width = 180;
            dataGridView_doben.Columns[3].Width = 180;
            dataGridView_doben.Columns[4].Width = 180;
            dataGridView_doben.Columns[5].Width = 180;
            dataGridView_doben.Columns[6].Width = 180;
            dataGridView_doben.Columns[7].Width = 180;
            dataGridView_doben.Columns[8].Width = 180;
            dataGridView_doben.Columns[9].Width = 200;
            dataGridView_doben.Columns[10].Width = 200;
            dataGridView_doben.Columns[11].Width = 200;
            for(int i=1;i<21;i++)
            {
                var count = new ReportViewModel
                {
                    NumberTesting = Convert.ToString(i * 5000)
                };
                Report.Add(count);
                
            }    
        }
        
        public IList<ReportViewModel> Report { get; set; }
        public ETargetTest eTargetTest
        {
            get
            {
                return (ETargetTest)comboBoxTarget.SelectedIndex;
            }
            set
            {
               comboBoxTarget.SelectedIndex = value.CompareTo(eTargetTest);
            }
        }

        public event EventHandler Insert
        {
            add => button_Insert.Click += value;
            remove => button_Insert.Click -= value;
        }

        public event EventHandler LoadFromDatabase
        {
            add => button_LoadFromDataBase.Click += value;
            remove => button_LoadFromDataBase.Click -= value;
        }
        private void Form_Baocao_Doben_Load(object sender, EventArgs e)
        {
            dataGridView_doben.BorderStyle = BorderStyle.Fixed3D;
            //dataGridView_doben.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 243, 250);
            dataGridView_doben.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_doben.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_doben.BackgroundColor = Color.White;
            dataGridView_doben.EnableHeadersVisualStyles = false;
            //dataGridView_doben.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_doben.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            //dataGridView_doben.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }



    }
}

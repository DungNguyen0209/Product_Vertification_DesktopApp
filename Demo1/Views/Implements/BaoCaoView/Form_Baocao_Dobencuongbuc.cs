using ProductVertificationDesktopApp.Domain.ViewModel;
using ProductVertificationDesktopApp.helps;
using ProductVertificationDesktopApp.Interface.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Views.BaoCaoViews
{
    public partial class Form_Baocao_Dobencuongbuc : UserControl, IViewReportDeformation
    {
        public Form_Baocao_Dobencuongbuc()
        {
            InitializeComponent();
            comboBoxTarget.DataSource = Constants.Targets;
            Report = new BindingList<ReportViewModel>();

            dataGridView_dobencuongbuc.DataSource = Report;
            dataGridView_dobencuongbuc.Columns[0].Width = 125;
            dataGridView_dobencuongbuc.Columns[1].Width = 180;
            dataGridView_dobencuongbuc.Columns[2].Width = 180;
            dataGridView_dobencuongbuc.Columns[3].Width = 180;
            dataGridView_dobencuongbuc.Columns[4].Width = 180;
            dataGridView_dobencuongbuc.Columns[5].Width = 180;
            dataGridView_dobencuongbuc.Columns[6].Width = 180;
            dataGridView_dobencuongbuc.Columns[7].Width = 180;
            dataGridView_dobencuongbuc.Columns[8].Width = 180;
            dataGridView_dobencuongbuc.Columns[9].Width = 200;
            dataGridView_dobencuongbuc.Columns[10].Width = 200;
            dataGridView_dobencuongbuc.Columns[11].Width = 200;
        }
        public IList<ReportViewModel> Report { get; set; }
        private void Form_Baocao_Dobencuongbuc_Load(object sender, EventArgs e)
        {
            dataGridView_dobencuongbuc.BorderStyle = BorderStyle.Fixed3D;
            //dataGridView_doben.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 243, 250);
            dataGridView_dobencuongbuc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_dobencuongbuc.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_dobencuongbuc.BackgroundColor = Color.White;
            dataGridView_dobencuongbuc.EnableHeadersVisualStyles = false;
            //dataGridView_doben.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_dobencuongbuc.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            //dataGridView_doben.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}

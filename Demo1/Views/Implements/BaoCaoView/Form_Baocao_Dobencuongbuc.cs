using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
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
        public int eTargetTest
        {
            get
            {
                return comboBoxTarget.SelectedIndex;
            }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        comboBoxTarget.SelectedIndex = value;
                    }));
                }
                catch
                {
                    comboBoxTarget.SelectedIndex = value;
                }
            }
        }

        public DateTime TimeStampStart
        {
            get
            { return dateTimePickerStart.Value; }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        dateTimePickerStart.Value = value;
                    }));
                }
                catch
                {
                    dateTimePickerStart.Value = value;
                }
            }
        }
        public DateTime TimeStampFinish
        {
            get
            { return dateTimePickerStop.Value; }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        dateTimePickerStop.Value = value;
                    }));
                }
                catch
                {
                    dateTimePickerStop.Value = value;
                }
            }
        }

        public string NameProduct
        {
            get
            { return textBoxNameProduct.Text; }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        textBoxNameProduct.Text = value;
                    }));
                }
                catch
                {
                    textBoxNameProduct.Text = value;
                }
            }
        }

        public string Comment
        {
            get
            { return textBoxAdditional.Text; }
            set
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        textBoxAdditional.Text = value;
                    }));
                }
                catch
                {
                    textBoxAdditional.Text = value;
                }
            }
        }

        public event EventHandler Insert
        {
            add => button_Insert.Click += value;
            remove => button_Insert.Click -= value;
        }

        public event EventHandler ImportData
        {
            add => btn_ImportData.Click += value;
            remove => btn_ImportData.Click -= value;
        }

        public event EventHandler FormLoad;
        public event EventHandler FormClose;

        public void Closing(object sender, EventArgs e)
        {
            FormClose?.Invoke(this, e);
        }
        public void SuccessExcel(string s)
        {
            MessageBox.Show(s);
        }

        public async Task<ServiceResponse> ConfirmExport()
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn in bản báo cáo  ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                return ServiceResponse.Successful();
            }

            else
            {
                var error = new Error
                {
                    ErrorCode = "Cancel.Export",
                    Message = "Cancel"
                };
                return ServiceResponse.Failed(error);
            }
        }
        private void Form_Baocao_Dobencuongbuc_Load(object sender, EventArgs e)
        {
            FormLoad?.Invoke(this, e);
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

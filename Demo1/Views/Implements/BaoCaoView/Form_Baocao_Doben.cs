using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.Models.Resource;
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
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
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
                        dateTimePickerStart.Value = value.AddHours(-value.Hour).AddMinutes(-value.Minute).AddSeconds(-value.Second);
                    }));
                }
                catch
                {
                    dateTimePickerStart.Value =value.AddHours(-value.Hour).AddMinutes(-value.Minute).AddSeconds(-value.Second);
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
                        dateTimePickerStop.Value = value.AddHours(-value.Hour).AddMinutes(-value.Minute).AddSeconds(-value.Second);
                    }));
                }
                catch
                {
                    dateTimePickerStop.Value = value.AddHours(-value.Hour).AddMinutes(-value.Minute).AddSeconds(-value.Second);
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

        public async Task<ServiceResponse> ConfirmExport ()
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

        private void Form_Baocao_Doben_Load_1(object sender, EventArgs e)
        {
                        FormLoad?.Invoke(this, e);
        }


    }
}

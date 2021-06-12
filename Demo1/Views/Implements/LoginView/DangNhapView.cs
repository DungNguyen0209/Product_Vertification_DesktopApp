using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProductVertificationDesktopApp.Domain.Communication.WebApi;
using ProductVertificationDesktopApp.Views.Interface.Login;

namespace ProductVertificationDesktopApp.Views.Implements.DangNhapView
{
    public partial class DangNhapView : UserControl,IViewLogin
    {
        private event EventHandler LoginEnter;
        public DangNhapView()
        {
            InitializeComponent();
            tb_tendangnhap.Text = "Gia";
            tb_matkhau.Text = "huhuhu";
        }
        public string Username
        {
            get => tb_tendangnhap.Text;
            set => tb_tendangnhap.Text = value;
        }
        public string Password
        {
            get => tb_matkhau.Text;
            set => tb_matkhau.Text = value;
        }

        public event EventHandler LoginClick
        {
            add
            {
                btn_dangnhap.Click += value;
                LoginEnter += value;
            }
            remove
            {
                btn_dangnhap.Click -= value;
                LoginEnter -= value;
            }
        }

        private void textBoxMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LoginEnter.Invoke(this, e);
            }
        }

        public void Alert(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Success(string message)
        {
            MessageBox.Show(message, "Thông báo");
        }

    }
}

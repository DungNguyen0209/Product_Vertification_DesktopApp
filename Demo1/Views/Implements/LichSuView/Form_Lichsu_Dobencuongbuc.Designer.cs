﻿
namespace ProductVertificationDesktopApp.Views.Implements.LichSuView
{
    partial class Form_Lichsu_Dobencuongbuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_dobencuongbuc = new System.Windows.Forms.DataGridView();
            this.Sukien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thoigian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dobencuongbuc)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_dobencuongbuc
            // 
            this.dataGridView_dobencuongbuc.AllowUserToAddRows = false;
            this.dataGridView_dobencuongbuc.AllowUserToDeleteRows = false;
            this.dataGridView_dobencuongbuc.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_dobencuongbuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dobencuongbuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_dobencuongbuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dobencuongbuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sukien,
            this.Thoigian,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(54)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_dobencuongbuc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_dobencuongbuc.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_dobencuongbuc.Location = new System.Drawing.Point(152, 69);
            this.dataGridView_dobencuongbuc.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_dobencuongbuc.Name = "dataGridView_dobencuongbuc";
            this.dataGridView_dobencuongbuc.ReadOnly = true;
            this.dataGridView_dobencuongbuc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dobencuongbuc.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_dobencuongbuc.RowHeadersVisible = false;
            this.dataGridView_dobencuongbuc.RowHeadersWidth = 55;
            this.dataGridView_dobencuongbuc.RowTemplate.Height = 50;
            this.dataGridView_dobencuongbuc.Size = new System.Drawing.Size(1304, 772);
            this.dataGridView_dobencuongbuc.TabIndex = 3;
            // 
            // Sukien
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sukien.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sukien.HeaderText = "Ngày truy cập";
            this.Sukien.MinimumWidth = 6;
            this.Sukien.Name = "Sukien";
            this.Sukien.ReadOnly = true;
            this.Sukien.Width = 300;
            // 
            // Thoigian
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thoigian.DefaultCellStyle = dataGridViewCellStyle3;
            this.Thoigian.HeaderText = "Ngày kết thúc";
            this.Thoigian.MinimumWidth = 6;
            this.Thoigian.Name = "Thoigian";
            this.Thoigian.ReadOnly = true;
            this.Thoigian.Width = 300;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Số lần thử";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Thời gian lên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Form_Lichsu_Dobencuongbuc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1607, 902);
            this.Controls.Add(this.dataGridView_dobencuongbuc);
            this.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form_Lichsu_Dobencuongbuc";
            this.Text = "Form_Lichsu_Dobencuongbuc";
            this.Load += new System.EventHandler(this.Form_Lichsu_Dobencuongbuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dobencuongbuc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_dobencuongbuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sukien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thoigian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
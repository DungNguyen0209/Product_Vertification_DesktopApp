
namespace ProductVertificationDesktopApp.Views.Implements.LichSuView
{
    partial class Form_Lichsu_Dobiendang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_dobiendang = new System.Windows.Forms.DataGridView();
            this.Sukien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dobiendang)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_dobiendang
            // 
            this.dataGridView_dobiendang.AllowUserToAddRows = false;
            this.dataGridView_dobiendang.AllowUserToDeleteRows = false;
            this.dataGridView_dobiendang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_dobiendang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dobiendang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_dobiendang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dobiendang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sukien,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(54)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_dobiendang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_dobiendang.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_dobiendang.Location = new System.Drawing.Point(152, 69);
            this.dataGridView_dobiendang.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_dobiendang.Name = "dataGridView_dobiendang";
            this.dataGridView_dobiendang.ReadOnly = true;
            this.dataGridView_dobiendang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dobiendang.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_dobiendang.RowHeadersVisible = false;
            this.dataGridView_dobiendang.RowHeadersWidth = 55;
            this.dataGridView_dobiendang.RowTemplate.Height = 50;
            this.dataGridView_dobiendang.Size = new System.Drawing.Size(1301, 772);
            this.dataGridView_dobiendang.TabIndex = 3;
            // 
            // Sukien
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sukien.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sukien.HeaderText = "Ngày truy cập";
            this.Sukien.MinimumWidth = 6;
            this.Sukien.Name = "Sukien";
            this.Sukien.ReadOnly = true;
            this.Sukien.Width = 600;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nội dung";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 700;
            // 
            // Form_Lichsu_Dobiendang
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1607, 902);
            this.Controls.Add(this.dataGridView_dobiendang);
            this.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form_Lichsu_Dobiendang";
            this.Text = "Form_Lichsu_Dobiendang";
            this.Load += new System.EventHandler(this.Form_Lichsu_Dobiendang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dobiendang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_dobiendang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sukien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
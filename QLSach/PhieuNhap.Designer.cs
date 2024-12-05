namespace QLSach
{
    partial class PhieuNhap
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tg = new System.Windows.Forms.Label();
            this.txtSoLuongNhap = new System.Windows.Forms.TextBox();
            this.sl = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.tensach = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbbMaTG = new System.Windows.Forms.ComboBox();
            this.cbbMaNXB = new System.Windows.Forms.ComboBox();
            this.cbbMaTL = new System.Windows.Forms.ComboBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 197);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(872, 307);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "Mã thể loại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "Mã NXB";
            // 
            // tg
            // 
            this.tg.AutoSize = true;
            this.tg.Location = new System.Drawing.Point(413, 93);
            this.tg.Name = "tg";
            this.tg.Size = new System.Drawing.Size(69, 16);
            this.tg.TabIndex = 34;
            this.tg.Text = "Mã tác giả";
            // 
            // txtSoLuongNhap
            // 
            this.txtSoLuongNhap.Location = new System.Drawing.Point(178, 93);
            this.txtSoLuongNhap.Name = "txtSoLuongNhap";
            this.txtSoLuongNhap.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuongNhap.TabIndex = 33;
            // 
            // sl
            // 
            this.sl.AutoSize = true;
            this.sl.Location = new System.Drawing.Point(71, 92);
            this.sl.Name = "sl";
            this.sl.Size = new System.Drawing.Size(60, 16);
            this.sl.TabIndex = 32;
            this.sl.Text = "Số lượng";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(511, 43);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(192, 22);
            this.txtTenSach.TabIndex = 31;
            // 
            // tensach
            // 
            this.tensach.AutoSize = true;
            this.tensach.Location = new System.Drawing.Point(413, 43);
            this.tensach.Name = "tensach";
            this.tensach.Size = new System.Drawing.Size(63, 16);
            this.tensach.TabIndex = 30;
            this.tensach.Text = "Tên sách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Mã sách";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(826, 91);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 44;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(699, 142);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 45;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbbMaTG
            // 
            this.cbbMaTG.FormattingEnabled = true;
            this.cbbMaTG.Location = new System.Drawing.Point(511, 90);
            this.cbbMaTG.Name = "cbbMaTG";
            this.cbbMaTG.Size = new System.Drawing.Size(121, 24);
            this.cbbMaTG.TabIndex = 46;
            this.cbbMaTG.SelectedIndexChanged += new System.EventHandler(this.cbbMaTG_SelectedIndexChanged);
            // 
            // cbbMaNXB
            // 
            this.cbbMaNXB.FormattingEnabled = true;
            this.cbbMaNXB.Location = new System.Drawing.Point(178, 143);
            this.cbbMaNXB.Name = "cbbMaNXB";
            this.cbbMaNXB.Size = new System.Drawing.Size(121, 24);
            this.cbbMaNXB.TabIndex = 48;
            // 
            // cbbMaTL
            // 
            this.cbbMaTL.FormattingEnabled = true;
            this.cbbMaTL.Location = new System.Drawing.Point(511, 145);
            this.cbbMaTL.Name = "cbbMaTL";
            this.cbbMaTL.Size = new System.Drawing.Size(121, 24);
            this.cbbMaTL.TabIndex = 49;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(178, 43);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(100, 22);
            this.txtMaSach.TabIndex = 50;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(826, 142);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 51;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 516);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.cbbMaTL);
            this.Controls.Add(this.cbbMaNXB);
            this.Controls.Add(this.cbbMaTG);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tg);
            this.Controls.Add(this.txtSoLuongNhap);
            this.Controls.Add(this.sl);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.tensach);
            this.Controls.Add(this.label4);
            this.Name = "PhieuNhap";
            this.Text = "PhieuNhap";
            this.Load += new System.EventHandler(this.PhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label tg;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.Label sl;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label tensach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbbMaTG;
        private System.Windows.Forms.ComboBox cbbMaNXB;
        private System.Windows.Forms.ComboBox cbbMaTL;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button btnTimKiem;
    }
}

namespace SF_QuanLyBanHang_05Nov21
{
    partial class frmManHinhChinh
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
            this.menuManHinhChinh = new System.Windows.Forms.MenuStrip();
            this.menuTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngTyNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtXứToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnMuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.menuManHinhChinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuManHinhChinh
            // 
            this.menuManHinhChinh.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuManHinhChinh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTaiKhoan,
            this.menuThongTin,
            this.menuHoaDon,
            this.menuBaoCao});
            this.menuManHinhChinh.Location = new System.Drawing.Point(0, 0);
            this.menuManHinhChinh.Name = "menuManHinhChinh";
            this.menuManHinhChinh.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuManHinhChinh.Size = new System.Drawing.Size(1600, 27);
            this.menuManHinhChinh.TabIndex = 0;
            this.menuManHinhChinh.Text = "Màn hình chính";
            // 
            // menuTaiKhoan
            // 
            this.menuTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangNhap,
            this.menuDangXuat});
            this.menuTaiKhoan.Name = "menuTaiKhoan";
            this.menuTaiKhoan.Size = new System.Drawing.Size(69, 19);
            this.menuTaiKhoan.Text = "Tài khoản";
            this.menuTaiKhoan.Click += new System.EventHandler(this.menuDangNhap_Click);
            // 
            // menuDangNhap
            // 
            this.menuDangNhap.Name = "menuDangNhap";
            this.menuDangNhap.ShortcutKeyDisplayString = "Ctrl + I";
            this.menuDangNhap.Size = new System.Drawing.Size(180, 22);
            this.menuDangNhap.Text = "Đăng nhập";
            this.menuDangNhap.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.ShortcutKeyDisplayString = "Ctrl + O";
            this.menuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // menuThongTin
            // 
            this.menuThongTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sảnPhẩmToolStripMenuItem,
            this.côngTyNhàCungCấpToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.xuấtXứToolStripMenuItem});
            this.menuThongTin.Name = "menuThongTin";
            this.menuThongTin.Size = new System.Drawing.Size(70, 19);
            this.menuThongTin.Text = "Thông tin";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // côngTyNhàCungCấpToolStripMenuItem
            // 
            this.côngTyNhàCungCấpToolStripMenuItem.Name = "côngTyNhàCungCấpToolStripMenuItem";
            this.côngTyNhàCungCấpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + C";
            this.côngTyNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.côngTyNhàCungCấpToolStripMenuItem.Text = "Công ty / Nhà cung cấp";
            this.côngTyNhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.côngTyNhàCungCấpToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + K";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // xuấtXứToolStripMenuItem
            // 
            this.xuấtXứToolStripMenuItem.Name = "xuấtXứToolStripMenuItem";
            this.xuấtXứToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + X";
            this.xuấtXứToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.xuấtXứToolStripMenuItem.Text = "Xuất xứ";
            this.xuấtXứToolStripMenuItem.Click += new System.EventHandler(this.xuấtXứToolStripMenuItem_Click);
            // 
            // menuHoaDon
            // 
            this.menuHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnMuaToolStripMenuItem,
            this.hóaĐơnBánToolStripMenuItem});
            this.menuHoaDon.Name = "menuHoaDon";
            this.menuHoaDon.Size = new System.Drawing.Size(65, 19);
            this.menuHoaDon.Text = "Hóa đơn";
            // 
            // hóaĐơnMuaToolStripMenuItem
            // 
            this.hóaĐơnMuaToolStripMenuItem.Name = "hóaĐơnMuaToolStripMenuItem";
            this.hóaĐơnMuaToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + M";
            this.hóaĐơnMuaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.hóaĐơnMuaToolStripMenuItem.Text = "Hóa đơn mua";
            this.hóaĐơnMuaToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnMuaToolStripMenuItem_Click);
            // 
            // hóaĐơnBánToolStripMenuItem
            // 
            this.hóaĐơnBánToolStripMenuItem.Name = "hóaĐơnBánToolStripMenuItem";
            this.hóaĐơnBánToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + B";
            this.hóaĐơnBánToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.hóaĐơnBánToolStripMenuItem.Text = "Hóa đơn bán";
            this.hóaĐơnBánToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnBánToolStripMenuItem_Click);
            // 
            // menuBaoCao
            // 
            this.menuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoDoanhThuToolStripMenuItem,
            this.báoCáoTồnKhoToolStripMenuItem});
            this.menuBaoCao.Name = "menuBaoCao";
            this.menuBaoCao.Size = new System.Drawing.Size(61, 19);
            this.menuBaoCao.Text = "Báo cáo";
            // 
            // báoCáoDoanhThuToolStripMenuItem
            // 
            this.báoCáoDoanhThuToolStripMenuItem.Name = "báoCáoDoanhThuToolStripMenuItem";
            this.báoCáoDoanhThuToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + D";
            this.báoCáoDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.báoCáoDoanhThuToolStripMenuItem.Text = "Báo cáo doanh thu";
            this.báoCáoDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.báoCáoDoanhThuToolStripMenuItem_Click);
            // 
            // báoCáoTồnKhoToolStripMenuItem
            // 
            this.báoCáoTồnKhoToolStripMenuItem.Name = "báoCáoTồnKhoToolStripMenuItem";
            this.báoCáoTồnKhoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + T";
            this.báoCáoTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.báoCáoTồnKhoToolStripMenuItem.Text = "Báo cáo tồn kho";
            this.báoCáoTồnKhoToolStripMenuItem.Click += new System.EventHandler(this.báoCáoTồnKhoToolStripMenuItem_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(1162, 838);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(83, 16);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Người dùng: ";
            // 
            // frmManHinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.menuManHinhChinh);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmManHinhChinh";
            this.Text = "frmManHinhChinh";
            this.Load += new System.EventHandler(this.frmManHinhChinh_Load);
            this.menuManHinhChinh.ResumeLayout(false);
            this.menuManHinhChinh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuManHinhChinh;
        private System.Windows.Forms.ToolStripMenuItem menuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuThongTin;
        private System.Windows.Forms.ToolStripMenuItem menuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem menuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnMuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnBánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem báoCáoDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem côngTyNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtXứToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
    }
}
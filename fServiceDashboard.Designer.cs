namespace project
{
    partial class fServiceDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupMyServices = new System.Windows.Forms.GroupBox();
            this.dgvMyServices = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupAllServices = new System.Windows.Forms.GroupBox();
            this.dgvAllServices = new System.Windows.Forms.DataGridView();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnUpdateService = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupMyServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyServices)).BeginInit();
            this.groupAllServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllServices)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(98)))));
            this.panelMenu.Controls.Add(this.lblAppName);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 703);
            this.panelMenu.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(26, 26);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(157, 28);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "SERVICE MGMT";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(862, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 24);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(201, 31);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Tổng Quan Dịch Vụ";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.groupMyServices);
            this.panelMain.Controls.Add(this.groupAllServices);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(862, 623);
            this.panelMain.TabIndex = 2;
            // 
            // groupMyServices
            // 
            this.groupMyServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMyServices.Controls.Add(this.dgvMyServices);
            this.groupMyServices.Controls.Add(this.btnCancel);
            this.groupMyServices.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupMyServices.Location = new System.Drawing.Point(23, 315);
            this.groupMyServices.Name = "groupMyServices";
            this.groupMyServices.Size = new System.Drawing.Size(816, 285);
            this.groupMyServices.TabIndex = 1;
            this.groupMyServices.TabStop = false;
            this.groupMyServices.Text = "Dịch Vụ Đã Đăng Ký";
            // 
            // dgvMyServices
            // 
            this.dgvMyServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMyServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyServices.Location = new System.Drawing.Point(16, 35);
            this.dgvMyServices.Name = "dgvMyServices";
            this.dgvMyServices.RowHeadersWidth = 51;
            this.dgvMyServices.RowTemplate.Height = 24;
            this.dgvMyServices.Size = new System.Drawing.Size(784, 185);
            this.dgvMyServices.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(16, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy Dịch Vụ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupAllServices
            // 
            this.groupAllServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAllServices.Controls.Add(this.dgvAllServices);
            this.groupAllServices.Controls.Add(this.btnRegister);
            this.groupAllServices.Controls.Add(this.btnDeleteService);
            this.groupAllServices.Controls.Add(this.btnAddService);
            this.groupAllServices.Controls.Add(this.btnUpdateService);
            this.groupAllServices.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAllServices.Location = new System.Drawing.Point(23, 23);
            this.groupAllServices.Name = "groupAllServices";
            this.groupAllServices.Size = new System.Drawing.Size(816, 285);
            this.groupAllServices.TabIndex = 0;
            this.groupAllServices.TabStop = false;
            this.groupAllServices.Text = "Tất Cả Dịch Vụ";
            // 
            // dgvAllServices
            // 
            this.dgvAllServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllServices.Location = new System.Drawing.Point(16, 35);
            this.dgvAllServices.Name = "dgvAllServices";
            this.dgvAllServices.RowHeadersWidth = 51;
            this.dgvAllServices.RowTemplate.Height = 24;
            this.dgvAllServices.Size = new System.Drawing.Size(784, 185);
            this.dgvAllServices.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(135)))), ((int)(((byte)(185)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(16, 235);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 35);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Đăng Ký";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteService.FlatAppearance.BorderSize = 0;
            this.btnDeleteService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteService.ForeColor = System.Drawing.Color.White;
            this.btnDeleteService.Location = new System.Drawing.Point(710, 235);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteService.TabIndex = 4;
            this.btnDeleteService.Text = "Xóa";
            this.btnDeleteService.UseVisualStyleBackColor = false;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddService.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddService.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.ForeColor = System.Drawing.Color.Black;
            this.btnAddService.Location = new System.Drawing.Point(518, 235);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(90, 35);
            this.btnAddService.TabIndex = 2;
            this.btnAddService.Text = "Thêm";
            this.btnAddService.UseVisualStyleBackColor = false;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateService.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdateService.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUpdateService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateService.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateService.Location = new System.Drawing.Point(614, 235);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(90, 35);
            this.btnUpdateService.TabIndex = 3;
            this.btnUpdateService.Text = "Sửa";
            this.btnUpdateService.UseVisualStyleBackColor = false;
            this.btnUpdateService.Click += new System.EventHandler(this.btnUpdateService_Click);
            // 
            // fServiceDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 703);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(980, 600);
            this.Name = "fServiceDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Dashboard";
            this.Load += new System.EventHandler(this.fServiceDashboard_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupMyServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyServices)).EndInit();
            this.groupAllServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllServices)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox groupAllServices;
        private System.Windows.Forms.DataGridView dgvAllServices;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.GroupBox groupMyServices;
        private System.Windows.Forms.DataGridView dgvMyServices;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnUpdateService;
        private System.Windows.Forms.Button btnDeleteService;
    }
}
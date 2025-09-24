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
            this.btnViewMyBill = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupPendingRequests = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.dgvPendingRequests = new System.Windows.Forms.DataGridView();
            this.groupUsersByService = new System.Windows.Forms.GroupBox();
            this.dgvUsersByService = new System.Windows.Forms.DataGridView();
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
            this.groupPendingRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).BeginInit();
            this.groupUsersByService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersByService)).BeginInit();
            this.groupMyServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyServices)).BeginInit();
            this.groupAllServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllServices)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(98)))));
            this.panelMenu.Controls.Add(this.btnViewMyBill);
            this.panelMenu.Controls.Add(this.lblAppName);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 833);
            this.panelMenu.TabIndex = 0;
            // 
            // btnViewMyBill
            // 
            this.btnViewMyBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewMyBill.FlatAppearance.BorderSize = 0;
            this.btnViewMyBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewMyBill.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMyBill.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnViewMyBill.Location = new System.Drawing.Point(0, 80);
            this.btnViewMyBill.Name = "btnViewMyBill";
            this.btnViewMyBill.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnViewMyBill.Size = new System.Drawing.Size(220, 60);
            this.btnViewMyBill.TabIndex = 1;
            this.btnViewMyBill.Text = "Xem Hóa Đơn";
            this.btnViewMyBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewMyBill.UseVisualStyleBackColor = true;
            this.btnViewMyBill.Click += new System.EventHandler(this.btnViewMyBill_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(220, 80);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "SERVICE MGMT";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.btnGenerateBill);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(962, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateBill.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGenerateBill.FlatAppearance.BorderSize = 0;
            this.btnGenerateBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateBill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBill.ForeColor = System.Drawing.Color.White;
            this.btnGenerateBill.Location = new System.Drawing.Point(790, 22);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(150, 35);
            this.btnGenerateBill.TabIndex = 1;
            this.btnGenerateBill.Text = "Chốt số tháng này";
            this.btnGenerateBill.UseVisualStyleBackColor = false;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
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
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.groupPendingRequests);
            this.panelMain.Controls.Add(this.groupUsersByService);
            this.panelMain.Controls.Add(this.groupMyServices);
            this.panelMain.Controls.Add(this.groupAllServices);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(962, 753);
            this.panelMain.TabIndex = 2;
            // 
            // groupPendingRequests
            // 
            this.groupPendingRequests.Controls.Add(this.btnReject);
            this.groupPendingRequests.Controls.Add(this.btnApprove);
            this.groupPendingRequests.Controls.Add(this.dgvPendingRequests);
            this.groupPendingRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPendingRequests.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupPendingRequests.Location = new System.Drawing.Point(20, 680);
            this.groupPendingRequests.Name = "groupPendingRequests";
            this.groupPendingRequests.Size = new System.Drawing.Size(922, 220);
            this.groupPendingRequests.TabIndex = 3;
            this.groupPendingRequests.TabStop = false;
            this.groupPendingRequests.Text = "Yêu cầu chờ duyệt";
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(142, 170);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 35);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Từ chối";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(16, 170);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(120, 35);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Duyệt";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // dgvPendingRequests
            // 
            this.dgvPendingRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPendingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingRequests.Location = new System.Drawing.Point(16, 35);
            this.dgvPendingRequests.Name = "dgvPendingRequests";
            this.dgvPendingRequests.RowHeadersWidth = 51;
            this.dgvPendingRequests.RowTemplate.Height = 24;
            this.dgvPendingRequests.Size = new System.Drawing.Size(890, 120);
            this.dgvPendingRequests.TabIndex = 0;
            // 
            // groupUsersByService
            // 
            this.groupUsersByService.Controls.Add(this.dgvUsersByService);
            this.groupUsersByService.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupUsersByService.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupUsersByService.Location = new System.Drawing.Point(20, 460);
            this.groupUsersByService.Name = "groupUsersByService";
            this.groupUsersByService.Padding = new System.Windows.Forms.Padding(10);
            this.groupUsersByService.Size = new System.Drawing.Size(922, 220);
            this.groupUsersByService.TabIndex = 2;
            this.groupUsersByService.TabStop = false;
            this.groupUsersByService.Text = "Danh sách sinh viên đã đăng ký (Admin view)";
            // 
            // dgvUsersByService
            // 
            this.dgvUsersByService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsersByService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersByService.Location = new System.Drawing.Point(16, 35);
            this.dgvUsersByService.Name = "dgvUsersByService";
            this.dgvUsersByService.RowHeadersWidth = 51;
            this.dgvUsersByService.RowTemplate.Height = 24;
            this.dgvUsersByService.Size = new System.Drawing.Size(890, 167);
            this.dgvUsersByService.TabIndex = 0;
            // 
            // groupMyServices
            // 
            this.groupMyServices.Controls.Add(this.dgvMyServices);
            this.groupMyServices.Controls.Add(this.btnCancel);
            this.groupMyServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupMyServices.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupMyServices.Location = new System.Drawing.Point(20, 240);
            this.groupMyServices.Name = "groupMyServices";
            this.groupMyServices.Size = new System.Drawing.Size(922, 220);
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
            this.dgvMyServices.Size = new System.Drawing.Size(890, 120);
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
            this.btnCancel.Location = new System.Drawing.Point(16, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy Dịch Vụ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupAllServices
            // 
            this.groupAllServices.Controls.Add(this.dgvAllServices);
            this.groupAllServices.Controls.Add(this.btnRegister);
            this.groupAllServices.Controls.Add(this.btnDeleteService);
            this.groupAllServices.Controls.Add(this.btnAddService);
            this.groupAllServices.Controls.Add(this.btnUpdateService);
            this.groupAllServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAllServices.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAllServices.Location = new System.Drawing.Point(20, 20);
            this.groupAllServices.Name = "groupAllServices";
            this.groupAllServices.Size = new System.Drawing.Size(922, 220);
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
            this.dgvAllServices.MultiSelect = true;
            this.dgvAllServices.Name = "dgvAllServices";
            this.dgvAllServices.RowHeadersWidth = 51;
            this.dgvAllServices.RowTemplate.Height = 24;
            this.dgvAllServices.Size = new System.Drawing.Size(890, 120);
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
            this.btnRegister.Location = new System.Drawing.Point(16, 170);
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
            this.btnDeleteService.Location = new System.Drawing.Point(816, 170);
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
            this.btnAddService.Location = new System.Drawing.Point(624, 170);
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
            this.btnUpdateService.Location = new System.Drawing.Point(720, 170);
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
            this.ClientSize = new System.Drawing.Size(1182, 833);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(980, 700);
            this.Name = "fServiceDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Dashboard";
            this.Load += new System.EventHandler(this.fServiceDashboard_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupPendingRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).EndInit();
            this.groupUsersByService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersByService)).EndInit();
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
        private System.Windows.Forms.GroupBox groupUsersByService;
        private System.Windows.Forms.DataGridView dgvUsersByService;
        private System.Windows.Forms.GroupBox groupPendingRequests;
        private System.Windows.Forms.DataGridView dgvPendingRequests;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnViewMyBill;
        private System.Windows.Forms.Button btnGenerateBill;
    }
}
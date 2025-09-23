namespace project
{
    partial class Home
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
            this.btnManageServices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageServices
            // 
            this.btnManageServices.Location = new System.Drawing.Point(183, 79);
            this.btnManageServices.Name = "btnManageServices";
            this.btnManageServices.Size = new System.Drawing.Size(108, 23);
            this.btnManageServices.TabIndex = 0;
            this.btnManageServices.Text = "Quản lý Dịch vụ";
            this.btnManageServices.UseVisualStyleBackColor = true;
            this.btnManageServices.Click += new System.EventHandler(this.btnManageServices_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageServices);
            this.Name = "Home";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageServices;
    }
}
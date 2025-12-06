namespace ZeGotao.UII
{

    partial class Principal
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnClose = new Button();
            btnMaxRestore = new Button();
            btnMinimize = new Button();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.BackgroundImageLayout = ImageLayout.Center;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.White;
            webView2.Dock = DockStyle.Fill;
            webView2.Location = new Point(0, 0);
            webView2.Name = "webView2";
            webView2.Size = new Size(1102, 634);
            webView2.TabIndex = 0;
            webView2.UseWaitCursor = true;
            webView2.ZoomFactor = 1D;
            webView2.Click += webView2_Click;
            // 
            // guna2BorderlessForm2
            // 
            guna2BorderlessForm2.ContainerControl = this;
            guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(200, 30, 30);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1066, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(15, 20);
            btnClose.TabIndex = 1;
            btnClose.Text = "✖";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // btnMaxRestore
            // 
            btnMaxRestore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaxRestore.BackColor = Color.FromArgb(60, 60, 60);
            btnMaxRestore.Cursor = Cursors.Hand;
            btnMaxRestore.FlatAppearance.BorderSize = 0;
            btnMaxRestore.FlatStyle = FlatStyle.Flat;
            btnMaxRestore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMaxRestore.ForeColor = Color.White;
            btnMaxRestore.Location = new Point(1045, 0);
            btnMaxRestore.Name = "btnMaxRestore";
            btnMaxRestore.Size = new Size(15, 20);
            btnMaxRestore.TabIndex = 2;
            btnMaxRestore.Text = "⬜";
            btnMaxRestore.UseVisualStyleBackColor = false;
            btnMaxRestore.Click += BtnMaxRestore_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(60, 60, 60);
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1024, 1);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(15, 20);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "—";
            btnMinimize.TextAlign = ContentAlignment.TopCenter;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += BtnMinimize_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1102, 634);
            Controls.Add(btnClose);
            Controls.Add(btnMaxRestore);
            Controls.Add(btnMinimize);
            Controls.Add(webView2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Principal";
            Text = "Principal";
            Load += Principal_Load;
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;

        private Panel loadingOverlay;

        private void CriarLoadingOverlay()
        {
            loadingOverlay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(120, 0, 0, 0), // fundo translúcido escuro
                Visible = true
            };

            var label = new Label
            {
                Text = "Aguarde, estamos preparando as vacinas...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.Transparent
            };

            loadingOverlay.Controls.Add(label);

            // centraliza
            loadingOverlay.Resize += (s, e) =>
            {
                label.Left = (loadingOverlay.Width - label.Width) / 2;
                label.Top = (loadingOverlay.Height - label.Height) / 2;
            };

            this.Controls.Add(loadingOverlay);
            loadingOverlay.BringToFront();
        }
    }
}
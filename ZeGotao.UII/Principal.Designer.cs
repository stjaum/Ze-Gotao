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
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            label1 = new Label();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(66, 23);
            label1.Name = "label1";
            label1.Size = new Size(352, 23);
            label1.TabIndex = 11;
            label1.Text = "Cuide-se, Deixe suas Vacinas em dias";
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.BackColor = SystemColors.Desktop;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.White;
            webView2.Location = new Point(2, -1);
            webView2.Name = "webView2";
            webView2.Size = new Size(661, 453);
            webView2.TabIndex = 13;
            webView2.ZoomFactor = 1D;
            webView2.Click += webView2_Click;
            // 
            // guna2BorderlessForm2
            // 
            guna2BorderlessForm2.ContainerControl = this;
            guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(664, 454);
            Controls.Add(webView2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Principal";
            Text = "Principal";
            Load += Principal_Load;
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
    }
}
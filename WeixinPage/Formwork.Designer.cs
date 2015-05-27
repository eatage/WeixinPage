namespace WeixinPage
{
    partial class Formwork
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
            this.components = new System.ComponentModel.Container();
            this.btn_get = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_get
            // 
            this.btn_get.Location = new System.Drawing.Point(124, 30);
            this.btn_get.Name = "btn_get";
            this.btn_get.Size = new System.Drawing.Size(78, 23);
            this.btn_get.TabIndex = 0;
            this.btn_get.Text = "获取模板ID";
            this.btn_get.UseVisualStyleBackColor = true;
            this.btn_get.Click += new System.EventHandler(this.btn_get_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(124, 104);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Formwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 396);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_get);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Formwork";
            this.Text = "模板消息";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_get;
        private System.Windows.Forms.Button btn_send;

    }
}


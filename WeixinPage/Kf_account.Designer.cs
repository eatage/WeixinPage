namespace WeixinPage
{
    partial class Kf_account
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
            this.btn_GetUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lkl_num = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lkl_num_c = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_nums = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_count = new System.Windows.Forms.Label();
            this.grb_chat = new System.Windows.Forms.GroupBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.richTextBox_msg = new System.Windows.Forms.RichTextBox();
            this.webBrowser_msg = new System.Windows.Forms.WebBrowser();
            this.btn_addkf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grb_chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GetUser
            // 
            this.btn_GetUser.Location = new System.Drawing.Point(332, 43);
            this.btn_GetUser.Name = "btn_GetUser";
            this.btn_GetUser.Size = new System.Drawing.Size(75, 23);
            this.btn_GetUser.TabIndex = 0;
            this.btn_GetUser.Text = "拉取用户";
            this.btn_GetUser.UseVisualStyleBackColor = true;
            this.btn_GetUser.Click += new System.EventHandler(this.btn_GetUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "关注该公众账号的总用户数：";
            // 
            // lkl_num
            // 
            this.lkl_num.AutoSize = true;
            this.lkl_num.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkl_num.Location = new System.Drawing.Point(182, 9);
            this.lkl_num.Name = "lkl_num";
            this.lkl_num.Size = new System.Drawing.Size(17, 19);
            this.lkl_num.TabIndex = 2;
            this.lkl_num.TabStop = true;
            this.lkl_num.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "拉取的用户个数，最大值为10000：";
            // 
            // lkl_num_c
            // 
            this.lkl_num_c.AutoSize = true;
            this.lkl_num_c.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkl_num_c.Location = new System.Drawing.Point(427, 9);
            this.lkl_num_c.Name = "lkl_num_c";
            this.lkl_num_c.Size = new System.Drawing.Size(17, 19);
            this.lkl_num_c.TabIndex = 4;
            this.lkl_num_c.TabStop = true;
            this.lkl_num_c.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户列表：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WeixinPage.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(422, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lab_nums
            // 
            this.lab_nums.AutoSize = true;
            this.lab_nums.Location = new System.Drawing.Point(461, 48);
            this.lab_nums.Name = "lab_nums";
            this.lab_nums.Size = new System.Drawing.Size(0, 13);
            this.lab_nums.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.openid});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(208, 370);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "呢称";
            this.username.MinimumWidth = 185;
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.username.Width = 185;
            // 
            // openid
            // 
            this.openid.DataPropertyName = "openid";
            this.openid.HeaderText = "openid";
            this.openid.Name = "openid";
            this.openid.ReadOnly = true;
            this.openid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "昵称：";
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_search.Location = new System.Drawing.Point(61, 45);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(132, 21);
            this.txt_search.TabIndex = 1;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(214, 43);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "搜索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(85, 77);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(39, 13);
            this.lbl_count.TabIndex = 13;
            this.lbl_count.Text = "共0行";
            // 
            // grb_chat
            // 
            this.grb_chat.Controls.Add(this.btn_send);
            this.grb_chat.Controls.Add(this.richTextBox_msg);
            this.grb_chat.Controls.Add(this.webBrowser_msg);
            this.grb_chat.Enabled = false;
            this.grb_chat.Location = new System.Drawing.Point(231, 93);
            this.grb_chat.Name = "grb_chat";
            this.grb_chat.Size = new System.Drawing.Size(554, 370);
            this.grb_chat.TabIndex = 14;
            this.grb_chat.TabStop = false;
            this.grb_chat.Text = "发送消息";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(473, 341);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // richTextBox_msg
            // 
            this.richTextBox_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_msg.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_msg.Location = new System.Drawing.Point(6, 261);
            this.richTextBox_msg.Name = "richTextBox_msg";
            this.richTextBox_msg.Size = new System.Drawing.Size(542, 74);
            this.richTextBox_msg.TabIndex = 1;
            this.richTextBox_msg.Text = "";
            // 
            // webBrowser_msg
            // 
            this.webBrowser_msg.Location = new System.Drawing.Point(6, 15);
            this.webBrowser_msg.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_msg.Name = "webBrowser_msg";
            this.webBrowser_msg.Size = new System.Drawing.Size(542, 240);
            this.webBrowser_msg.TabIndex = 0;
            // 
            // btn_addkf
            // 
            this.btn_addkf.Location = new System.Drawing.Point(616, 43);
            this.btn_addkf.Name = "btn_addkf";
            this.btn_addkf.Size = new System.Drawing.Size(75, 23);
            this.btn_addkf.TabIndex = 15;
            this.btn_addkf.Text = "添加客服";
            this.btn_addkf.UseVisualStyleBackColor = true;
            this.btn_addkf.Click += new System.EventHandler(this.btn_addkf_Click);
            // 
            // Kf_account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 475);
            this.Controls.Add(this.btn_addkf);
            this.Controls.Add(this.grb_chat);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lab_nums);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lkl_num_c);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lkl_num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_GetUser);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Kf_account";
            this.Text = "获取用户信息";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grb_chat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lkl_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lkl_num_c;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lab_nums;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.GroupBox grb_chat;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.RichTextBox richTextBox_msg;
        private System.Windows.Forms.WebBrowser webBrowser_msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn openid;
        private System.Windows.Forms.Button btn_addkf;

    }
}


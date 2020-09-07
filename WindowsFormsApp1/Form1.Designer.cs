namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.input = new System.Windows.Forms.Label();
            this.inputpath = new System.Windows.Forms.TextBox();
            this.enter = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.AutoSize = true;
            this.input.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.input.Location = new System.Drawing.Point(31, 71);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(80, 21);
            this.input.TabIndex = 0;
            this.input.Text = "File Path";
            // 
            // inputpath
            // 
            this.inputpath.Location = new System.Drawing.Point(117, 71);
            this.inputpath.Name = "inputpath";
            this.inputpath.Size = new System.Drawing.Size(477, 22);
            this.inputpath.TabIndex = 1;
            this.inputpath.TextChanged += new System.EventHandler(this.inputpath_TextChanged);
            // 
            // enter
            // 
            this.enter.Location = new System.Drawing.Point(687, 70);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(75, 23);
            this.enter.TabIndex = 2;
            this.enter.Text = "Enter";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(22, 136);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.ReadOnly = true;
            this.display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.display.Size = new System.Drawing.Size(750, 275);
            this.display.TabIndex = 3;
            this.display.TextChanged += new System.EventHandler(this.display_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(606, 70);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 4;
            this.browse.Text = "browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.display);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.inputpath);
            this.Controls.Add(this.input);
            this.Name = "Form1";
            this.Text = "File loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label input;
        private System.Windows.Forms.TextBox inputpath;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browse;
    }
}


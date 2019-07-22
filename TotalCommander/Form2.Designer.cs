namespace TotalCommander
{
    partial class Form2
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
            this.tbform2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbform2
            // 
            this.tbform2.Location = new System.Drawing.Point(89, 32);
            this.tbform2.Name = "tbform2";
            this.tbform2.Size = new System.Drawing.Size(93, 20);
            this.tbform2.TabIndex = 0;
            this.tbform2.Text = "notepad.exe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default Editor";
            // 
            // buttonForm2
            // 
            this.buttonForm2.Location = new System.Drawing.Point(188, 30);
            this.buttonForm2.Name = "buttonForm2";
            this.buttonForm2.Size = new System.Drawing.Size(56, 23);
            this.buttonForm2.TabIndex = 2;
            this.buttonForm2.Text = "Save";
            this.buttonForm2.UseVisualStyleBackColor = true;
            this.buttonForm2.Click += new System.EventHandler(this.buttonForm2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 90);
            this.Controls.Add(this.buttonForm2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbform2);
            this.Name = "Form2";
            this.Text = "Default Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbform2;
        public System.Windows.Forms.Button buttonForm2;
    }
}
namespace DepartmentStudentApp
{
    partial class MainUI
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
            this.searchStudentButton = new System.Windows.Forms.Button();
            this.entryStudentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchStudentButton
            // 
            this.searchStudentButton.Location = new System.Drawing.Point(213, 49);
            this.searchStudentButton.Name = "searchStudentButton";
            this.searchStudentButton.Size = new System.Drawing.Size(123, 68);
            this.searchStudentButton.TabIndex = 3;
            this.searchStudentButton.Text = "Search Student";
            this.searchStudentButton.UseVisualStyleBackColor = true;
            this.searchStudentButton.Click += new System.EventHandler(this.searchStudentButton_Click);
            // 
            // entryStudentButton
            // 
            this.entryStudentButton.Location = new System.Drawing.Point(36, 49);
            this.entryStudentButton.Name = "entryStudentButton";
            this.entryStudentButton.Size = new System.Drawing.Size(123, 68);
            this.entryStudentButton.TabIndex = 2;
            this.entryStudentButton.Text = "Entry Student";
            this.entryStudentButton.UseVisualStyleBackColor = true;
            this.entryStudentButton.Click += new System.EventHandler(this.entryStudentButton_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 175);
            this.Controls.Add(this.searchStudentButton);
            this.Controls.Add(this.entryStudentButton);
            this.Name = "MainUI";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchStudentButton;
        private System.Windows.Forms.Button entryStudentButton;
    }
}
namespace BLOKNOT
{
    partial class ReplaceForm
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
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            txtReplace = new TextBox();
            btnReplace = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(29, 83);
            label1.Name = "label1";
            label1.Size = new Size(141, 21);
            label1.TabIndex = 0;
            label1.Text = "Текст для замены";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(29, 26);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 1;
            label2.Text = "Что заменить";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtSearch.Location = new Point(176, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 29);
            txtSearch.TabIndex = 2;
            // 
            // txtReplace
            // 
            txtReplace.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtReplace.Location = new Point(176, 80);
            txtReplace.Name = "txtReplace";
            txtReplace.Size = new Size(100, 29);
            txtReplace.TabIndex = 3;
            // 
            // btnReplace
            // 
            btnReplace.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnReplace.Location = new Point(62, 126);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(178, 42);
            btnReplace.TabIndex = 4;
            btnReplace.Text = "Выполнить замену";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += btnReplace_Click_1;
            // 
            // ReplaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 180);
            Controls.Add(btnReplace);
            Controls.Add(txtReplace);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReplaceForm";
            Text = "ReplaceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private TextBox txtReplace;
        private Button btnReplace;
    }
}
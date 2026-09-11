namespace nKanban
{
    partial class frmAddTask
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
            btnConfirm = new Button();
            txtDescription = new RichTextBox();
            label3 = new Label();
            cbTaskStatus = new ComboBox();
            txtTitle = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 0;
            label1.Text = "Title : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 67);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 0;
            label2.Text = "Description : ";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(573, 690);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(101, 43);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtDescription
            // 
            txtDescription.AcceptsTab = true;
            txtDescription.Location = new Point(13, 109);
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtDescription.Size = new Size(664, 532);
            txtDescription.TabIndex = 1;
            txtDescription.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 659);
            label3.Name = "label3";
            label3.Size = new Size(82, 28);
            label3.TabIndex = 0;
            label3.Text = "Status :";
            // 
            // cbTaskStatus
            // 
            cbTaskStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTaskStatus.FormattingEnabled = true;
            cbTaskStatus.Items.AddRange(new object[] { "To Do", "In Progress", "Done" });
            cbTaskStatus.Location = new Point(104, 659);
            cbTaskStatus.Name = "cbTaskStatus";
            cbTaskStatus.Size = new Size(116, 28);
            cbTaskStatus.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(88, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(586, 27);
            txtTitle.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(459, 690);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(101, 43);
            btnClose.TabIndex = 4;
            btnClose.Text = "Cancel";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmAddTask
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(688, 754);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(txtTitle);
            Controls.Add(cbTaskStatus);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(btnConfirm);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddTask";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnConfirm;
        private RichTextBox txtDescription;
        private Label label3;
        private ComboBox cbTaskStatus;
        private TextBox txtTitle;
        private Button btnClose;
    }
}
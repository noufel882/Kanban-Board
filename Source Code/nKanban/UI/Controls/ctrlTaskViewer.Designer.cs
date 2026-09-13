namespace nKanban.UI
{
    partial class ctrlTaskViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            panel2 = new Panel();
            lblTitle = new Label();
            btnContentView = new Button();
            pnlBody = new Panel();
            cbTaskStatus = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTitle = new TextBox();
            txtDescription = new RichTextBox();
            pnlHeader.SuspendLayout();
            panel2.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.ControlLightLight;
            pnlHeader.Controls.Add(panel2);
            pnlHeader.Controls.Add(btnContentView);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(582, 48);
            pnlHeader.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTitle);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(48, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(534, 48);
            panel2.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F);
            lblTitle.Location = new Point(97, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 28);
            lblTitle.TabIndex = 13;
            // 
            // btnContentView
            // 
            btnContentView.Dock = DockStyle.Left;
            btnContentView.FlatStyle = FlatStyle.Flat;
            btnContentView.Image = Properties.Resources.Arrow_DOWN32;
            btnContentView.Location = new Point(0, 0);
            btnContentView.Name = "btnContentView";
            btnContentView.Size = new Size(48, 48);
            btnContentView.TabIndex = 0;
            btnContentView.UseVisualStyleBackColor = true;
            btnContentView.Click += btnContentView_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(txtDescription);
            pnlBody.Controls.Add(txtTitle);
            pnlBody.Controls.Add(cbTaskStatus);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(label2);
            pnlBody.Controls.Add(label1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 48);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(582, 497);
            pnlBody.TabIndex = 13;
            // 
            // cbTaskStatus
            // 
            cbTaskStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTaskStatus.FormattingEnabled = true;
            cbTaskStatus.Items.AddRange(new object[] { "To Do", "In Progress", "Done" });
            cbTaskStatus.Location = new Point(101, 451);
            cbTaskStatus.Name = "cbTaskStatus";
            cbTaskStatus.Size = new Size(116, 28);
            cbTaskStatus.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 451);
            label3.Name = "label3";
            label3.Size = new Size(82, 28);
            label3.TabIndex = 13;
            label3.Text = "Status :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 67);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 14;
            label2.Text = "Description : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 17);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 15;
            label1.Text = "Title : ";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(88, 22);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(474, 27);
            txtTitle.TabIndex = 18;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(15, 112);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(547, 322);
            txtDescription.TabIndex = 19;
            txtDescription.Text = "";
            // 
            // ctrlTaskViewer
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Name = "ctrlTaskViewer";
            Size = new Size(582, 545);
            MouseDown += ctrlTaskViewer_MouseDown;
            pnlHeader.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlHeader;
        private Button btnContentView;
        private Panel panel2;
        private Label lblTitle;
        private Panel pnlBody;
        private ComboBox cbTaskStatus;
        private Label label3;
        private Label label2;
        private Label label1;
        private RichTextBox txtDescription;
        private TextBox txtTitle;
    }
}

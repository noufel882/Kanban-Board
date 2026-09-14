namespace nKanban
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnAddTask = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pnlToDo = new nKanban.UI.Controls.ctrlPanel();
            pnlInProgress = new nKanban.UI.Controls.ctrlPanel();
            pnlDone = new nKanban.UI.Controls.ctrlPanel();
            pnlBoard = new TableLayoutPanel();
            pnlTools = new Panel();
            btnSaveBoard = new Button();
            ctrlDeleteButton1 = new nKanban.UI.Controls.ctrlDeleteButton();
            btnLoad = new Button();
            pnlBoard.SuspendLayout();
            pnlTools.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(8, 11);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(78, 46);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "Add";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 4;
            label1.Text = "To Do ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(567, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 5;
            label2.Text = "In Progress";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1131, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 6;
            label3.Text = "Done";
            // 
            // pnlToDo
            // 
            pnlToDo.AllowDrop = true;
            pnlToDo.BorderStyle = BorderStyle.FixedSingle;
            pnlToDo.Dock = DockStyle.Fill;
            pnlToDo.FlowDirection = FlowDirection.TopDown;
            pnlToDo.Location = new Point(10, 52);
            pnlToDo.Margin = new Padding(10);
            pnlToDo.Name = "pnlToDo";
            pnlToDo.Size = new Size(544, 778);
            pnlToDo.TabIndex = 7;
            pnlToDo.Tag = "To Do";
            pnlToDo.Text = "ctrlPanel1";
            pnlToDo.WrapContents = false;
            // 
            // pnlInProgress
            // 
            pnlInProgress.AllowDrop = true;
            pnlInProgress.BorderStyle = BorderStyle.FixedSingle;
            pnlInProgress.Dock = DockStyle.Fill;
            pnlInProgress.FlowDirection = FlowDirection.TopDown;
            pnlInProgress.Location = new Point(574, 52);
            pnlInProgress.Margin = new Padding(10);
            pnlInProgress.Name = "pnlInProgress";
            pnlInProgress.Size = new Size(544, 778);
            pnlInProgress.TabIndex = 8;
            pnlInProgress.Tag = "In Progress";
            pnlInProgress.Text = "ctrlPanel1";
            pnlInProgress.WrapContents = false;
            // 
            // pnlDone
            // 
            pnlDone.AllowDrop = true;
            pnlDone.BorderStyle = BorderStyle.FixedSingle;
            pnlDone.Dock = DockStyle.Fill;
            pnlDone.FlowDirection = FlowDirection.TopDown;
            pnlDone.Location = new Point(1138, 52);
            pnlDone.Margin = new Padding(10);
            pnlDone.Name = "pnlDone";
            pnlDone.Size = new Size(546, 778);
            pnlDone.TabIndex = 9;
            pnlDone.Tag = "Done";
            pnlDone.Text = "ctrlPanel1";
            pnlDone.WrapContents = false;
            // 
            // pnlBoard
            // 
            pnlBoard.ColumnCount = 3;
            pnlBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            pnlBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            pnlBoard.Controls.Add(pnlDone, 2, 1);
            pnlBoard.Controls.Add(label3, 2, 0);
            pnlBoard.Controls.Add(pnlInProgress, 1, 1);
            pnlBoard.Controls.Add(pnlToDo, 0, 1);
            pnlBoard.Controls.Add(label1, 0, 0);
            pnlBoard.Controls.Add(label2, 1, 0);
            pnlBoard.Dock = DockStyle.Fill;
            pnlBoard.Location = new Point(0, 71);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.RowCount = 2;
            pnlBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            pnlBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 95F));
            pnlBoard.Size = new Size(1694, 840);
            pnlBoard.TabIndex = 10;
            // 
            // pnlTools
            // 
            pnlTools.Controls.Add(btnLoad);
            pnlTools.Controls.Add(btnSaveBoard);
            pnlTools.Controls.Add(ctrlDeleteButton1);
            pnlTools.Controls.Add(btnAddTask);
            pnlTools.Dock = DockStyle.Top;
            pnlTools.Location = new Point(0, 0);
            pnlTools.Name = "pnlTools";
            pnlTools.Size = new Size(1694, 71);
            pnlTools.TabIndex = 11;
            // 
            // btnSaveBoard
            // 
            btnSaveBoard.Location = new Point(203, 11);
            btnSaveBoard.Name = "btnSaveBoard";
            btnSaveBoard.Size = new Size(78, 46);
            btnSaveBoard.TabIndex = 2;
            btnSaveBoard.Text = "Save";
            btnSaveBoard.UseVisualStyleBackColor = true;
            btnSaveBoard.Click += btnSaveBoard_Click;
            // 
            // ctrlDeleteButton1
            // 
            ctrlDeleteButton1.AllowDrop = true;
            ctrlDeleteButton1.Image = (Image)resources.GetObject("ctrlDeleteButton1.Image");
            ctrlDeleteButton1.Location = new Point(107, 5);
            ctrlDeleteButton1.Name = "ctrlDeleteButton1";
            ctrlDeleteButton1.Size = new Size(60, 60);
            ctrlDeleteButton1.TabIndex = 1;
            ctrlDeleteButton1.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(308, 11);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(78, 46);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1694, 911);
            Controls.Add(pnlBoard);
            Controls.Add(pnlTools);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main menu";
            WindowState = FormWindowState.Maximized;
            pnlBoard.ResumeLayout(false);
            pnlBoard.PerformLayout();
            pnlTools.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddTask;
        private Label label1;
        private Label label2;
        private Label label3;
        private UI.Controls.ctrlPanel pnlToDo;
        private UI.Controls.ctrlPanel pnlInProgress;
        private UI.Controls.ctrlPanel pnlDone;
        private TableLayoutPanel pnlBoard;
        private Panel pnlTools;
        private UI.Controls.ctrlDeleteButton ctrlDeleteButton1;
        private Button btnSaveBoard;
        private Button btnLoad;
    }
}

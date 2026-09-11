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
            btnAddTask = new Button();
            pnlToDo = new FlowLayoutPanel();
            pnlInProgress = new FlowLayoutPanel();
            pnlDone = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(60, 12);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(78, 46);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "Add";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // pnlToDo
            // 
            pnlToDo.BorderStyle = BorderStyle.FixedSingle;
            pnlToDo.FlowDirection = FlowDirection.TopDown;
            pnlToDo.Location = new Point(38, 110);
            pnlToDo.Name = "pnlToDo";
            pnlToDo.Size = new Size(354, 586);
            pnlToDo.TabIndex = 1;
            // 
            // pnlInProgress
            // 
            pnlInProgress.BorderStyle = BorderStyle.FixedSingle;
            pnlInProgress.FlowDirection = FlowDirection.TopDown;
            pnlInProgress.Location = new Point(509, 110);
            pnlInProgress.Name = "pnlInProgress";
            pnlInProgress.Size = new Size(354, 586);
            pnlInProgress.TabIndex = 2;
            // 
            // pnlDone
            // 
            pnlDone.BorderStyle = BorderStyle.FixedSingle;
            pnlDone.FlowDirection = FlowDirection.TopDown;
            pnlDone.Location = new Point(990, 110);
            pnlDone.Name = "pnlDone";
            pnlDone.Size = new Size(354, 586);
            pnlDone.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(166, 68);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 4;
            label1.Text = "To Do ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(633, 68);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 5;
            label2.Text = "In Progress";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1147, 68);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 6;
            label3.Text = "Done";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1394, 711);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pnlDone);
            Controls.Add(pnlInProgress);
            Controls.Add(pnlToDo);
            Controls.Add(btnAddTask);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddTask;
        private FlowLayoutPanel pnlToDo;
        private FlowLayoutPanel pnlInProgress;
        private FlowLayoutPanel pnlDone;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

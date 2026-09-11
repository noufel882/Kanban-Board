using nKanban.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nKanban
{
    public partial class frmAddTask : Form
    {
        public event EventHandler<TaskDetails> AddTaskDelegate;

        protected void AddNewTask(TaskDetails task)
        {
            var handler = AddTaskDelegate;
            handler?.Invoke(this, task);
        }   

        public frmAddTask()
        {
            InitializeComponent();
            cbTaskStatus.SelectedIndex = 0; // Set default selection to "To Do"
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("The task title is require !","Note",MessageBoxButtons.OK);
                return;
            }

            TaskDetails newTask = new TaskDetails
            {
                TaskName = txtTitle.Text,
                TaskDescription = txtDescription.Text,
                TaskStatus = cbTaskStatus.SelectedItem.ToString()
            };

            AddNewTask(newTask);
            this.Close();
        }
    }
}

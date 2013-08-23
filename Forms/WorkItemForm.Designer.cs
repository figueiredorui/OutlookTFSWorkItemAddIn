namespace OutlookAddIn2.Forms
{
    partial class WorkItemForm
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
            this.components = new System.ComponentModel.Container();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAssignedTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbIteration = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtTeamProject = new System.Windows.Forms.TextBox();
            this.btnTeamProject = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWorkItemType = new System.Windows.Forms.ComboBox();
            this.grpWorkItem = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpWorkItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(98, 46);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(575, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(98, 101);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(575, 221);
            this.txtDescription.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // cmbAssignedTo
            // 
            this.cmbAssignedTo.FormattingEnabled = true;
            this.cmbAssignedTo.Location = new System.Drawing.Point(436, 19);
            this.cmbAssignedTo.Name = "cmbAssignedTo";
            this.cmbAssignedTo.Size = new System.Drawing.Size(235, 21);
            this.cmbAssignedTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Assigned To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Area:";
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(98, 72);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(238, 21);
            this.cmbArea.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Iteration:";
            // 
            // cmbIteration
            // 
            this.cmbIteration.FormattingEnabled = true;
            this.cmbIteration.Location = new System.Drawing.Point(436, 73);
            this.cmbIteration.Name = "cmbIteration";
            this.cmbIteration.Size = new System.Drawing.Size(236, 21);
            this.cmbIteration.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Team Project:";
            // 
            // txtTeamProject
            // 
            this.txtTeamProject.Location = new System.Drawing.Point(110, 35);
            this.txtTeamProject.Name = "txtTeamProject";
            this.txtTeamProject.Size = new System.Drawing.Size(525, 20);
            this.txtTeamProject.TabIndex = 0;
            // 
            // btnTeamProject
            // 
            this.btnTeamProject.Location = new System.Drawing.Point(641, 33);
            this.btnTeamProject.Name = "btnTeamProject";
            this.btnTeamProject.Size = new System.Drawing.Size(42, 23);
            this.btnTeamProject.TabIndex = 5;
            this.btnTeamProject.Text = "...";
            this.btnTeamProject.UseVisualStyleBackColor = true;
            this.btnTeamProject.Click += new System.EventHandler(this.btnTeamProject_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Work Item Type:";
            // 
            // cmbWorkItemType
            // 
            this.cmbWorkItemType.FormattingEnabled = true;
            this.cmbWorkItemType.Location = new System.Drawing.Point(98, 19);
            this.cmbWorkItemType.Name = "cmbWorkItemType";
            this.cmbWorkItemType.Size = new System.Drawing.Size(238, 21);
            this.cmbWorkItemType.TabIndex = 3;
            // 
            // grpWorkItem
            // 
            this.grpWorkItem.Controls.Add(this.btnSave);
            this.grpWorkItem.Controls.Add(this.label7);
            this.grpWorkItem.Controls.Add(this.txtTitle);
            this.grpWorkItem.Controls.Add(this.txtDescription);
            this.grpWorkItem.Controls.Add(this.cmbIteration);
            this.grpWorkItem.Controls.Add(this.label1);
            this.grpWorkItem.Controls.Add(this.cmbArea);
            this.grpWorkItem.Controls.Add(this.label5);
            this.grpWorkItem.Controls.Add(this.cmbWorkItemType);
            this.grpWorkItem.Controls.Add(this.label3);
            this.grpWorkItem.Controls.Add(this.label2);
            this.grpWorkItem.Controls.Add(this.cmbAssignedTo);
            this.grpWorkItem.Controls.Add(this.label4);
            this.grpWorkItem.Location = new System.Drawing.Point(12, 67);
            this.grpWorkItem.Name = "grpWorkItem";
            this.grpWorkItem.Size = new System.Drawing.Size(688, 381);
            this.grpWorkItem.TabIndex = 6;
            this.grpWorkItem.TabStop = false;
            this.grpWorkItem.Text = "Work Item";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(596, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WorkItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 473);
            this.Controls.Add(this.grpWorkItem);
            this.Controls.Add(this.btnTeamProject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTeamProject);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpWorkItem.ResumeLayout(false);
            this.grpWorkItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAssignedTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbIteration;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnTeamProject;
        private System.Windows.Forms.ComboBox cmbWorkItemType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTeamProject;
        private System.Windows.Forms.GroupBox grpWorkItem;
        private System.Windows.Forms.Button btnSave;
    }
}
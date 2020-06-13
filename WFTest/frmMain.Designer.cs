namespace WFTest
{
    partial class frmMain
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
            this.btnFill = new System.Windows.Forms.Button();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFillInfo = new System.Windows.Forms.Label();
            this.cbDisable = new System.Windows.Forms.CheckBox();
            this.lblResizeInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFill
            // 
            this.btnFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFill.Location = new System.Drawing.Point(16, 834);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(165, 60);
            this.btnFill.TabIndex = 0;
            this.btnFill.Text = "&Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cDate});
            this.dgFiles.Location = new System.Drawing.Point(16, 23);
            this.dgFiles.MultiSelect = false;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.ReadOnly = true;
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.RowHeadersWidth = 4;
            this.dgFiles.RowTemplate.Height = 33;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.Size = new System.Drawing.Size(723, 794);
            this.dgFiles.TabIndex = 1;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cName.HeaderText = "Name";
            this.cName.MinimumWidth = 10;
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 859;
            // 
            // cDate
            // 
            this.cDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDate.HeaderText = "Date";
            this.cDate.MinimumWidth = 10;
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            this.cDate.Width = 102;
            // 
            // lblFillInfo
            // 
            this.lblFillInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFillInfo.AutoSize = true;
            this.lblFillInfo.Location = new System.Drawing.Point(198, 838);
            this.lblFillInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFillInfo.Name = "lblFillInfo";
            this.lblFillInfo.Size = new System.Drawing.Size(0, 20);
            this.lblFillInfo.TabIndex = 2;
            // 
            // cbDisable
            // 
            this.cbDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisable.AutoSize = true;
            this.cbDisable.Location = new System.Drawing.Point(535, 853);
            this.cbDisable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDisable.Name = "cbDisable";
            this.cbDisable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDisable.Size = new System.Drawing.Size(204, 24);
            this.cbDisable.TabIndex = 3;
            this.cbDisable.Text = "Disable During Updates";
            this.cbDisable.UseVisualStyleBackColor = true;
            this.cbDisable.CheckedChanged += new System.EventHandler(this.cbDisable_CheckedChanged);
            // 
            // lblResizeInfo
            // 
            this.lblResizeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResizeInfo.AutoSize = true;
            this.lblResizeInfo.Location = new System.Drawing.Point(198, 869);
            this.lblResizeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResizeInfo.Name = "lblResizeInfo";
            this.lblResizeInfo.Size = new System.Drawing.Size(0, 20);
            this.lblResizeInfo.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 910);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.lblFillInfo);
            this.Controls.Add(this.lblResizeInfo);
            this.Controls.Add(this.cbDisable);
            this.Name = "frmMain";
            this.Text = "DataGridView Test";
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.Label lblFillInfo;
        private System.Windows.Forms.CheckBox cbDisable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.Label lblResizeInfo;
    }
}
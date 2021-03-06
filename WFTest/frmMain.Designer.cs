﻿namespace WFTest
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
            this.lblFillInfo = new System.Windows.Forms.Label();
            this.cbDisable = new System.Windows.Forms.CheckBox();
            this.lblResizeInfo = new System.Windows.Forms.Label();
            this.cbDisableBolding = new System.Windows.Forms.CheckBox();
            this.cbDataSource = new System.Windows.Forms.CheckBox();
            this.cbBoldingInLine = new System.Windows.Forms.CheckBox();
            this.cbVirtual = new System.Windows.Forms.CheckBox();
            this.lblThread = new System.Windows.Forms.Label();
            this.cbDelay = new System.Windows.Forms.CheckBox();
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
            this.dgFiles.AllowUserToResizeRows = false;
            this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgFiles.Location = new System.Drawing.Point(16, 23);
            this.dgFiles.MultiSelect = false;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.ReadOnly = true;
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.RowHeadersWidth = 4;
            this.dgFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgFiles.RowTemplate.Height = 33;
            this.dgFiles.RowTemplate.ReadOnly = true;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.Size = new System.Drawing.Size(723, 663);
            this.dgFiles.TabIndex = 1;
            // 
            // lblFillInfo
            // 
            this.lblFillInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFillInfo.AutoSize = true;
            this.lblFillInfo.Location = new System.Drawing.Point(198, 797);
            this.lblFillInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFillInfo.Name = "lblFillInfo";
            this.lblFillInfo.Size = new System.Drawing.Size(0, 20);
            this.lblFillInfo.TabIndex = 2;
            // 
            // cbDisable
            // 
            this.cbDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisable.AutoSize = true;
            this.cbDisable.Location = new System.Drawing.Point(535, 809);
            this.cbDisable.Margin = new System.Windows.Forms.Padding(2);
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
            // cbDisableBolding
            // 
            this.cbDisableBolding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisableBolding.AutoSize = true;
            this.cbDisableBolding.Location = new System.Drawing.Point(594, 869);
            this.cbDisableBolding.Name = "cbDisableBolding";
            this.cbDisableBolding.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDisableBolding.Size = new System.Drawing.Size(145, 24);
            this.cbDisableBolding.TabIndex = 5;
            this.cbDisableBolding.Text = "Disable Bolding";
            this.cbDisableBolding.UseVisualStyleBackColor = true;
            this.cbDisableBolding.CheckedChanged += new System.EventHandler(this.cbDisableBolding_CheckedChanged);
            // 
            // cbDataSource
            // 
            this.cbDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDataSource.AutoSize = true;
            this.cbDataSource.Location = new System.Drawing.Point(585, 722);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDataSource.Size = new System.Drawing.Size(154, 24);
            this.cbDataSource.TabIndex = 6;
            this.cbDataSource.Text = "Use DataSource";
            this.cbDataSource.UseVisualStyleBackColor = true;
            this.cbDataSource.CheckedChanged += new System.EventHandler(this.cbDataSource_CheckedChanged);
            // 
            // cbBoldingInLine
            // 
            this.cbBoldingInLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBoldingInLine.AutoSize = true;
            this.cbBoldingInLine.Location = new System.Drawing.Point(598, 839);
            this.cbBoldingInLine.Name = "cbBoldingInLine";
            this.cbBoldingInLine.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBoldingInLine.Size = new System.Drawing.Size(141, 24);
            this.cbBoldingInLine.TabIndex = 7;
            this.cbBoldingInLine.Text = "Bolding In-Line";
            this.cbBoldingInLine.UseVisualStyleBackColor = true;
            this.cbBoldingInLine.CheckedChanged += new System.EventHandler(this.cbBoldingInLine_CheckedChanged);
            // 
            // cbVirtual
            // 
            this.cbVirtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVirtual.AutoSize = true;
            this.cbVirtual.Location = new System.Drawing.Point(582, 752);
            this.cbVirtual.Name = "cbVirtual";
            this.cbVirtual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbVirtual.Size = new System.Drawing.Size(157, 24);
            this.cbVirtual.TabIndex = 8;
            this.cbVirtual.Text = "Use Virtual Mode";
            this.cbVirtual.UseVisualStyleBackColor = true;
            this.cbVirtual.CheckedChanged += new System.EventHandler(this.cbVirtual_CheckedChanged);
            // 
            // lblThread
            // 
            this.lblThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThread.AutoSize = true;
            this.lblThread.Location = new System.Drawing.Point(198, 833);
            this.lblThread.Name = "lblThread";
            this.lblThread.Size = new System.Drawing.Size(0, 20);
            this.lblThread.TabIndex = 9;
            // 
            // cbDelay
            // 
            this.cbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDelay.AutoSize = true;
            this.cbDelay.Location = new System.Drawing.Point(546, 780);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDelay.Size = new System.Drawing.Size(193, 24);
            this.cbDelay.TabIndex = 10;
            this.cbDelay.Text = "Add virtual 10ms delay";
            this.cbDelay.UseVisualStyleBackColor = true;
            this.cbDelay.CheckedChanged += new System.EventHandler(this.cbDelay_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 910);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.lblFillInfo);
            this.Controls.Add(this.lblThread);
            this.Controls.Add(this.lblResizeInfo);
            this.Controls.Add(this.cbDataSource);
            this.Controls.Add(this.cbVirtual);
            this.Controls.Add(this.cbDelay);
            this.Controls.Add(this.cbDisable);
            this.Controls.Add(this.cbBoldingInLine);
            this.Controls.Add(this.cbDisableBolding);
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
        private System.Windows.Forms.Label lblResizeInfo;
        private System.Windows.Forms.CheckBox cbDisableBolding;
        private System.Windows.Forms.CheckBox cbDataSource;
        private System.Windows.Forms.CheckBox cbBoldingInLine;
        private System.Windows.Forms.CheckBox cbVirtual;
        private System.Windows.Forms.Label lblThread;
        private System.Windows.Forms.CheckBox cbDelay;
    }
}
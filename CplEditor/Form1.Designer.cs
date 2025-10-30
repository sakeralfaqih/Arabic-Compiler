namespace CplEditor
{
    partial class Form1
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.EditorControl = new ScintillaNET.Scintilla();
            this.ErrorGridView = new System.Windows.Forms.DataGridView();
            this.ColLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MainMenuStrip.Size = new System.Drawing.Size(1148, 30);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.AnalyzeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnalyzeButton.FlatAppearance.BorderSize = 0;
            this.AnalyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnalyzeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyzeButton.ForeColor = System.Drawing.Color.White;
            this.AnalyzeButton.Location = new System.Drawing.Point(0, 30);
            this.AnalyzeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(1148, 55);
            this.AnalyzeButton.TabIndex = 1;
            this.AnalyzeButton.Text = "تحليل وبناء المشروع (Build)";
            this.AnalyzeButton.UseVisualStyleBackColor = false;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 85);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.EditorControl);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ErrorGridView);
            this.MainSplitContainer.Size = new System.Drawing.Size(1148, 729);
            this.MainSplitContainer.SplitterDistance = 554;
            this.MainSplitContainer.SplitterWidth = 5;
            this.MainSplitContainer.TabIndex = 2;
            // 
            // EditorControl
            // 
            this.EditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorControl.Location = new System.Drawing.Point(0, 0);
            this.EditorControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditorControl.Name = "EditorControl";
            this.EditorControl.Size = new System.Drawing.Size(1148, 554);
            this.EditorControl.TabIndex = 0;
            // 
            // ErrorGridView
            // 
            this.ErrorGridView.AllowUserToAddRows = false;
            this.ErrorGridView.AllowUserToDeleteRows = false;
            this.ErrorGridView.AllowUserToResizeRows = false;
            this.ErrorGridView.BackgroundColor = System.Drawing.Color.White;
            this.ErrorGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ErrorGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLine,
            this.ColMessage});
            this.ErrorGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorGridView.Location = new System.Drawing.Point(0, 0);
            this.ErrorGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ErrorGridView.Name = "ErrorGridView";
            this.ErrorGridView.ReadOnly = true;
            this.ErrorGridView.RowHeadersVisible = false;
            this.ErrorGridView.RowHeadersWidth = 51;
            this.ErrorGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ErrorGridView.Size = new System.Drawing.Size(1148, 170);
            this.ErrorGridView.TabIndex = 0;
            // 
            // ColLine
            // 
            this.ColLine.HeaderText = "السطر";
            this.ColLine.MinimumWidth = 6;
            this.ColLine.Name = "ColLine";
            this.ColLine.ReadOnly = true;
            this.ColLine.Width = 80;
            // 
            // ColMessage
            // 
            this.ColMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColMessage.HeaderText = "الخطأ";
            this.ColMessage.MinimumWidth = 6;
            this.ColMessage.Name = "ColMessage";
            this.ColMessage.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 814);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.MainMenuStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "محرر اللغة العربية (CPL Editor)";
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // --- هذه هي المتغيرات التي تربط الكود بالتصميم ---
        // (الكود في Form1.cs سيستخدم هذه المتغيرات)
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private ScintillaNET.Scintilla EditorControl;
        private System.Windows.Forms.DataGridView ErrorGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMessage;
    }
}
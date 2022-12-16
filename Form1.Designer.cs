namespace Calculator
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
            this.ApplyButton = new System.Windows.Forms.Button();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AppendButton = new System.Windows.Forms.Button();
            this.contextTextBox = new System.Windows.Forms.TextBox();
            this.AddCalculation = new System.Windows.Forms.Button();
            this.MultiplyButton = new System.Windows.Forms.Button();
            this.DivideButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.PowButton = new System.Windows.Forms.Button();
            this.SqrtnButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.SqrButton = new System.Windows.Forms.Button();
            this.SqrtButton = new System.Windows.Forms.Button();
            this.FactButton = new System.Windows.Forms.Button();
            this.MedianButton = new System.Windows.Forms.Button();
            this.DeviationButton = new System.Windows.Forms.Button();
            this.RepeatButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.UndoButton = new System.Windows.Forms.Button();
            this.FixButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.addFilenameButton = new System.Windows.Forms.Button();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.clearDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(9, 146);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(102, 54);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.AcceptsReturn = true;
            this.mainTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.mainTextBox.Location = new System.Drawing.Point(9, 64);
            this.mainTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(381, 55);
            this.mainTextBox.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox1.Location = new System.Drawing.Point(9, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(381, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AppendButton
            // 
            this.AppendButton.Location = new System.Drawing.Point(394, 10);
            this.AppendButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AppendButton.Name = "AppendButton";
            this.AppendButton.Size = new System.Drawing.Size(94, 52);
            this.AppendButton.TabIndex = 4;
            this.AppendButton.Text = "Append";
            this.AppendButton.UseVisualStyleBackColor = true;
            this.AppendButton.Click += new System.EventHandler(this.AppendButton_Click);
            // 
            // contextTextBox
            // 
            this.contextTextBox.Location = new System.Drawing.Point(9, 124);
            this.contextTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.contextTextBox.Name = "contextTextBox";
            this.contextTextBox.ReadOnly = true;
            this.contextTextBox.Size = new System.Drawing.Size(381, 20);
            this.contextTextBox.TabIndex = 5;
            this.contextTextBox.TextChanged += new System.EventHandler(this.ContextTextBox_TextChanged);
            // 
            // AddCalculation
            // 
            this.AddCalculation.Location = new System.Drawing.Point(394, 64);
            this.AddCalculation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddCalculation.Name = "AddCalculation";
            this.AddCalculation.Size = new System.Drawing.Size(94, 55);
            this.AddCalculation.TabIndex = 6;
            this.AddCalculation.Text = "Add Calculation";
            this.AddCalculation.UseVisualStyleBackColor = true;
            this.AddCalculation.Click += new System.EventHandler(this.AddCalculationButton_Click);
            // 
            // MultiplyButton
            // 
            this.MultiplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplyButton.Location = new System.Drawing.Point(6, 217);
            this.MultiplyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MultiplyButton.Name = "MultiplyButton";
            this.MultiplyButton.Size = new System.Drawing.Size(63, 31);
            this.MultiplyButton.TabIndex = 7;
            this.MultiplyButton.Text = "*";
            this.MultiplyButton.UseVisualStyleBackColor = true;
            this.MultiplyButton.Click += new System.EventHandler(this.MultiplyButton_Click);
            // 
            // DivideButton
            // 
            this.DivideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DivideButton.Location = new System.Drawing.Point(6, 252);
            this.DivideButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DivideButton.Name = "DivideButton";
            this.DivideButton.Size = new System.Drawing.Size(63, 31);
            this.DivideButton.TabIndex = 8;
            this.DivideButton.Text = "/";
            this.DivideButton.UseVisualStyleBackColor = true;
            this.DivideButton.Click += new System.EventHandler(this.DivideButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(73, 217);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(63, 31);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtractButton.Location = new System.Drawing.Point(73, 252);
            this.ExtractButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(63, 31);
            this.ExtractButton.TabIndex = 10;
            this.ExtractButton.Text = "-";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // PowButton
            // 
            this.PowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowButton.Location = new System.Drawing.Point(140, 217);
            this.PowButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PowButton.Name = "PowButton";
            this.PowButton.Size = new System.Drawing.Size(63, 31);
            this.PowButton.TabIndex = 11;
            this.PowButton.Text = "^";
            this.PowButton.UseVisualStyleBackColor = true;
            this.PowButton.Click += new System.EventHandler(this.PowButton_Click);
            // 
            // SqrtnButton
            // 
            this.SqrtnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqrtnButton.Location = new System.Drawing.Point(140, 252);
            this.SqrtnButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SqrtnButton.Name = "SqrtnButton";
            this.SqrtnButton.Size = new System.Drawing.Size(63, 31);
            this.SqrtnButton.TabIndex = 12;
            this.SqrtnButton.Text = "n√";
            this.SqrtnButton.UseVisualStyleBackColor = true;
            this.SqrtnButton.Click += new System.EventHandler(this.SqrtnButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogButton.Location = new System.Drawing.Point(207, 217);
            this.LogButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(63, 31);
            this.LogButton.TabIndex = 13;
            this.LogButton.Text = "log a";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // SqrButton
            // 
            this.SqrButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqrButton.Location = new System.Drawing.Point(8, 287);
            this.SqrButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SqrButton.Name = "SqrButton";
            this.SqrButton.Size = new System.Drawing.Size(63, 31);
            this.SqrButton.TabIndex = 14;
            this.SqrButton.Text = "^2";
            this.SqrButton.UseVisualStyleBackColor = true;
            this.SqrButton.Click += new System.EventHandler(this.SqrButton_Click);
            // 
            // SqrtButton
            // 
            this.SqrtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqrtButton.Location = new System.Drawing.Point(8, 322);
            this.SqrtButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SqrtButton.Name = "SqrtButton";
            this.SqrtButton.Size = new System.Drawing.Size(63, 31);
            this.SqrtButton.TabIndex = 15;
            this.SqrtButton.Text = "√";
            this.SqrtButton.UseVisualStyleBackColor = true;
            this.SqrtButton.Click += new System.EventHandler(this.SqrtButton_Click);
            // 
            // FactButton
            // 
            this.FactButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FactButton.Location = new System.Drawing.Point(73, 287);
            this.FactButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FactButton.Name = "FactButton";
            this.FactButton.Size = new System.Drawing.Size(63, 31);
            this.FactButton.TabIndex = 16;
            this.FactButton.Text = "!";
            this.FactButton.UseVisualStyleBackColor = true;
            this.FactButton.Click += new System.EventHandler(this.FactButton_Click);
            // 
            // MedianButton
            // 
            this.MedianButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MedianButton.Location = new System.Drawing.Point(8, 357);
            this.MedianButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MedianButton.Name = "MedianButton";
            this.MedianButton.Size = new System.Drawing.Size(63, 31);
            this.MedianButton.TabIndex = 17;
            this.MedianButton.Text = "median";
            this.MedianButton.UseVisualStyleBackColor = true;
            this.MedianButton.Click += new System.EventHandler(this.MedianButton_Click);
            // 
            // DeviationButton
            // 
            this.DeviationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviationButton.Location = new System.Drawing.Point(75, 357);
            this.DeviationButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeviationButton.Name = "DeviationButton";
            this.DeviationButton.Size = new System.Drawing.Size(63, 31);
            this.DeviationButton.TabIndex = 18;
            this.DeviationButton.Text = "dev";
            this.DeviationButton.UseVisualStyleBackColor = true;
            this.DeviationButton.Click += new System.EventHandler(this.DeviationButton_Click);
            // 
            // RepeatButton
            // 
            this.RepeatButton.Enabled = false;
            this.RepeatButton.Location = new System.Drawing.Point(272, 146);
            this.RepeatButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Size = new System.Drawing.Size(57, 29);
            this.RepeatButton.TabIndex = 19;
            this.RepeatButton.Text = "Repeat";
            this.RepeatButton.UseVisualStyleBackColor = true;
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(333, 146);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(57, 29);
            this.ClearButton.TabIndex = 20;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(333, 35);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(57, 23);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // historyListBox
            // 
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.Location = new System.Drawing.Point(333, 180);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.Size = new System.Drawing.Size(156, 212);
            this.historyListBox.TabIndex = 22;
            this.historyListBox.SelectedIndexChanged += new System.EventHandler(this.HistoryListBox_SelectedIndexChanged);
            // 
            // UndoButton
            // 
            this.UndoButton.Enabled = false;
            this.UndoButton.Location = new System.Drawing.Point(210, 146);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(57, 29);
            this.UndoButton.TabIndex = 23;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // FixButton
            // 
            this.FixButton.Enabled = false;
            this.FixButton.Location = new System.Drawing.Point(270, 35);
            this.FixButton.Name = "FixButton";
            this.FixButton.Size = new System.Drawing.Size(57, 23);
            this.FixButton.TabIndex = 24;
            this.FixButton.Text = "Fix";
            this.FixButton.UseVisualStyleBackColor = true;
            this.FixButton.Click += new System.EventHandler(this.FixButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(166, 150);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(35, 13);
            this.timeLabel.TabIndex = 25;
            this.timeLabel.Text = "label1";
            this.timeLabel.Visible = false;
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(231, 325);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(96, 30);
            this.exportButton.TabIndex = 26;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Enabled = false;
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(231, 357);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(96, 31);
            this.importButton.TabIndex = 27;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // addFilenameButton
            // 
            this.addFilenameButton.Location = new System.Drawing.Point(231, 290);
            this.addFilenameButton.Name = "addFilenameButton";
            this.addFilenameButton.Size = new System.Drawing.Size(96, 31);
            this.addFilenameButton.TabIndex = 28;
            this.addFilenameButton.Text = "Add Filename";
            this.addFilenameButton.UseVisualStyleBackColor = true;
            this.addFilenameButton.Click += new System.EventHandler(this.addFilenameButton_Click);
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(235, 274);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(35, 13);
            this.filenameLabel.TabIndex = 29;
            this.filenameLabel.Text = "label1";
            this.filenameLabel.Visible = false;
            // 
            // clearDataButton
            // 
            this.clearDataButton.Location = new System.Drawing.Point(9, 36);
            this.clearDataButton.Name = "clearDataButton";
            this.clearDataButton.Size = new System.Drawing.Size(75, 23);
            this.clearDataButton.TabIndex = 30;
            this.clearDataButton.Text = "Clear";
            this.clearDataButton.UseVisualStyleBackColor = true;
            this.clearDataButton.Click += new System.EventHandler(this.clearDataButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 395);
            this.Controls.Add(this.clearDataButton);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.addFilenameButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.FixButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RepeatButton);
            this.Controls.Add(this.DeviationButton);
            this.Controls.Add(this.MedianButton);
            this.Controls.Add(this.FactButton);
            this.Controls.Add(this.SqrtButton);
            this.Controls.Add(this.SqrButton);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.SqrtnButton);
            this.Controls.Add(this.PowButton);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DivideButton);
            this.Controls.Add(this.MultiplyButton);
            this.Controls.Add(this.AddCalculation);
            this.Controls.Add(this.contextTextBox);
            this.Controls.Add(this.AppendButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.ApplyButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AppendButton;
        private System.Windows.Forms.TextBox contextTextBox;
        private System.Windows.Forms.Button AddCalculation;
        private System.Windows.Forms.Button MultiplyButton;
        private System.Windows.Forms.Button DivideButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button PowButton;
        private System.Windows.Forms.Button SqrtnButton;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.Button SqrButton;
        private System.Windows.Forms.Button SqrtButton;
        private System.Windows.Forms.Button FactButton;
        private System.Windows.Forms.Button MedianButton;
        private System.Windows.Forms.Button DeviationButton;
        private System.Windows.Forms.Button RepeatButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button FixButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button addFilenameButton;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.Button clearDataButton;
    }
}


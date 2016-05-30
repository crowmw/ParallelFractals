namespace ParallelFractals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationCount = new System.Windows.Forms.Label();
            this.MPIGroupBox = new System.Windows.Forms.GroupBox();
            this.partitionTextBox = new System.Windows.Forms.TextBox();
            this.partitionLabel = new System.Windows.Forms.Label();
            this.processCountTextBox = new System.Windows.Forms.TextBox();
            this.ProcessCountLabel = new System.Windows.Forms.Label();
            this.iterationsTextBox = new System.Windows.Forms.TextBox();
            this.IterationsLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.CUDAGroupBox = new System.Windows.Forms.GroupBox();
            this.fractalBox = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MPIGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.fractalBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rysuj MPI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(8, 120);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(33, 13);
            this.durationLabel.TabIndex = 1;
            this.durationLabel.Text = "Czas:";
            // 
            // durationCount
            // 
            this.durationCount.AutoSize = true;
            this.durationCount.Location = new System.Drawing.Point(41, 120);
            this.durationCount.Name = "durationCount";
            this.durationCount.Size = new System.Drawing.Size(0, 13);
            this.durationCount.TabIndex = 2;
            // 
            // MPIGroupBox
            // 
            this.MPIGroupBox.Controls.Add(this.partitionTextBox);
            this.MPIGroupBox.Controls.Add(this.partitionLabel);
            this.MPIGroupBox.Controls.Add(this.processCountTextBox);
            this.MPIGroupBox.Controls.Add(this.ProcessCountLabel);
            this.MPIGroupBox.Controls.Add(this.button1);
            this.MPIGroupBox.Controls.Add(this.durationCount);
            this.MPIGroupBox.Controls.Add(this.durationLabel);
            this.MPIGroupBox.Location = new System.Drawing.Point(13, 129);
            this.MPIGroupBox.Name = "MPIGroupBox";
            this.MPIGroupBox.Size = new System.Drawing.Size(265, 144);
            this.MPIGroupBox.TabIndex = 3;
            this.MPIGroupBox.TabStop = false;
            this.MPIGroupBox.Text = "MPI";
            // 
            // partitionTextBox
            // 
            this.partitionTextBox.Location = new System.Drawing.Point(101, 55);
            this.partitionTextBox.Name = "partitionTextBox";
            this.partitionTextBox.Size = new System.Drawing.Size(100, 20);
            this.partitionTextBox.TabIndex = 8;
            this.partitionTextBox.Text = "1500";
            // 
            // partitionLabel
            // 
            this.partitionLabel.AutoSize = true;
            this.partitionLabel.Location = new System.Drawing.Point(15, 58);
            this.partitionLabel.Name = "partitionLabel";
            this.partitionLabel.Size = new System.Drawing.Size(79, 13);
            this.partitionLabel.TabIndex = 7;
            this.partitionLabel.Text = "Wielkość porcji";
            // 
            // processCountTextBox
            // 
            this.processCountTextBox.Location = new System.Drawing.Point(101, 29);
            this.processCountTextBox.Name = "processCountTextBox";
            this.processCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.processCountTextBox.TabIndex = 6;
            this.processCountTextBox.Text = "5";
            // 
            // ProcessCountLabel
            // 
            this.ProcessCountLabel.AutoSize = true;
            this.ProcessCountLabel.Location = new System.Drawing.Point(8, 32);
            this.ProcessCountLabel.Name = "ProcessCountLabel";
            this.ProcessCountLabel.Size = new System.Drawing.Size(87, 13);
            this.ProcessCountLabel.TabIndex = 5;
            this.ProcessCountLabel.Text = "Liczba procesów";
            // 
            // iterationsTextBox
            // 
            this.iterationsTextBox.Location = new System.Drawing.Point(101, 19);
            this.iterationsTextBox.Name = "iterationsTextBox";
            this.iterationsTextBox.Size = new System.Drawing.Size(100, 20);
            this.iterationsTextBox.TabIndex = 4;
            this.iterationsTextBox.Text = "100";
            // 
            // IterationsLabel
            // 
            this.IterationsLabel.AutoSize = true;
            this.IterationsLabel.Location = new System.Drawing.Point(29, 22);
            this.IterationsLabel.Name = "IterationsLabel";
            this.IterationsLabel.Size = new System.Drawing.Size(65, 13);
            this.IterationsLabel.TabIndex = 3;
            this.IterationsLabel.Text = "Liczba itracji";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(293, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(506, 446);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // CUDAGroupBox
            // 
            this.CUDAGroupBox.Location = new System.Drawing.Point(13, 279);
            this.CUDAGroupBox.Name = "CUDAGroupBox";
            this.CUDAGroupBox.Size = new System.Drawing.Size(265, 129);
            this.CUDAGroupBox.TabIndex = 5;
            this.CUDAGroupBox.TabStop = false;
            this.CUDAGroupBox.Text = "CUDA";
            // 
            // fractalBox
            // 
            this.fractalBox.Controls.Add(this.IterationsLabel);
            this.fractalBox.Controls.Add(this.iterationsTextBox);
            this.fractalBox.Location = new System.Drawing.Point(13, 12);
            this.fractalBox.Name = "fractalBox";
            this.fractalBox.Size = new System.Drawing.Size(264, 111);
            this.fractalBox.TabIndex = 6;
            this.fractalBox.TabStop = false;
            this.fractalBox.Text = "Fraktal";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 498);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fractalBox);
            this.Controls.Add(this.CUDAGroupBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.MPIGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MPI/CUDA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MPIGroupBox.ResumeLayout(false);
            this.MPIGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.fractalBox.ResumeLayout(false);
            this.fractalBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label durationCount;
        private System.Windows.Forms.GroupBox MPIGroupBox;
        private System.Windows.Forms.TextBox processCountTextBox;
        private System.Windows.Forms.Label ProcessCountLabel;
        private System.Windows.Forms.TextBox iterationsTextBox;
        private System.Windows.Forms.Label IterationsLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox CUDAGroupBox;
        private System.Windows.Forms.TextBox partitionTextBox;
        private System.Windows.Forms.Label partitionLabel;
        private System.Windows.Forms.GroupBox fractalBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}


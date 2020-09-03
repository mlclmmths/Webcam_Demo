namespace Webcam
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
            this.comboCamera = new System.Windows.Forms.ComboBox();
            this.displayOutput = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.capturedOutput = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textboxBase64 = new System.Windows.Forms.RichTextBox();
            this.base64Label = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.displayOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCamera
            // 
            this.comboCamera.FormattingEnabled = true;
            this.comboCamera.Location = new System.Drawing.Point(61, 34);
            this.comboCamera.Name = "comboCamera";
            this.comboCamera.Size = new System.Drawing.Size(418, 21);
            this.comboCamera.TabIndex = 0;
            this.comboCamera.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // displayOutput
            // 
            this.displayOutput.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.displayOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayOutput.Location = new System.Drawing.Point(12, 80);
            this.displayOutput.Name = "displayOutput";
            this.displayOutput.Size = new System.Drawing.Size(400, 400);
            this.displayOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.displayOutput.TabIndex = 1;
            this.displayOutput.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(733, 510);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(814, 510);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "S&top";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // cameraLabel
            // 
            this.cameraLabel.AutoSize = true;
            this.cameraLabel.Location = new System.Drawing.Point(12, 42);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(46, 13);
            this.cameraLabel.TabIndex = 6;
            this.cameraLabel.Text = "Camera:";
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(895, 80);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(75, 23);
            this.buttonCapture.TabIndex = 7;
            this.buttonCapture.Text = "&Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // capturedOutput
            // 
            this.capturedOutput.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.capturedOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.capturedOutput.Location = new System.Drawing.Point(477, 80);
            this.capturedOutput.Name = "capturedOutput";
            this.capturedOutput.Size = new System.Drawing.Size(400, 400);
            this.capturedOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.capturedOutput.TabIndex = 8;
            this.capturedOutput.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSave.Location = new System.Drawing.Point(895, 109);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textboxBase64
            // 
            this.textboxBase64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxBase64.Location = new System.Drawing.Point(895, 264);
            this.textboxBase64.Name = "textboxBase64";
            this.textboxBase64.ReadOnly = true;
            this.textboxBase64.Size = new System.Drawing.Size(150, 216);
            this.textboxBase64.TabIndex = 10;
            this.textboxBase64.Text = "";
            this.textboxBase64.TextChanged += new System.EventHandler(this.textboxBase64_TextChanged);
            // 
            // base64Label
            // 
            this.base64Label.AutoSize = true;
            this.base64Label.Location = new System.Drawing.Point(892, 248);
            this.base64Label.Name = "base64Label";
            this.base64Label.Size = new System.Drawing.Size(46, 13);
            this.base64Label.TabIndex = 11;
            this.base64Label.Text = "Base64:";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(896, 510);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(896, 139);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 13;
            this.buttonConvert.Text = "B64_Image";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1057, 543);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.base64Label);
            this.Controls.Add(this.textboxBase64);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.capturedOutput);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.cameraLabel);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.displayOutput);
            this.Controls.Add(this.comboCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webcam Demo C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCamera;
        private System.Windows.Forms.PictureBox displayOutput;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.PictureBox capturedOutput;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RichTextBox textboxBase64;
        private System.Windows.Forms.Label base64Label;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonConvert;
    }
}


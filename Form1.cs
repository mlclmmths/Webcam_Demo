using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace Webcam
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes the storage path
        /// </summary>
        //public string pathFolder = Application.StartupPath + @"\Captures\";
        public string pathFolder = @"C:\Captures\";
        bool content = false;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Initialize webcam
        ///  captureDevices will look for devices that are attached to the computer
        ///  videoSource will use the selected device to view the image
        /// </summary>
        private FilterInfoCollection captureDevices;
        private VideoCaptureDevice videoSource;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            displayOutput.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in captureDevices)
                comboCamera.Items.Add(filterInfo.Name);
            comboCamera.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning == true)
                videoSource.Stop();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                StartWebcam();
            }
            catch
            {
                MessageBox.Show("Invalid webcam!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                StopWebcam();
                if(textboxBase64 != null)
                    textboxBase64.Text = null;
            }
            catch { }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            videoSource.Stop();
            displayOutput.Image = null;
            Application.Exit(null);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            videoSource.Stop();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (content == true)
            {
                string displayName = "Webcam_Demo";
                string capturedName = $"{displayName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bmp";
                if (Directory.Exists(pathFolder))
                {
                    capturedOutput.Image.Save(pathFolder + capturedName, ImageFormat.Bmp);
                    ConvertToBase64String(capturedName);
                    MessageBox.Show("Save successful", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Directory.CreateDirectory(pathFolder);
                    capturedOutput.Image.Save(pathFolder + capturedName, ImageFormat.Bmp);
                    MessageBox.Show("Save successful", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
                MessageBox.Show("No content to save!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (textboxBase64.Text != null)
            {
                displayOutput.Image = ConvertFromBase64();
                MessageBox.Show("Image converted from Base64String successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Nothing to convert!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            try
            {
                capturedOutput.Image = (Bitmap)displayOutput.Image.Clone();
                ContentCheck();
            }
            catch
            {
                MessageBox.Show("Webcam not started!", "Error!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void textboxBase64_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Operation funtions
        /// </summary>
        private void StartWebcam()
        {
            videoSource = new VideoCaptureDevice(captureDevices[comboCamera.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }

        private void StopWebcam()
        {
            videoSource.Stop();
            displayOutput.Image = null;
            displayOutput.Invalidate();
            capturedOutput.Image = null;
            capturedOutput.Invalidate();            
        }

        private bool ContentCheck()
        {
            return content = true;
        }

        private Image ConvertFromBase64()
        {
            videoSource.Stop();
            displayOutput.Image = null;
            byte[] imageBytes = Convert.FromBase64String(textboxBase64.Text);
            MemoryStream mem = new MemoryStream(imageBytes, 0, imageBytes.Length);
            mem.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(mem, true);
            return image;
        }

        private string ConvertToBase64String(string fileName)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                byte[] imageBytes = File.ReadAllBytes(pathFolder + fileName);
                string base64String = Convert.ToBase64String(imageBytes);
                textboxBase64.Text = base64String;
                return base64String;            
            }
        }
    }
}

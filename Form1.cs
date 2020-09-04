using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        //public string pathFolderApp = Application.StartupPath + @"\Captures\";
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

        private void comboCamera_SelectedIndexChanged(object sender, EventArgs e)
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
                string _tempName = $"{displayName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bmp";
                if (Directory.Exists(pathFolder))
                {
                    capturedOutput.Image.Save(pathFolder + _tempName, ImageFormat.Bmp);
                    capturedOutput.Image = ImageCrop(_tempName);
                    capturedOutput.Image.Save(pathFolder + $"passport_{_tempName}", ImageFormat.Bmp);
                    ConvertToBase64String($"passport_{_tempName}");
                    WatermarkImage($"passport_{_tempName}");
                    MessageBox.Show("Save successful", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Directory.CreateDirectory(pathFolder);
                    capturedOutput.Image.Save(pathFolder + _tempName, ImageFormat.Bmp);
                    capturedOutput.Image = ImageCrop(_tempName);
                    capturedOutput.Image.Save(pathFolder + $"passport_{_tempName}", ImageFormat.Bmp);
                    ConvertToBase64String($"passport_{_tempName}");
                    MessageBox.Show("Save successful", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("No content to save!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                displayOutput.Image = ConvertFromBase64();
                MessageBox.Show("Image converted from Base64String successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Nothing to convert!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (textboxBase64 != null)
            {
                videoSource.Stop();
                displayOutput.Image = null;
                byte[] imageBytes = Convert.FromBase64String(textboxBase64.Text);
                MemoryStream mem = new MemoryStream(imageBytes, 0, imageBytes.Length);
                mem.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(mem, true);
                return image;
            }
            else return null;
        }

        /// Asynchronous operations
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

        private Image ImageCrop(string fileName)
        {
            int width = 413;
            int height = 531;
            Image result = null;
            var source = Image.FromFile($"{pathFolder}\\{fileName}");
            try
            {
                if (source.Width != width || source.Height != height)
                {
                    float sourceRatio = (float)source.Width / source.Height;

                    using (var target = new Bitmap(width, height))
                    {
                        using (var g = Graphics.FromImage(target))
                        {
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;

                            float scaling;
                            float scalingY = (float)source.Height / height;
                            float scalingX = (float)source.Width / width;
                            if (scalingX < scalingY)
                                scaling = scalingX;
                            else
                                scaling = scalingY;

                            int newWidth = (int)(source.Width / scaling);
                            int newHeight = (int)(source.Height / scaling);

                            if (newWidth < width)
                                newWidth = width;
                            if (newHeight < height)
                                newHeight = height;

                            int shiftX = 0;
                            int shiftY = 0;

                            if(newWidth > width)
                            {
                                shiftX = (newWidth - width) / 2;
                            }
                            if(newHeight > height)
                            {
                                shiftY = (newHeight - height) / 2;
                            }
                            g.DrawImage(source, -shiftX, -shiftY, newWidth, newHeight);
                        }
                        result = (Image)target.Clone();
                    }
                }
                else
                {
                    result = (Image)source.Clone();
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        private string watermark = "SAINS";
        private void WatermarkImage(string fileName)
        {
            Image source = Image.FromFile($"{pathFolder}\\{fileName}");
            int width = source.Width;
            int height = source.Height;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(72,72);
            Graphics graphics = Graphics.FromImage(source);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawImage(
                source, 
                new Rectangle(0,0,width,height), 
                0,
                0, 
                width, 
                height, 
                GraphicsUnit.Pixel);

            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            Font font = null;
            SizeF sizeF = new SizeF();
            {
                for(int i = 0; i < 7; i++)
                {
                    font = new Font("Arial", sizes[i],
                        FontStyle.Regular);
                    sizeF = graphics.MeasureString(watermark, font);
                    if ((ushort)sizeF.Width < (ushort)width)
                        break;
                }
            }

            int yPixelsFromBottom = (int)(height * .05);
            float yPostFromBottom = ((height - yPixelsFromBottom) - (sizeF.Height / 2));
            float xCenterOfImg = (width / 2);

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;

            SolidBrush semiTransBrush = new SolidBrush(Color.Aqua);
            graphics.DrawString(
                watermark, 
                font, 
                semiTransBrush, 
                new PointF(xCenterOfImg + 1, yPostFromBottom + 1), 
                strFormat);

            SolidBrush semiTransBrush2 = new SolidBrush(Color.Aqua);
            graphics.DrawString(
                watermark, 
                font, 
                semiTransBrush2, 
                new PointF(xCenterOfImg, yPostFromBottom), 
                strFormat);

            graphics.Dispose();
            source.Save($"{pathFolder} wm_{fileName}", ImageFormat.Bmp);
            source.Dispose();
        }
    }
}

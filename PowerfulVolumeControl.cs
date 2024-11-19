using AudioSwitcher.AudioApi.CoreAudio;

namespace PowerfulVolumeControl
{
    public partial class PowerfulVolumeControl : Form
    {
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        public PowerfulVolumeControl()
        {
            InitializeComponent();
            GenerateVolumeButtons();
        }

        private void GenerateVolumeButtons()
        {
            int buttonWidth = 50;
            int buttonHeight = 30;
            int spacing = 5;
            int columns = 10;

            int xoffset = 10;
            int yoffset = 17;

            for (int i = 1; i <= 100; i++)
            {
                int volume = i; 
                RadioButton btn = new RadioButton
                {
                    Name = $"btnVal{volume}",
                    Text = $"{volume}",
                    Width = 50,
                    Height = 20,
                    Location = new System.Drawing.Point(
                        xoffset + ((volume - 1) % 10) * (50 + xoffset), 
                        yoffset + ((volume - 1) / 10) * (20 + yoffset)  
                    )
                };

                btn.CheckedChanged += (sender, e) => VolumeButton_CheckedChanged(sender, e, volume);

                // Add the button to the GroupBox
                groupBox1.Controls.Add(btn);
            }

        }
        private void VolumeButton_CheckedChanged(object sender, EventArgs e, int volume)
        {
            if (((RadioButton)sender).Checked)
            {
                defaultPlaybackDevice.Volume = volume;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Very powerful (subject to change) volume control app that let you... well, control the volume. Tbh, this app was made for joke purposes only. \n\n—kat");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            defaultPlaybackDevice.Volume = 0;
        }
    }
}

using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    public partial class MainProject : Form
    {
        StringAnalysis stringAnalysis;
        public MainProject()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                textInput.Text=File.ReadAllText(openFile.FileName.ToString());
            }
            stringAnalysis = new StringAnalysis(textInput.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            stringAnalysis.EncoderInputFirst(stringAnalysis.GetString()[0]);
        }

        private void textOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            if (textInput.Text == "")
            {
                MessageBox.Show("Input biò trôìng");
            }
            else {
                convertBtn.Text = "Run";
            }

        }
        
    }
}
using System;
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
            stringAnalysis = new StringAnalysis();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            stringAnalysis.Clear();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                convertBtn.Text = "Convert";
                textInput.Text=File.ReadAllText(openFile.FileName.ToString());
            }
            
            stringAnalysis.EncoderInputFirst(textInput.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            textInput.Text = "";
            textOutput.Text = "";
            ChangeColorInput();
        }

        private void textOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            if (convertBtn.Text == "Convert")
            {
                if ((textClassName.Text == "") || (textExeFileName.Text == ""))
                {
                    MessageBox.Show("Classname trôìng hoac textExeFileName trôìng");
                }
                else
                {
                    if (textInput.Text == "")
                    {
                        MessageBox.Show("Input biò trôìng");
                    }
                    else
                    {
                        convertBtn.Text = "Run";
                        DecoderTextInput();
                    }
                }
            }
            

        }
        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        private void ChangeColorInput()
        {
            string NameFunction = stringAnalysis.GetNameFunction().GetName();
            string stringColorNameFunction = stringAnalysis.GetNameFunction().GetColor();
            Color colorNameFunction = Color.FromName(stringColorNameFunction);


            AppendText(textInput, NameFunction, colorNameFunction);
            textInput.AppendText("(");
            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                Color colorVariableName = Color.FromName(variable.GetColor());
                Color colorVariableType = Color.FromName(variable.GetColorDataType());

                AppendText(textInput,variable.GetName(), colorVariableName);
                textInput.AppendText(":");
                AppendText(textInput,variable.GetDataType().Trim(), colorVariableType);
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textInput.AppendText(",");
                }
                
            }
            textInput.AppendText(")");

            Variable result = new Variable(stringAnalysis.GetVariables().GetResult().GetName(),stringAnalysis.GetVariables().GetResult().GetDataType());
            Color colorResultName = Color.FromName(result.GetColor());
            Color colorResultType = Color.FromName(result.GetColorDataType());

            AppendText(textInput, result.GetName(), colorResultName);
            textInput.AppendText(":");
            AppendText(textInput, result.GetDataType(), colorResultType);
          

            Pre preTemp = new Pre(stringAnalysis.GetPre().GetName());
            Post postTemp = new Post(stringAnalysis.GetPost().GetName());

            textInput.AppendText("\n");
            textInput.AppendText("pre ");

            Color colorPre = Color.FromName(preTemp.GetColor());
            Color colorPost = Color.FromName(postTemp.GetColor());

            AppendText(textInput, preTemp.GetName(), colorPre);

            textInput.AppendText("\n");
            textInput.AppendText("post ");
            AppendText(textInput, postTemp.GetName(), colorPost);

           

        }

        private void DecoderTextInput()
        {
            AppendText(textOutput, "using ", Color.Blue);
            textOutput.AppendText("System;" + "\n");
            AppendText(textOutput, "namespace ", Color.Blue);
            textOutput.AppendText("FormalSpecification" + "\n");
            textOutput.AppendText("{" + "\n");

            AppendText(textOutput, "    public class ", Color.Blue);
            AppendText(textOutput, textClassName.Text + "\n", Color.Red);
            textOutput.AppendText("    {" + "\n");

            NhapText();
            XuatText();
            CheckText();

            textOutput.AppendText("    }" + "\n");
            textOutput.AppendText("}");

        }


        private void NhapText()
        {
            AppendText(textOutput, "        public void ", Color.Blue);
            textOutput.AppendText("Nhap_" + stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");

            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                AppendText(textOutput, "ref " + variable.GetRealDataType(variable.GetDataType()), Color.Blue);
                textOutput.AppendText(" ");
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(")" + "\n");
            textOutput.AppendText("        {" + "\n");

            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                AppendText(textOutput, "            Console", Color.Cyan);
                textOutput.AppendText(".WriteLine" + "(" + "\"" + "Nhap " + variable.GetName() + " : " + "\"); " + "\n");
                textOutput.AppendText("            " + variable.GetName() + " = ");
                AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()), Color.Blue);
                textOutput.AppendText(".Parse(");
                AppendText(textOutput, "Console", Color.Cyan);
                textOutput.AppendText(".ReadLine());" + "\n");
            }
            textOutput.AppendText("        }" + "\n");
        }



        private void XuatText()
        {
            Variable variable = stringAnalysis.GetVariables().GetResult();

            AppendText(textOutput, "        public void ", Color.Blue);
            textOutput.AppendText("Xuat_" + stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");
            AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()), Color.Blue);
            textOutput.AppendText(" " + variable.GetName()+")" + "\n");
            textOutput.AppendText("        {" + "\n");
            AppendText(textOutput, "            Console", Color.Cyan);
            textOutput.AppendText(".WriteLine(" + "\"" + "Ket qua la : {0}"+ "\"" +"," + variable.GetName() + ");" + "\n") ;
            textOutput.AppendText("        }");
            textOutput.AppendText("\n");

        }

        private void CheckText()
        {
            AppendText(textOutput, "        public int ", Color.Blue);
            textOutput.AppendText("KiemTra_" + stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");
            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                AppendText(textOutput,variable.GetRealDataType(variable.GetDataType()) + " ", Color.Blue);
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(")" + "\n");
            textOutput.AppendText("        {" + "\n");
            string check = stringAnalysis.GetPre().GetName();
            AppendText(textOutput,"            return " ,Color.Blue);
            if (check == "") textOutput.AppendText("1 ;" + "\n");
            else textOutput.AppendText(" (" + stringAnalysis.GetPre().GetName() + ") ; \n");
            textOutput.AppendText("        }" + "\n");


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
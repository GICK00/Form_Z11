using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Form_Z11
{
    public partial class Form1 : Form
    {
        class Regular
        {
            private Regex r;
            private string text;

            public string Math()
            {
                bool match = r.IsMatch(text);
                if (match == true)
                    return "\r\nТекст содержит шаблон.\r\n";
                else
                    return "\r\nТекст не содержит шаблон.\r\n";
            }
            public string MathView()
            {
                string str = "";
                MatchCollection match = r.Matches(text);
                foreach (Match m in match)
                    str += m + " ";
                return str + "\r\n";
            }
            public string MatchDelet()
            {
                return r.Replace(text, "") + "\r\n";
            }
            public Regex R
            {
                get { return r; }
                set { r = value; }
            }
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                Regular reg = new Regular();
                reg.Text = Convert.ToString(textBoxText.Text);
                if (reg.Text.Length <= 0)
                    throw new Exception("Введите текст!");
                reg.R = new Regex($@"{Convert.ToString(textBoxR.Text)}");
                if (reg.R.ToString().Length <= 0)
                    throw new Exception("Введите строку для поиска!");

                
                textBoxText.Text += reg.Math();
                textBoxText.Text += reg.MathView();
                textBoxText.Text += reg.MatchDelet();

                textBoxText.Text += "Значения R - " + reg.R + ", Text - " + reg.Text;
            }
            catch (Exception ex)
            {
                textBoxText.Text = ex.Message;
            }
        }
    }
}

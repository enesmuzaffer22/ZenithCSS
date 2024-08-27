using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZenithCSS
{
    public partial class Form5 : Form
    {
        string padding = "";
        string fontStyle = "";
        string fontSize = "";
        string bgColor = "";
        string textColor = "";
        string borderTop = "";
        string borderRight = "";
        string borderBottom = "";
        string borderLeft = "";
        string borderColor = "";
        string borderRadius = "";

        string focusBgColor = "";
        string focusTextColor = "";
        string focusBorderColor = "";
        string focusPadding = "";
        string focusTransition = "";

        string inputCSS = "";
        string inputFocusCSS = "";
        string css = "";
        string html = "";

        private void LoadFonts()
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFonts.Families;

            foreach (FontFamily fontFamily in fontFamilies)
            {
                comboBox1.Items.Add(fontFamily.Name);
            }
        }

        private async void prepareDesigner()
        {
            writeHTML();

            string filePath = "style.css";
            string content = "#textBox{\r\n   outline: none;\r\n   border-top: none;\r\n   border-right: none;\r\n   border-left: none;\r\n   border-bottom: 2px solid #808080;\r\n   padding: 0 0 6px 0;\r\n   background-color: transparent;\r\n   color: #808080;\r\n   transition: ease-in-out 0.1s;\r\n   font-size: 24px;\r\n   font-family: sans-serif;\r\n}\r\n\r\n#textBox:focus{\r\n   background-color: transparent;\r\n   border-color: #1a8219;\r\n   color: #ffffff;\r\n   padding: 0 0 12px 0;\r\n}";

            try
            {
                File.WriteAllText(filePath, content);
                MessageBox.Show("CSS başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

            textColor = "\r\n   color: rgb(128, 128, 128);";
            bgColor = "\r\n   background-color: transparent;";
            borderColor = "rgb(128, 128, 128)";
            focusBgColor = "\r\n   background-color: transparent;";
            focusBorderColor = "rgb(26, 130, 25)";
            focusTextColor = "\r\n   color: rgb(255, 255, 255);";

            css = content;

            await webView21.EnsureCoreWebView2Async(null);

            string indexPath = System.IO.Path.Combine(Application.StartupPath, "index.html");
            webView21.CoreWebView2.Navigate("file:///" + indexPath);
        }

        private void writeCSS()
        {
            string filePath = "style.css";
            string content = css;

            try
            {
                File.WriteAllText(filePath, content);
                MessageBox.Show("CSS başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void writeHTML()
        {
            string filePath = "index.html";
            string content = "<link rel=\"stylesheet\" href=\"style.css\">\r\n<link rel=\"stylesheet\" href=\"body.css\">\r\n<input type=\"text\" placeholder=\"Type something...\" id=\"textBox\">";

            html = content;

            try
            {
                File.WriteAllText(filePath, content);
                MessageBox.Show("HTML başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string iconPath = System.IO.Path.Combine(Application.StartupPath, "icon.ico");
            this.Icon = new Icon(iconPath);

            LoadFonts();
            prepareDesigner();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                bgColor = "\r\n   background-color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label29.BackColor = selectedColor;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                textColor = "\r\n   color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label12.BackColor = selectedColor;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "none")
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                textBox6.Enabled = false;
                borderTop = "";
                borderRight = "";
                borderBottom = "";
                borderLeft = "";
                borderColor = "";
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                textBox6.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                button1.Enabled = false;
                bgColor = "\r\n   background-color: transparent;";
                label22.BackColor = Color.FromArgb(32, 32, 32);
            }
            else if (checkBox5.Checked == false)
            {
                button1.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                borderTop = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                borderRight = "";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                borderBottom = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                borderLeft = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                borderColor = "rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ")";
                label23.BackColor = selectedColor;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                focusBgColor = "\r\n   background-color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label26.BackColor = selectedColor;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                focusTextColor = "\r\n   color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label24.BackColor = selectedColor;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                focusBorderColor = "rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label25.BackColor = selectedColor;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            padding = "\r\n   padding: " + textBox4.Text + "px " + textBox1.Text + "px " + textBox2.Text + "px " + textBox3.Text + "px;";
            fontStyle = "\r\n   font-family: " + "\"" + comboBox1.Text + "\", sans-serif;";
            fontSize = "\r\n   font-size: " + textBox5.Text + "px;";

            borderBottom = "\r\n   border-bottom: none;";
            borderTop = "\r\n   border-top: none;";
            borderLeft = "\r\n   border-left: none;";
            borderRight = "\r\n   border-right: none;";

            if (checkBox1.Checked == true)
            {
                borderTop = "\r\n   border-top: " + textBox6.Text + "px " + comboBox2.Text + " " + borderColor + ";";
            }

            if (checkBox2.Checked == true)
            {
                borderRight = "\r\n   border-right: " + textBox6.Text + "px " + comboBox2.Text + " " + borderColor + ";";
            }

            if (checkBox4.Checked == true)
            {
                borderBottom = "\r\n   border-bottom: " + textBox6.Text + "px " + comboBox2.Text + " " + borderColor + ";";
            }

            if (checkBox3.Checked == true)
            {
                borderLeft = "\r\n   border-left: " + textBox6.Text + "px " + comboBox2.Text + " " + borderColor + ";";
            }
            borderRadius = "\r\n   border-radius: " + textBox8.Text + "px " + textBox11.Text + "px " + textBox10.Text + "px " + textBox9.Text + "px;";

            focusTransition = "\r\n   transition: ease-in-out " + textBox7.Text + "s;";

            focusPadding = "\r\n   padding: " + textBox12.Text + "px " + textBox15.Text + "px " + textBox14.Text + "px " + textBox13.Text + "px;";

            inputCSS = "#textBox{" + "\r\n   outline: none;" + focusTransition + padding + fontStyle + fontSize + borderTop + borderRight + borderBottom + borderLeft + borderRadius + bgColor + textColor + "\r\n}";
            inputFocusCSS = "#textBox:focus{" + focusBgColor + focusTextColor + focusPadding + "\r\n   border-color: " + focusBorderColor + "\r\n}";
            css = inputCSS + "\r\n\r\n" + inputFocusCSS;

            writeCSS();
            writeHTML();

            webView21.Reload();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.textBox1.Text = html;
            form4.textBox2.Text = css;
            form4.Show();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                button4.Enabled = false;
                focusBgColor = "\r\n   background-color: transparent;";
                label26.BackColor = Color.FromArgb(32, 32, 32);
            }
            else if (checkBox6.Checked == false)
            {
                button4.Enabled = true;
            }
        }
    }
}

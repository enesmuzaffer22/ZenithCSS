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
    public partial class Form3 : Form
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

        string hoverBgColor = "";
        string hoverTextColor = "";
        string hoverBorderColor = "";
        string hoverTransition = "";

        string activeBgColor = "";
        string activeTextColor = "";
        string activeBorderColor = "";
        string activeTransition = "";

        string linkCSS = "";
        string linkHoverCSS = "";
        string linkActiveCSS = "";
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
            string content = "a {\r\n    text-decoration: none;\r\n    border-left: 2px solid white;\r\n    border-bottom: 2px solid white;\r\n    border-right: 2px solid white;\r\n    border-top: 2px solid white;\r\n    padding: 14px 28px;\r\n    background-color: transparent;\r\n    color: white;\r\n    font-family: sans-serif;\r\n    font-size: 20px;\r\n}\r\n\r\na:hover{\r\n    color: black;\r\n    background-color: white;\r\n    transition: 0.3s;\r\n    border-color: white;\r\n}\r\n\r\na:active{\r\n    color: black;\r\n    background-color: #DDDDDD;\r\n    transition: 0.3s;\r\n    border-color: #DDDDDD;\r\n}";

            try
            {
                File.WriteAllText(filePath, content);
                MessageBox.Show("CSS başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

            textColor = "\r\n   color: white;";
            bgColor = "\r\n   background-color: transparent;";
            borderColor = "rgb(255, 255, 255)";
            hoverBgColor = "\r\n   background-color: white;";
            hoverBorderColor = "rgb(255, 255, 255)";
            hoverTextColor = "\r\n   color: black;";
            activeBgColor = "\r\n   background-color: #DDDDDD;";
            activeTextColor = "\r\n   color: black;";
            activeBorderColor = "rgb(221, 221, 221)";
            borderBottom = "\r\n   border-bottom: 2px solid white;";
            borderTop = "\r\n   border-top: 2px solid white;";
            borderLeft = "\r\n   border-left: 2px solid white;";
            borderRight = "\r\n   border-right: 2px solid white;";

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
            string content = "<link rel=\"stylesheet\" href=\"style.css\">\r\n<link rel=\"stylesheet\" href=\"body.css\">\r\n<a href=\"\">Click Me</a>";

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

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
                label22.BackColor = selectedColor;
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
                button7.Enabled = false;
                textBox6.Enabled = false;
                borderTop = "";
                borderRight = "";
                borderBottom = "";
                borderLeft = "";
                borderColor = "";
                hoverBorderColor = "";
                activeBorderColor = "";
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
                button7.Enabled = true;
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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                button4.Enabled = false;
                hoverBgColor = "\r\n   background-color: transparent;";
                label26.BackColor = Color.FromArgb(32, 32, 32);
            }
            else if (checkBox6.Checked == false)
            {
                button4.Enabled = true;
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
                hoverBgColor = "\r\n   background-color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
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
                hoverTextColor = "\r\n   color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
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
                hoverBorderColor = "rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label25.BackColor = selectedColor;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                activeBgColor = "\r\n   background-color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label27.BackColor = selectedColor;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                button9.Enabled = false;
                activeBgColor = "\r\n   background-color: transparent;";
                label27.BackColor = Color.FromArgb(32, 32, 32);
            }
            else if (checkBox7.Checked == false)
            {
                button9.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                activeTextColor = "\r\n   color: rgb(" + selectedColor.R + ", " + selectedColor.G + ", " + selectedColor.B + ");";
                label28.BackColor = selectedColor;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                activeBorderColor = "rgb(" + selectedColor.R + ", " + selectedColor.G + ", "+ selectedColor.B + ");";
                label29.BackColor = selectedColor;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            padding = "\r\n   padding: " + textBox4.Text + "px " + textBox1.Text + "px " + textBox2.Text + "px " + textBox3.Text + "px;";
            fontStyle = "\r\n   font-family: " + "\"" + comboBox1.Text + "\", sans-serif;";
            fontSize = "\r\n   font-size: " + textBox5.Text + "px;";

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

            hoverTransition = "\r\n   transition: " + textBox7.Text + "s;";

            activeTransition = "\r\n   transition: " + textBox12.Text + "s;";

            linkCSS = "a{" + "\r\n   text-decoration: none;" + padding + fontStyle + fontSize + borderTop + borderRight + borderBottom + borderLeft + borderRadius + bgColor + textColor + "\r\n}";
            linkHoverCSS = "a:hover{" + hoverBgColor + hoverTextColor + hoverTransition + "\r\n   border-color: " + hoverBorderColor + "\r\n}";
            linkActiveCSS = "a:active{" + activeBgColor + activeTextColor + activeTransition + "\r\n   border-color: " + activeBorderColor + "\r\n}";
            css = linkCSS + "\r\n\r\n" + linkHoverCSS + "\r\n\r\n" + linkActiveCSS;

            writeCSS();
            writeHTML();

            webView21.Reload();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                borderLeft = "";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                borderBottom = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                borderRight = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                borderTop = "";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.textBox1.Text = html;
            form4.textBox2.Text = css;
            form4.Show();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SampColorPicker
{
    public class MainForm : Form
    {
        private Label labelColor;
        private Panel panelColor;
        private Button buttonCopy;
        private ColorDialog colorDialog;

        public MainForm()
        {
            this.Text = "SampColorPicker";
            this.ClientSize = new Size(320, 240);

            this.labelColor = new Label();
            this.labelColor.Location = new Point(16, 16);
            this.labelColor.AutoSize = true;
            this.labelColor.Text = "Color seleccionado:";
            this.Controls.Add(this.labelColor);

            this.panelColor = new Panel();
            this.panelColor.Location = new Point(16, 40);
            this.panelColor.Size = new Size(60, 60);
            this.panelColor.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.panelColor);

            this.buttonCopy = new Button();
            this.buttonCopy.Location = new Point(16, 112);
            this.buttonCopy.Size = new Size(128, 32);
            this.buttonCopy.Text = "Copiar código";
            this.buttonCopy.Click += new EventHandler(this.OnButtonCopyClick);
            this.Controls.Add(this.buttonCopy);

            this.colorDialog = new ColorDialog();
            this.colorDialog.FullOpen = true;

            this.CenterToScreen();
        }

        private void OnButtonCopyClick(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = this.colorDialog.Color;
                string hexColor = string.Format("0x{0:X2}{1:X2}{2:X2}", selectedColor.R, selectedColor.G, selectedColor.B);
                Clipboard.SetText(hexColor);

                this.panelColor.BackColor = selectedColor;
                this.labelColor.Text = "Color seleccionado: " + hexColor;
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

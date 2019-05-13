using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Assingment4C_Reinard_Serfontein_25865234
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gHook.hook();
        }

        GlobalKeyboardHook gHook;

        private void Form1_Load(object sender, EventArgs e)
        {
            gHook = new GlobalKeyboardHook(); // Create a new GlobalKeyboardHook
                                              // Declare a KeyDown Event

            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            // Add the keys you want to hook to the HookedKeys list
            foreach (Keys key in Enum.GetValues(typeof(Keys)))

            gHook.HookedKeys.Add(key);
        }

        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text += ((char)e.KeyValue).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gHook.unhook();
        }

        StreamWriter outputFile;

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFile = File.CreateText(saveFileDialog1.FileName);
          
                outputFile.WriteLine(textBox1.Text);
                
                outputFile.Close();

                MessageBox.Show("Data has being copied over to text file");
            }
        }
    }
}

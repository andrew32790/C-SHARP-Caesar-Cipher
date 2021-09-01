using System;
using System.Drawing;
using System.Windows.Forms;

namespace Caesar_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            numericUpDown1.Maximum = int.MaxValue;
        }

        string inputText = string.Empty;
        string textDecrypt = string.Empty;
        string usedKey = string.Empty;
        int Ckey = 0;

        //Main cypher 
        public static char cipher(char inputC, int key)
        {
            if (!char.IsLetter(inputC))
            {
                return inputC;
            }

            char c =char.IsUpper(inputC)?'A':'a';
            return (char)((((inputC+key)-c)%26)+c);
        }
        //Encryption 
        public static string Encrypt(string input, int key)
        {
            string result = string.Empty;
            foreach(char inputC in input)
            {
                result += cipher(inputC, key);
            }
            return result;
        }

        //Decryption
        public static string Decrypt(string input,int key)
        {
            return Encrypt(input,26-key);
        }

        //Input Text
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputText = textBox1.Text;
            textDecrypt = inputText;
            string count = textBox1.Text;
            label6.Text = (count.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length).ToString();
            
        }

        //Key
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Ckey = (int)numericUpDown1.Value;
             usedKey= Convert.ToString(Ckey);
            
            string title = "Key Value";
            string info = "The value for the Key must be equal or lower than 26";
            
            if (Ckey >26)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        //Encrypt Button
        private void button1_Click(object sender, EventArgs e)
        {
            
            string cipherText = Encrypt(inputText, Ckey);
            textBox2.Text = cipherText;
            label10.Text = usedKey;
        }

        //Decrypt Button
        private void button2_Click(object sender, EventArgs e)
        {
            string encryptedText = Decrypt(textDecrypt, Ckey);
            textBox2.Text = encryptedText;
        }

        //Reset fields and key
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            numericUpDown1.Value = 1;
            label10.Text = "1";
        }

        //Guide Button
        private void button5_Click(object sender, EventArgs e)
        {
            string title = "How to use...";
            string info = "To use the Caesar Cipher you must input some text into the upper field and then choose a Key value(The Key can only be a number!). After this press the Encrypt button to change the text(Only letters are encrypted!). If you want to reverse the encryption, input the enrcypted text into the upper field, enter the Key used for encryption and then press the Decrypt button.(If the text is not decrypted the Key is invalid!)";
            MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //About Button
        private void button4_Click(object sender, EventArgs e)
        {
            string title = "Caesar Cihper";
            string info = "In cryptography, a Caesar cipher, also known as Caesar's cipher, the shift cipher, Caesar's code or Caesar shift, is one of the simplest and most widely known encryption techniques. It is a type of substitution cipher in which each letter in the plaintext is replaced by a letter some fixed number of positions down the alphabet. For example, with a left shift of 3, D would be replaced by A, E would become B, and so on. The method is named after Julius Caesar, who used it in his private correspondence.";
            MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Reset Key Button
        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            label10.Text = "1";
        }
        //Reset Fields Button
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        //Form Free Move
        Point lastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //???
        private void label7_Click(object sender, EventArgs e)
        {
            string title = "???";
            string info = "Et tu, Brute?";
            MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}

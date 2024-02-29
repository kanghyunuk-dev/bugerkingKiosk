using OrderForm;
using System;
using System.Windows.Forms;

namespace projecttest
{
    public partial class Form1 : Form
    {
        private Main_form main_Form;
        private string paymentAmount;
        public Form1(Main_form main_Form)
        {
            InitializeComponent();
            this.main_Form = new Main_form();

            main_Form.Update_Total_Price();
            textBox1.Text = main_Form.Lb_Total_Price_P;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = textBox1.Text;
            
            if (!string.IsNullOrWhiteSpace(userInput)) 
            {
                paymentAmount = userInput; 
                OpenPaymentForm();
            }
            else
            {  MessageBox.Show("금액을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        }
        private void OpenPaymentForm()
        {
            Form2 form2 = new Form2(paymentAmount, this);
            form2.FormClosed += Form2_FormClosed; 
            form2.Show();
        }

       
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetAmount();
        }

       
        public void ResetAmount()
        {
            paymentAmount = ""; 
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

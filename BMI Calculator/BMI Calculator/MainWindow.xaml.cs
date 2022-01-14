using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMI_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class Customer
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string phoneNumber { get; set; }
            public int heightInches { get; set; }
            public int weightLbs { get; set; }
            public int custBMI { get; set; }
            public string statusTitle { get; set; }
        }



        private void Exit_btn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_btn(object sender, RoutedEventArgs e)
        {
            First_Name.Text = "";
            Last_Name.Text = "";
            Phone_num.Text = "";
            Height.Text = "";
            Weight.Text = "";
            Message.Text = "Message: ";
            Bmi_Result.Text = "Bmi Result:";
        }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer1 = new Customer();
            customer1.firstName = First_Name.Text;
            customer1.lastName = Last_Name.Text;
            customer1.phoneNumber = Phone_num.Text;

            int currentWeight = 0;
            int currentHeight = 0;
            Int32.TryParse(Weight.Text, out currentWeight);
            Int32.TryParse(Height.Text, out currentHeight);
            customer1.weightLbs = currentWeight;
            customer1.heightInches = currentHeight;

            int bmi;
            bmi = 703 * currentWeight / (customer1.heightInches * customer1.heightInches);
            customer1.custBMI = bmi;

            string yourBMIStatus = "NA";
            customer1.statusTitle = yourBMIStatus;

            //  MessageBox.Show($"The Customer's name is {customer1.firstName} {customer1.lastName} and they can be reached at {customer1.phoneNumber}. " +
            //    $"They are {customer1.heightInches} inches tall. Their weight is {customer1.weightLbs}. Their BMI is {bmi}");

            if (bmi < 18.5)
            {
                Message.Text = "According to CDC.gov BMI Calculator you are underweight.";
                customer1.statusTitle = "Underweight";
            }
            if (bmi < 24.9)
            {
                Message.Text = "According to CDC.gov BMI Calculator you are Normal.";
                customer1.statusTitle = "Normal";
            }
            if (bmi < 29.9)
            {
                Message.Text = "According to CDC.gov BMI Calculator you are overweight.";
                customer1.statusTitle = "overweight";
            }
            else
            {
                Message.Text = "According to CDC.gov BMI Calculator you are Obese.";
                customer1.statusTitle = "Obese";
            }
            Bmi_Result.Text = $"{bmi}";


        }
    }
}
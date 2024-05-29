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

namespace WpfRelearnCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name, subject, possessive;
        int age = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        //First validation, then display text.
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            int validationError = 3;
            tbxInfo.Text = "";
            while (validationError != 0)
            {
                VerifyName(ref validationError);
                VerifyAge(ref validationError);
                VerifyGender(ref validationError);
                break;
            }
            if (validationError == 0) tbxInfo.Text = $"{possessive} name is {name}. {subject} {age} Year(s) old";
        }
        //Validating name
        private void VerifyName(ref int error)
        {
            if (txtName.Text == "") { tbxInfo.Text += "You have to put your name! \n"; }
            else { name = txtName.Text; error--; }
        }
        //Validating gender
        private void VerifyGender(ref int error)
        {
            string[,] pronouns = { { "He is", "His" }, { "She is", "Her" }, { "They are", "Their" } };
            if (btnMale.IsChecked == true)
            {
                subject = pronouns[0, 0];
                possessive = pronouns[0, 1];
                error--;

            }
            else if (btnFemale.IsChecked == true)
            {
                subject = pronouns[1, 0];
                possessive = pronouns[1, 1];
                error--;

            }
            else if (btnTrans.IsChecked == true)
            {
                subject = pronouns[2, 0];
                possessive = pronouns[2, 1];
                error--;

            }
            else 
            { 
                tbxInfo.Text += "You have to put your gender! \n";
            }
        }
        //Validating age
        private void VerifyAge(ref int error)
        {
            if (datBirthdate.SelectedDate.HasValue == true) { age = VerifyAgeInYears(datBirthdate.SelectedDate.Value); error--; }
            else { tbxInfo.Text += "You have to put your age! \n"; }
        }
        private int VerifyAgeInYears(DateTime bday)
        {
            // Het slaat de dag van vandaag
            DateTime now = DateTime.Today;
            // Reken het leeftijd
            int ageCalc = now.Year - bday.Year;
            if (bday.AddYears(ageCalc) > now) ageCalc--;
            return ageCalc;
        }
        // Bron: https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday?page=2&tab=scoredesc#tab-top
    }
}

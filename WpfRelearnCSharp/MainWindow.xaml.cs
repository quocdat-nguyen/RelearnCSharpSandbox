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
        string name, subject, possessive, edu, message;
        int age = 0;
        List<string> studyLists = new List<string> { "Art", "Technology", "Communication", "Pharmacy", "Economy", "Health" };
        

        public MainWindow()
        {
            InitializeComponent();
            cmbListStudy.ItemsSource = studyLists;
        }
        //First validation, then display text.
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            int validationError = 4;
            tbxInfo.Text = "";
            while (validationError != 0)
            {
                VerifyName(ref validationError);
                VerifyAge(ref validationError);
                VerifyLeapYear(datBirthdate.SelectedDate.Value.Year);
                VerifyGender(ref validationError);
                VerifyStudy(ref validationError);
                break;
            }
            if (validationError == 0) tbxInfo.Text = $"{possessive} name is {name}. {subject} {age} Year(s) old. {possessive} education is {edu}, {message}.";
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
            if (datBirthdate.SelectedDate.HasValue == true) { 
                age = VerifyAgeInYears(datBirthdate.SelectedDate.Value);
                error--; 
            }
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
        //VerifyStudy
        private void VerifyStudy(ref int error)
        {
            switch (cmbListStudy.SelectedIndex)
            {
                case 0: 
                    edu = cmbListStudy.SelectedItem.ToString(); error--; break;
                case 1:
                    edu = cmbListStudy.SelectedItem.ToString(); error--; break;
                case 2:
                    edu = cmbListStudy.SelectedItem.ToString(); error--; break;
                case 3:
                    edu = cmbListStudy.SelectedItem.ToString(); error--; break;
                case 4:
                    edu = cmbListStudy.SelectedItem.ToString(); error--; break;
                case 5:
                    edu = cmbListStudy.SelectedItem.ToString(); error--; break;
                default: tbxInfo.Text += "Select education! \n";
                    break;
            }
        }

        private void VerifyLeapYear(int leapYear)
        {
            
            if ((leapYear % 4 == 0 && leapYear % 100 != 0) || leapYear % 400 == 0)
            {
                message += "It is leapyear";
            }
            else message += "It isn't leapyear";
        }
        // Bron: https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday?page=2&tab=scoredesc#tab-top
        //       https://www.sanfoundry.com/csharp-program-check-leap-year/
    }
}

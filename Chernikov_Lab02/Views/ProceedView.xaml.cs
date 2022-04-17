using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Chernikov_Lab02.Models;

namespace Chernikov_Lab02.Views
{
    /// <summary>
    /// Логика взаимодействия для ProceedView.xaml
    /// </summary>
    public partial class ProceedView : UserControl
    {
    
        public ProceedView()
        {
            InitializeComponent();
            BProceed.IsEnabled = false;
        }

        private async void Proceed_Click(object sender, RoutedEventArgs e)
        {
            var PersonClass = new Person();
            var selectedDate = DatePicker1.SelectedDate.Value.Date;
            var today = DateTime.Today;
            var month = DatePicker1.SelectedDate.Value.Month;
            var day = DatePicker1.SelectedDate.Value.Day;
            var year = DatePicker1.SelectedDate.Value.Year;
            var age = today.Year - year;
            

            if (DatePicker1.SelectedDate.Value.Date > today.AddYears(-age)) age--;

            if (age <= 0 || age >= 135) // Checking if user's age is between 0 and 135
            {
                MessageBox.Show("Your age is incorrect, pleasy try again");
                FirstNameTextBlock.Text = "";
                LastNameTextBlock.Text = "";
                EmailTextBlock.Text = "";
                BirthdateTextBlock.Text = "";
                isAdultTextBlock.Text = "";
                sunSignTextBlock.Text = "";
                chZodiacSignTextBlock.Text = "";
                isBirthdayTextBlock.Text = "";
            }

            else
            {
                if (day == today.Day && month == today.Month)
                {
                    if (age == 1)
                    {
                        MessageBox.Show("Happy Birthday, you're now " + age.ToString() + " year old!");
                    }
                    else
                    {
                        MessageBox.Show("Happy Birthday, you're now " + age.ToString() + " years old!");
                    }

                }
                PersonClass._firstName = TbName.Text;
                PersonClass._lastName = TbSurname.Text;
                PersonClass._email = TbEmail.Text;
                PersonClass._birthdate = selectedDate;

                FirstNameTextBlock.Text = "Your name is : " + PersonClass.FirstName;
                LastNameTextBlock.Text = "Your surname is : " + PersonClass.LastName;
                EmailTextBlock.Text = "Your email is : " + PersonClass.Email;
                BirthdateTextBlock.Text = "Your birthdate is : " + PersonClass.Birthdate;

                if (await Task.Run(() => PersonClass.isAdult(selectedDate)))
                {
                    isAdultTextBlock.Text = "You are an adult";
                }
                else
                {
                    isAdultTextBlock.Text = "You are not an adult";
                }

                sunSignTextBlock.Text = await Task.Run(() => "Your sun sign is : " + PersonClass.sunSign(selectedDate));
                chZodiacSignTextBlock.Text = await Task.Run(() => "Your chinese sign is : " + PersonClass.chineseSign(selectedDate));

                if ( await Task.Run(() => PersonClass.isBirthday(selectedDate)))
                {
                    isBirthdayTextBlock.Text = "Today is your birthday";
                }
                else
                {
                    isBirthdayTextBlock.Text = "Today is not your birthday";
                }
            }
        }

        private void Input_Changed(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbName.Text) || String.IsNullOrWhiteSpace(TbSurname.Text) || String.IsNullOrWhiteSpace(TbEmail.Text))
            {
                BProceed.IsEnabled = false;
            }

            else
            {
                BProceed.IsEnabled = true;
            }

        }
    }
}

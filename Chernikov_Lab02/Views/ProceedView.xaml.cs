using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Chernikov_Lab02.Models;
using Chernikov_Lab02.CustomExceptions;
using System.Net.Mail;

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


            if (DatePicker1.SelectedDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }
            try
            {

                if (age <= 0)
                {
                    throw new NotBornYetException("Incorrect Data! You are not born yet!");
                }
                else if (age >= 135)
                {
                    throw new TooOldToBeAliveException("Incorrect Data! You are already dead!");
                }


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


                try
                {
                    MailAddress Address = new(PersonClass._email);

                }
                catch (FormatException)
                {
                    throw new InvalidEmailException("Incorrect Data! Invalid email");

                }


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

                if (await Task.Run(() => PersonClass.isBirthday(selectedDate)))
                {
                    isBirthdayTextBlock.Text = "Today is your birthday";
                }
                else
                {
                    isBirthdayTextBlock.Text = "Today is not your birthday";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

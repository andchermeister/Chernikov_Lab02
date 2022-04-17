using System;

namespace Chernikov_Lab02.Models
{
    internal class Person
    {
        #region Fields
        public string _firstName;
        public string _lastName;
        public string _email;
        public DateTime _birthdate;
        public readonly bool _isAdult;
        public readonly string _sunSign;
        public readonly string _chineseSign;
        public readonly bool _isBirthday;
        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }

        public string SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }
        #endregion

        internal Person(string FirstName, string LastName, string Email, DateTime Birthdate)
        {
            _firstName = FirstName;
            _lastName = LastName;
            _email = Email;
            _birthdate = Birthdate;
            _isAdult = isAdult(_birthdate);
            _sunSign = sunSign(_birthdate);
            _chineseSign = chineseSign(_birthdate);
            _isBirthday = isBirthday(_birthdate);
        }

        public Person(string FirstName, string LastName, string Email)
        {
            _firstName = FirstName;
            _lastName = LastName;
            _email = Email;
            _isAdult = isAdult(_birthdate);
            _sunSign = sunSign(_birthdate);
            _chineseSign = chineseSign(_birthdate);
            _isBirthday = isBirthday(_birthdate);
        }

        public Person()
        {
            _firstName = "";
            _lastName = "";
            _email = "";
            _birthdate = DateTime.Today;
            _isAdult = isAdult(_birthdate);
            _sunSign = sunSign(_birthdate);
            _chineseSign = chineseSign(_birthdate);
            _isBirthday = isBirthday(_birthdate);
        }

        public bool isAdult(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;

            if(age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isBirthday(DateTime dateOfBirth)
        {
            if(dateOfBirth.Day == DateTime.Today.Day && dateOfBirth.Month == DateTime.Today.Month)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        public string sunSign(DateTime dateOfBirth)
        {
            var day = dateOfBirth.Day;
            var month = dateOfBirth.Month;

            if ((month == 12 && day >= 22) || (month == 01 && day <= 19))
            {
                return "Capricorn";
            }

            else if ((month == 01 && day >= 20) || (month == 02 && day <= 17))
            {
                return "Aquarius";
            }

            else if ((month == 02 && day >= 18) || (month == 03 && day <= 19))
            {
                return "Pisces";
            }

            else if ((month == 03 && day >= 20) || (month == 04 && day <= 19))
            {
                return "Aries";
            }

            else if ((month == 04 && day >= 20) || (month == 05 && day <= 20))
            {
                return "Taurus";
            }

            else if ((month == 05 && day >= 21) || (month == 06 && day <= 20))
            {
                return "Gemini";
            }

            else if ((month == 06 && day >= 21) || (month == 07 && day <= 22))
            {
                return "Cancer";
            }

            else if ((month == 07 && day >= 23) || (month == 08 && day <= 22))
            {
                return "Leo";
            }

            else if ((month == 08 && day >= 23) || (month == 09 && day <= 22))
            {
                return "Virgo";
            }

            else if ((month == 09 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }

            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }

            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }

            else
            {
                return "";
            }
        }

        public string chineseSign(DateTime dateOfBirth)
        {
            var ch_zodiacNum = (dateOfBirth.Year - 1888) % 12;
            if (ch_zodiacNum == 0)
            {
                return "Rat";
            }
            else if (ch_zodiacNum == 1)
            {
                return "Ox";
            }
            else if (ch_zodiacNum == 2)
            {
                return "Tiger"; 
            }
            else if (ch_zodiacNum == 3)
            {
                return "Rabbit";
            }
            else if (ch_zodiacNum == 4)
            {
                return "Dragon";
            }
            else if (ch_zodiacNum == 5)
            {
                return "Snake";
            }
            else if (ch_zodiacNum == 6)
            {
                return "Horse";
            }
            else if (ch_zodiacNum == 7)
            {
                return "Goat";    
            }
            else if (ch_zodiacNum == 8)
            {
                return "Monkey";
            }
            else if (ch_zodiacNum == 9)
            {
                return "Rooster";
            }
            else if (ch_zodiacNum == 10)
            {
                return "Dog";
            }
            else if (ch_zodiacNum == 11)
            {
                return "Pig";
            }
            else
            {
                return "";
            }
        
        }
    }
}

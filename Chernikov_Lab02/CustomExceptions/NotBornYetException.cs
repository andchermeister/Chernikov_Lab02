using System;

namespace Chernikov_Lab02.CustomExceptions
{
    class NotBornYetException : Exception
    {
        public NotBornYetException(string message)
            : base(message)
        {

        }
    }
}

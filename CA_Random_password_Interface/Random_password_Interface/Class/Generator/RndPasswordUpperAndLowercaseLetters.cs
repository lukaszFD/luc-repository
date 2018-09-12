using System;
using System.Text;
using Random_password_Interface.Interface;

namespace Random_password_Interface.Class.Generator
{
    class RndPasswordUpperAndLowercaseLetters : IGenerator
    {
        public string Generator()
        {
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "w", "x", "y", "z", "ś", "ć", "ń", "ż", "ź", "q", "ą" };

            Random rnd = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 5; i++)
                stringBuilder.Append(letters[rnd.Next(letters.Length)] + letters[rnd.Next(letters.Length)].ToUpper() + letters[rnd.Next(letters.Length)] + letters[rnd.Next(letters.Length)].ToUpper());
            return Convert.ToString(stringBuilder);
        }
    }
}

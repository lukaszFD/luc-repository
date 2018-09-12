using System;
using System.Text;
using Random_password_Interface.Interface;

namespace Random_password_Interface.Class.Generator
{
    class RndPasswordManyDifferentCharacters : IGenerator
    {
        public string Generator()
        {
            string[] specialCharacters = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "=", "-", "<", ">", "?", "/", "[", "]", "{", "}", "|" };
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "w", "x", "y", "z", "ś", "ć", "ń", "ż", "ź", "q", "ą" };
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Random rnd = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 5; i++)
                stringBuilder.Append(letters[rnd.Next(letters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)] + letters[rnd.Next(letters.Length)].ToUpper() + numbers[rnd.Next(numbers.Length)]);
            return Convert.ToString(stringBuilder);
        }
    }
}

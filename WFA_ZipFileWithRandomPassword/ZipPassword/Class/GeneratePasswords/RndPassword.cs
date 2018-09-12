using System;
using System.Text;

namespace ZipPassword.Class.GeneratePasswords
{
    class RndPassword
    {
        private string[] specialCharacters = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "=", "-", "<", ">", "?", "/", "[", "]", "{", "}", "|" };
        private string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "w", "x", "y", "z", "ś", "ć", "ń", "ż", "ź", "q", "ą" };
        private int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
       
        Random rnd = new Random();
        StringBuilder stringBuilder = new StringBuilder();

        public string PasswordWithManyDifferentCharacters(int precision)
        {
            for (int i = 0; i < precision; i++)
                stringBuilder.Append(letters[rnd.Next(letters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)] + letters[rnd.Next(letters.Length)].ToUpper() + numbers[rnd.Next(numbers.Length)]);
            return Convert.ToString(stringBuilder);
        }

        public string Numbers(int precision)
        {
            for (int i = 0; i < precision; i++)
                stringBuilder.Append(numbers[rnd.Next(numbers.Length)] + numbers[rnd.Next(numbers.Length)] + numbers[rnd.Next(numbers.Length)] );
            return Convert.ToString(stringBuilder);
        }

        public string SpecialCharacters(int precision)
        {
            for (int i = 0; i < precision; i++)
                stringBuilder.Append(specialCharacters[rnd.Next(specialCharacters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)]);
            return Convert.ToString(stringBuilder);
        }

        public string UpperAndLower(int precision)
        {
            for (int i = 0; i < precision; i++)
                stringBuilder.Append(letters[rnd.Next(letters.Length)] + letters[rnd.Next(letters.Length)].ToUpper() + letters[rnd.Next(letters.Length)] + "-" + letters[rnd.Next(letters.Length)].ToUpper());
            return Convert.ToString(stringBuilder);
        }
    }
}

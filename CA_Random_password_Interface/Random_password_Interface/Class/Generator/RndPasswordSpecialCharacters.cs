using System;
using System.Text;
using Random_password_Interface.Interface;

namespace Random_password_Interface.Class.Generator
{
    class RndPasswordSpecialCharacters : IGenerator
    {
        public string Generator()
        {
            string[] specialCharacters = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "=", "-", "<", ">", "?", "/", "[", "]", "{", "}", "|" };
           
            Random rnd = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 5; i++)
                stringBuilder.Append(specialCharacters[rnd.Next(specialCharacters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)] + specialCharacters[rnd.Next(specialCharacters.Length)]);
            return Convert.ToString(stringBuilder);
        }
    }
}

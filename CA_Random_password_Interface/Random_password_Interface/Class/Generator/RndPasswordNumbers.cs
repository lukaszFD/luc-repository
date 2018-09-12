using System;
using System.Text;
using Random_password_Interface.Interface;

namespace Random_password_Interface.Class.Generator
{
    class RndPasswordNumbers : IGenerator
    {
        public string Generator()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Random rnd = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 5; i++)
                stringBuilder.Append(numbers[rnd.Next(numbers.Length)] + numbers[rnd.Next(numbers.Length)] + numbers[rnd.Next(numbers.Length)] + numbers[rnd.Next(numbers.Length)] + "-" + numbers[rnd.Next(numbers.Length)]);
            return Convert.ToString(stringBuilder);
        }
    }
}

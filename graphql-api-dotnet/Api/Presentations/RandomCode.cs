using System;

namespace Api.Presentations
{
    public class RandomCode
    {
        private static Random random = new Random();

        public static string Get()
        {
            return random.Next(100000, 999999).ToString();
        }
    }
}
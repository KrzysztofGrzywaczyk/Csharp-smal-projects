﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz_algorithm
{
    public class FizzBuzz
    {
        public static string FizzBuzzMethod(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";
            if (number % 3 == 0) 
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";
            else
                return number.ToString();

        }
    }
}

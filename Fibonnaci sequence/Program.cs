using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

long first = 0;
long second = 1;
long result;
int number;
bool validate;

do
{
    Console.Clear();
    Console.WriteLine("Put the number of occurrences within the progression :");
    validate = int.TryParse(Console.ReadLine(), out number);
}
while (!validate);

for (long i = 0; i < number; i++)
{
    result = first + second;
    Console.WriteLine(result);
    first = second;
    second = result;
}







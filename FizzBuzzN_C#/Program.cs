using System;

namespace FizzBuzz2
{
   
  // class (reference type), struct (value type), interface (reference type), enum (value type)
  internal class Fizzy
  {
    /*
      FizzBuzz Extravaganza
      a user should be able to enter the starting and ending count
      a user should be able to enter these values in any order
      a user should be able to get the number of times fizz, buzz and fizzbuzz appear
      a user should be able to set new values for fizz, buzz and fizzbuzz
    */
    private string _fizz = "fizz";
    private string _buzz = "buzz";
    private string _fizzbuzz = "fizzbuzz";

    public static void Main()
    {
      var f = new Fizzy();

      f.GetEntry();
    }

    private int GetInput()
    {
      var input = Console.ReadLine();

      return int.Parse(input);
    }

    private int GetEndpoint()
    {
      Console.WriteLine("enter number:");
      return GetInput();
    }

    private void GetEntry()
    {
      var endpoint1 = GetEndpoint();
      var endpoint2 = GetEndpoint();

      if (endpoint1 < endpoint2)
      {
        FizzBuzz(endpoint1, endpoint2);
      }
      else
      {
        FizzBuzz(endpoint2, endpoint1);
      }
    }

    private void FizzBuzz(int a, int b)
    {
      for (var i = a; i <= b; i++)
      {
        if (i % 3 == 0 && i % 5 == 0)
        {
          Console.WriteLine(_fizzbuzz);
        }
        else if (i % 3 == 0)
        {
          Console.WriteLine(_fizz);
        }
        else if (i % 5 == 0)
        {
          Console.WriteLine(_buzz);
        }
        else
        {
          Console.WriteLine(i);
        }
      }
    }
  }
}


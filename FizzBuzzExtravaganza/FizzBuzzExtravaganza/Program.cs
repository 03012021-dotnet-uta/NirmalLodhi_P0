using System;


namespace FizzBuzzExtravaganza // scope, prevents name collusion
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
    // declare private variables to store fizz, buzz and fizzbuzz
    private int iFizz =0;
    private int iBuzz=0; 
    private int iFizzBuzz=0;

    public static void Main()
    {
      var f = new Fizzy();

      f.GetEntry();
    }
    //Getting user input
    public string GetInput()
    {
      return Console.ReadLine();
    }
    //getting number for the program
    private int GetEndpoint()
    {
      Console.WriteLine("enter number:");
      var numb = GetInput();
      return int.Parse(numb);
    }
    /* 
    getting values of fizz, buzz and fizzbuzz if user want to replace value of fizz, buzz and fizzbuzz with somethig else like
    replacing fizz with Ram, buzz with Nirmal and fizzbuzz with RamNirmal
    */
    private string GetFizzBuzz( string x )
    {
      Console.WriteLine("Supply the value of "+ x +" : ");  
      return GetInput();
    }
    
    // to know if user want to replace the value of fizz, buzz and fizzbbuzz and then call FizzBuzz method and printing the count of each
    private void GetEntry()
    {
      var endpoint1 = GetEndpoint();
      var endpoint2 = GetEndpoint();
      Console.WriteLine("Do you want to replace the value of Fizz, Buzz and FizzBuzz? Y/N");
      var repval=GetInput();
      if (endpoint1 < endpoint2)
      {
          if (repval=="Y")
          {
            FizzBuzz(endpoint1, endpoint2,repval);      
          }
          else
          {
              FizzBuzz(endpoint1, endpoint2,"N");
          }
      }
      else
      {
          if(repval=="Y")
          {
            FizzBuzz(endpoint2, endpoint1,repval);
          }
          else 
          {
            FizzBuzz(endpoint2, endpoint1,"N");
          }
        
      }
      Console.WriteLine("The number of times "+_fizz+" = "+iFizz);
      Console.WriteLine("The number of times "+_buzz+" = "+iBuzz);
      Console.WriteLine("The number of times "+_fizzbuzz+" = "+iFizzBuzz);
    }
        // the main method to know  if a number is fizz, buzz and fizzbuzz and to calculate the count of each existance of these words
    private void FizzBuzz(int a, int b, string YN)
    {
 
     if (YN=="Y")
     {
     _fizz=GetFizzBuzz("fizz");
     _buzz=GetFizzBuzz("buzz");
     _fizzbuzz=GetFizzBuzz("fizzbuzz");
     }

      for (var i = a; i <= b; i++)
      {
        if (i % 3 == 0 && i % 5 == 0)
        {
          Console.WriteLine(_fizzbuzz);
          iFizzBuzz=iFizzBuzz+1;
        }
        else if (i % 3 == 0)
        {
          Console.WriteLine(_fizz);
          iFizz=iFizz+1;
        }
        else if (i % 5 == 0)
        {
          Console.WriteLine(_buzz);
          iBuzz=iBuzz+1;
        }
        else
        {
          Console.WriteLine(i);
        }
      }

    }
  }
}
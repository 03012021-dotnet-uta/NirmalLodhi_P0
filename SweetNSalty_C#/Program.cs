using System;

namespace SweetnSalty
{
    class Program
    {
        static void Main(string[] args)

        {
     
        Program T1= new Program();
        T1.SweetnSalty();
        }

        public void SweetnSalty()
        {               
            
             int i = 0;
        
        for ( i= 1; i <= 1000; i++)  

{  
        
        if (i % 3 == 0 && i % 5 == 0)  
        {  
            Console.WriteLine("Sweet'nSalty ");  
        }  
        else if (i % 3 == 0)  
        {  
           Console.WriteLine("Sweet ");  
        }  
        else if (i % 5 == 0)  
        {  
           Console.WriteLine("Salty ");  
        }  
        else  
        {  
            Console.WriteLine(i);  

        }  
      if(i%10==0)
      {
     Console.WriteLine();
      
      }
      else 
      Console.WriteLine()


}   
        }

        
        
    }
}

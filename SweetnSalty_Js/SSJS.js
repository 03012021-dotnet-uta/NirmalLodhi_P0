
	    let iSweet =0;
            let iSalty=0; 
            let iSweetnSalty=0;
            let sPrintString='' ;
            
		for (let i = 1; i <= 1000; i++)  
            {  
                    if (i % 3 == 0 && i % 5 == 0)  
                    {  
                        // Checking if number is multiple of both 3 and 5 and print "sweet’nSalty"  
                        iSweetnSalty=iSweetnSalty+1;
                        sPrintString=sPrintString +  ' ' + 'sweet’nsalty' ;
                    }  
                    else if (i % 3 == 0)  
                    {  
                        // Checking if number is multiple of only 3 and print "sweet" 
                        iSweet=iSweet+1;
                        sPrintString=sPrintString +  ' ' + 'sweet' ;
                    }  
                    else if (i % 5 == 0)  
                    {  
                        // Checking if number is multiple of only 5 and print "salty"
                        iSalty=iSalty+1;
                        sPrintString=sPrintString +  ' ' + 'salty';
                    }  
                    else  
                    {  
                        // else print the number itself
                        sPrintString=sPrintString +  ' ' + i ;
                    }  

                    if (i % 10 == 0)  
                    {
                        console.log(sPrintString); 
                        console.log(``); 
                        sPrintString=`` ;
                    }
                 
            }
            
            console.log(`There are total numbers in Sweet group ${iSweet}`); 
            console.log(`There are total numbers in Sweet group ${iSalty}`); 
            console.log(`There are total numbers in Sweet’nSalty group ${iSweetnSalty}`); 
           

                
        

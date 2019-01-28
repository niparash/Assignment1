using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5, b = 15;
            //to call a method that checks and prints all the prime numbers in a given range
            printPrimeNumbers(a, b);

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);


            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);

            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);

            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            Console.ReadKey(true);

            // write your self-reflection here as a comment

        }

        /*
        * x – starting range, integer (int)
        * y – ending range, integer (int)
        * 
        * summary      : This method prints all the prime numbers between x and y
        * For example 5, 25 will print all the prime numbers between 5 and 25 i.e. 
        * 5, 7, 11, 13, 17, 19, 23
        * Tip: Write a method isPrime() to compute if a number is prime or not.
        *
        * returns      : N/A
        * return type  : void
        *
        */

        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                // Write your code here
                //Check if the range ends at 1; in that case there are no prime numbers in given range
                if(y == 1)
                {
                    Console.WriteLine("There are no prime numbers between " + x + " and " + y);
                }
                //if the range does not end at 1; check for all the prime numbers in the range
                else
                {
                    //loop starts at starting point of range and continues until the endpoint of range
                    Console.WriteLine("The prime numbers between " + x + " and " + y + " are: ");
                    for (int i = x; i <= y; i++)
                    {
                        //declare flag to identify prime number. If the number is prime, change the value of flag and exit the condition. 
                        //if flag is 0 then print the prime number
                        int flag = 0;
                        for (int j = 2; j <= i/2; j++)
                        {
                            if (i % j == 0)
                            {
                                flag = 1;
                                break;
                            }
                        }
                         if(flag == 0)
                         {
                            Console.WriteLine(i);
                         }
                    }
                }
                //return;
            }//end of try Method - printPrimeNumbers
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }//end of Method - printPrimeNumbers


        /*This method calcuates factorial for a given value
        *returns: result
        *return type: double
        */
        public static double factorial(int a)
        {
            int n = 1;
            for (int i = 1; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }//end of Method - factorial

        /*
        * para    n – number of terms of the series, integer (int)
        * 
        * summary        : This method computes the series 1/2 – 2!/3 + 3!/4 – 4!/5 --- n     * where ! means factorial, i.e., 4! = 4*3*2*1 = 24. Round off the results to 
        * three decimal places. 
        * Odd terms are all positive whereas even terms are all negative.
        *
        * returns        : result
        * return type    : double
        */

        public static double getSeriesResult(int n)
        {
            double odd, even;
            double result1=0, result2=0;
            try
            {
                // Write your code here
                //loop to add all the odd term products
                Console.WriteLine("Print the series");
                for(int i=1; i<=n; i+=2)
                {
                    odd = factorial(i) / (i+1);
                    result1 += odd;
                }
                //loop to add all the even term products
                for (int i = 2; i <= n; i+=2)
                {
                    even = factorial(i) / (i + 1);
                    result2 += even;
                }
                //returns difference of odd and even terms with a decimal of 3 digits
                return Math.Round(result1-result2,3);
            }//end of try Method - getSeriesResult
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }//end of Method - getSeriesResult

        /*
        * n – non-negative number to be converted, integer (long)
        * 
        * summary: This method converts a number from decimal (base 10) to binary (base 2).
        * Implementation: A number can be converted from decimal to binary in the following   * steps: 1)Divide it by 2. 2)Get the integer quotient for next iteration. 3)Get the   * remainder for binary digit. 4)Repeat the steps until the quotient is equal to 0.
        * For example, binary conversion for 15 is 1111 
        *
        * Follow this link for detail explanation:
        * https://www.rapidtables.com/convert/number/decimal-to-binary.html
        *
        * returns      : integer 
        * return type  : long
        */

        public static long decimalToBinary(long n)
        {
            try
            {
                // Write your code here
                long rem;
                string result = string.Empty;
                Console.WriteLine("Print the decimal to binary");
                //loop until the number is greater than zero upon dividing by 2 in each iteration
                while (n>0)
                {
                    //remainder represents the binary value
                    rem = n % 2;
                    n /= 2;
                    //add the result in form of string because integer will give a summation of the values
                    result = rem.ToString() + result;
                }
                return Convert.ToInt64(result);
            }//end of try Method - decimalToBinary
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }//end of Method - decimalToBinary

        /*
        * n – non-negative number to be converted, integer (long)
* 
* summary: This method converts a number from binary (base 2) to decimal (base 10).
* Implementation: A number can be converted from binary to decimal in the following   * steps: 1)Start from the rightmost bit to the left. 2)Multiply each bit by 2^i where * i starts from 0 and increases by 1 on iteration. 3)Add all the computations for the  * result.
* For example, decimal conversion for 1101 = 1 * 2^3 + 1 * 2^2 + 0 * 2^1 + 1 * 2^0
* = 1*8 + 1*4 + 0*2 + 1*1
* = 8 + 4 + 0 + 1
* = 13
*
* Follow this link for detail explanation:
* https://www.rapidtables.com/convert/number/binary-to-decimal.html
*
* Tip: Write a method to compute 2^n, i.e, 2*2*2*2---n. Call it whenever required. Do * not use Math.Power()
*
* returns      : integer 
* return type  : long
*/


        public static long binaryToDecimal(long n)
        {
            try
            {
                // Write your code here
                int n1 = Convert.ToInt32(n);
                int rem,i=1,power=1,result=0;
                Console.WriteLine("Print the binary to decimal");
                //loop to separate binary digits and multiply each digit with respective power of 2
                for (int j=n1;j>0;j=j/10)
                {
                    rem = j % 10;
                    if (i == 1)
                    {
                        power *= 1;
                    }
                    else
                    {
                        power *= 2;
                    }
                    result = result + (rem * power);
                    i++;
                }
                return result;
            }//end of try Method - binaryToDecimal
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }// end of Method - binaryToDecimal

        /*
* n – number of lines for the pattern, integer (int)
* 
* summary      : This method prints a triangle using *
* For example n = 5 will display the output as: 

    *
   ***
  *****
 *******
*********

*
* returns      : N/A
* return type  : void
*/

        public static void printTriangle(int n)
        {
            try
            {
                // Write your code here

                int num = n - 1,num1;
                Console.WriteLine("Print triangle");
                //loop to add rows of * as per given integer
                for (int i = 1; i <= n; i++)
                {
                    string spaces = new String(' ', num);
                    num1 = ((i-1) * 2) + 1;
                    string pattern = new String('*', num1);
                    Console.WriteLine(spaces + pattern);
                    num--;
                }
            }//end of try Method - printTriangle
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }//end of Method - printTriangle

        /*
* a – array of elements, integer (int)
* 
* summary      : This method computes the frequency of each element in the array
* For example a = {1,2,3,2,2,1,3,2} will display the output as: 

Number	Frequency
1	2
2	4
3	2

* returns      : N/A
* return type  : void
*/

        public static void computeFrequency(int[] a)
        {
            try
            {
                // Write your code here
                
                int len = a.Length;
                int ctr;
                //add new array of same length to capture frequency
                int[] freq = new int[len];
                Console.WriteLine("Print the frequency of each element");
                //loop to initialize new array
                for (int i = 0; i < len; i++)
                {
                    freq[i] = -1;
                }
                //loop to count frequency of each element in the given array and increase the counter and insert in the respective position of new array
                for (int i = 0; i < len; i++)
                {
                    ctr = 1;
                    for (int j = i + 1; j < len; j++)
                    {
                        if (a[i] == a[j])
                        {
                            ctr++;
                            freq[j] = 0;
                        }
                    }
                    if (freq[i] != 0)
                    {
                        freq[i] = ctr;
                    }
                }
                Console.Write("\nThe frequency of all elements of the array : \n");
                Console.WriteLine("Number \t Frequency");
                for (int i = 0; i < len; i++)
                {
                    if (freq[i] != 0)
                    {
                        Console.WriteLine( a[i]+ "\t" +freq[i]);
                    }
                }
            }//end of try Method - computeFrequency
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }

        }//end of Method - computeFrequency
    }//end of class Program
}//end of namespace Assignment1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersToWords
{
    public static class Helper
    {
        enum Single
        {
            ONE = 1,
            TWO = 2,
            THREE = 3,
            FOUR = 4,
            FIVE = 5,
            SIX = 6,
            SEVEN = 7,
            EIGHT = 8,
            NINE = 9,
            TEN = 10,
            ELEVEN = 11,
            TWELVE = 12
        }

        enum Teens
        {
            THIRTEEN = 13,
            FOURTEEN = 14,
            FIFTEEN = 15,
            SIXTEEN = 16,
            SEVENTEEN = 17,
            EIGHTEEN = 18,
            NINETEEN = 19

        }

        enum Tens
        {
            TEN = 1,
            TWENTY = 2,
            THIRTY = 3,
            FOURTY = 4,
            FIFTY = 5,
            SIXTY = 6,
            SEVENTY = 7,
            EIGHTY = 8,
            NINETY = 9
        }

        enum Powers
        {
            HUNDRED = 0,
            THOUSAND = 1,
            MILLION = 2,
            BILLION = 3,
            TRILLION = 4,
            QUADRILLION = 5,
            QUINTILLION = 6
        }
        public static string NumbersToWords(decimal number)
        {
           
            long dollars = (long)number;
            decimal cents = Decimal.Subtract(number, Decimal.Floor(number)) * 100;

            if (dollars == 0)
            {
                if (cents != 0)
                {
                    return "ZERO" +" DOLLARS AND " + GetHundredWord((int)cents) + " CENTS";
                }
                return "ZERO DOLLARS";
            }
            if (dollars == 1)
            {
                if (cents != 0)
                {
                    return ((Single)dollars).ToString() + " DOLLAR AND " + GetHundredWord((int)cents) + " CENTS";
                }
                return ((Single)dollars).ToString() + " DOLLAR";
            }
            if (dollars <= 10)
            {
                if (cents != 0)
                {
                    return ((Single)dollars).ToString() + " DOLLARS AND " + GetHundredWord((int)cents) + " CENTS";
                }
                return ((Single)dollars).ToString() + " DOLLARS";
            }

            string returnWord = "";
            Dictionary<int, long> dict = new Dictionary<int, long>();

            //for each group of 3 add to hundred list starting from the right 
            int magnitude = 0;
            do
            {
                dict.Add(magnitude, dollars % 1000);
                magnitude++;
                dollars /= 1000;
            } while (dollars > 0);
           

            foreach (KeyValuePair<int, long> item in dict)
            {
                //Cast Enum Powers (The orders of magnitude) which correlates to the key

                //If it's in the 'ONES' don't add a power to the returnWord
                if (item.Key < 1 && item.Value > 0)
                {
                    returnWord = " AND " + GetHundredWord(item.Value) + " " + returnWord;
                }
                else
                {
                    //if our number is 0 don't convert to word and ignore
                    if (item.Value != 0)
                    {
                        returnWord = " AND " + GetHundredWord(item.Value) + " " + (Powers)item.Key + returnWord;

                    }
                }
                
            }

            //remove leading "AND"....
            if(returnWord.StartsWith(" AND "))
            {
                returnWord = returnWord.Remove(0, 5);
            }
            //If we have cents
            if(cents != 0) {
                return returnWord.TrimEnd() + " DOLLARS"  + " AND " + GetHundredWord((int)cents) + " CENTS" ;
            }
            return returnWord.TrimEnd() + " DOLLARS";
        }

        private static string GetHundredWord (long number)
        {
            string returnWord = "";
         
            if (number <= 12)
            {
                return ((Single)number).ToString();
            }
            if (number <= 19)
            {
                return ((Teens)number).ToString();
            }
            if (number <= 99)
            {
                //two component number
                long tens = number / 10;
                long single = number % 10;

                returnWord = ((Tens)tens).ToString();
                //if the number is a 'composite' number
                if (single != 0)
                {
                    
                    if (number <= 12)
                    {
                        returnWord =  ((Single)number).ToString();
                    }
                    else if (number <= 19)
                    {
                        returnWord =  ((Teens)number).ToString();
                    }
                    else
                    {
                        returnWord += "-" + ((Single)single).ToString();
                    }
                }
                return  returnWord;
            }
            //three component number
            if (number <= 999)
            {
                //find the hundreds column 
                long hundreds = number / 100;
                long tens = number / 10 % 10;
                long single = number % 10;
                //Make the two digit num
                long twoDigit = tens * 10 + single;
               
                if(twoDigit >= 20)
                {
                    returnWord = ((Single)hundreds).ToString() + " " + Powers.HUNDRED + " AND " + ((Tens)tens).ToString();
                    if (single != 0)
                    {
                        returnWord += "-" + ((Single)single).ToString();
                    }
                    return returnWord;
                }
                else
                {
                    //find teens 
                    returnWord = ((Single)hundreds).ToString() + " " + Powers.HUNDRED;
                    if (twoDigit > 0 && twoDigit <= 12)
                    {
                        return returnWord +=" AND " + ((Single)twoDigit).ToString();
                    }
                    else if (twoDigit == 0)
                    {
                        return returnWord;
                    }
                    returnWord += " AND " + ((Teens)twoDigit).ToString();
                }
            }
            return returnWord;
        }       
    }
}

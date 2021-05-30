using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest
{
    public static class WebConstant
    {
        public static string SessionCart = "TicketShoppingCartSession";
        public static double GetPriceBasedOnQuantity(double quantity,double price)
        {
            if (quantity<=10)
            {
                return price;
            }
            else
            {
                return  0;
            }
           
        }
        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}

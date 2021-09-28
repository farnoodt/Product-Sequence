using System;
using System.Collections.Generic;

namespace Product_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Li = new List<string>() { "a", "b", "a", "c" , "d","b","c", "d", "c" };
            List<string> Seq = new List<string>() { "a", "b", "c" };
            Console.WriteLine(ProductSequenceUtil(Li,Seq));
        }

        static int ProductSequenceUtil(List<string> Product, List<string> Sequenc)
        {
            int Min = int.MaxValue;
            int temp = int.MaxValue;
            for (int i = Product.Count; i >= Sequenc.Count; i--)
            {
                Product.RemoveAt(Product.Count - 1);
                temp = ProductSequence(Product, Sequenc);
                if (Min > temp && temp != -1)
                    Min = temp;
            }
            return Min == int.MaxValue? -1: Min;
        }
        static int ProductSequence(List<string> Product, List<string> Sequence)
        {
            int start = Product.Count - 1;
            int lastIndex = 0;

            for (int i = Sequence.Count - 1; i >= 0; i--)
            {
                String currPriority = Sequence[i];
                while (start >= 0 && Product[start] != currPriority)
                {
                    //start will point to the index of the first word in the sequence at the end for the sequence loop.
                    start--;
                }
                if (start >= 0 && i == Sequence.Count - 1)
                {
                    //Set the index of the last word in the sequence.
                    lastIndex = start;
                }
            }

            return start < 0 ? -1 : lastIndex - start + 1;
        }

        
    }
}

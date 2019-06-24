using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.MySolution
{
   
    public class TextJustification
    {

        public String find(String[] words, int maxWidth, int index)
        {
            if (index < words.Length)
            {
                String result = "";
                int currentLen = 0;
                int remainLength = maxWidth;
                while (result.Length < maxWidth && index < words.Length)
                {
                    if (remainLength >= words[index].Length + 1)
                    { //remainingLength+1 for space
                        if (!result.Equals(""))
                        {
                            result += "@" + words[index];
                            currentLen = words[index].Length + 1;
                        }
                        else
                        {
                            result += words[index];
                            currentLen = words[index].Length;
                        }
                        remainLength -= currentLen;
                        index++;
                    }
                    else if (remainLength > 0)
                    {
                        if (result.Contains("@") == false)
                        {
                            for (int i = 0; i < remainLength; i++)
                            {
                                result = result + " ";
                            }
                        }
                        else
                        {
                            //go in only if there at least 2 words
                            String[] arr = result.Split("@");
                            int mod = (remainLength % (arr.Length - 1));
                            int splitedSpace = remainLength / (arr.Length - 1);
                            String spaces = " ";
                            for (int i = 0; i < splitedSpace; i++)
                            {
                                spaces = spaces + " ";
                            }
                            String leftmost = spaces;
                            for (int i = 0; i < mod; i++)
                            {
                                leftmost = leftmost + " ";
                            }
                       //     result = regex.Replace("Hello World", "Foo", 1); //result.StartsWith("@", leftmost);

                        //    var newText = regex.Replace("Hello World", "Foo", 1);
                            result = result.Replace("@", spaces);
                        }
                    }
                }
                result = result.Replace("@", " ");
                return result + "\n" + find(words, maxWidth, index);
            }
            else
            {
                return "";
            }
        }

        public static void Run(String[] args)
        {
            TextJustification t = new TextJustification();
            String[] words = { "This", "is", "a", "text", "justification", "problem", "in", "tutorial", "horizon" };
            int maxWidth = 25;
            //System.out.println(t.find(words, maxWidth, 0));
        }
    }
}

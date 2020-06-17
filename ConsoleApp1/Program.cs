using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(FixAngles("<<>>")); // <<>>
            Console.WriteLine(FixAngles("<<<>>")); // <<<>>>
            Console.WriteLine(FixAngles("<<")); // <<>>
            Console.WriteLine(FixAngles(">>")); // <<>>
            Console.WriteLine(FixAngles("<>><<")); // <<>><<>>
        }

        private static string FixAngles(string angles)
        {
            int count = 0;
            string prefix = "";
            string postfix = "";

            // check if opened correctly
            if (angles.StartsWith('>'))
            {
                angles = "<" + angles;
            }

            // check if closed correctly
            if (angles.EndsWith('<'))
            {
                angles += ">";
            }

            foreach (char a in angles)
            {
                if (a == '<') count++;
                if (a == '>') count--;

                if (count == -1)
                {
                    count++;
                    prefix += "<";
                }
            }

            for (int i = 0; i < count; i++)
            {
                postfix += ">";
            }

            angles = prefix + angles + postfix;

            return angles;


        }

        private static string FixAngles_old(string angles)
        {
            Dictionary<char, int> angleCounts = new Dictionary<char, int>();

            // check if opened correctly
            if (angles.StartsWith('>'))
            {
                angles = "<" + angles;
            }

            // check if closed correctly
            if (angles.EndsWith('<'))
            {
                angles += ">";
            }

            foreach (char a in angles)
            {
                if (!angleCounts.ContainsKey(a))
                {
                    angleCounts.Add(a, 0);
                }
                angleCounts[a]++;
            }

            if (angleCounts.Count > 2)
            {
                Exception e = new Exception("Invalid character found");
            }

            while (angleCounts['>'] != angleCounts['<'])
            {
                if (angleCounts['>'] < angleCounts['<'])
                {
                    angles = "<" + angles;
                }

                if (angleCounts['>'] > angleCounts['<'])
                {
                    angles += ">";
                }
            }

            return angles;
        }
    }
}

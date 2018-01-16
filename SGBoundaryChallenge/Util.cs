using System;
using System.Collections.Generic;
using System.Text;

namespace SGBoundaryChallenge
{
    public class Util
    {
        public static bool[,] InputToMatrix(string input)
        {
            string[] ins = input.Split('\n');
            int size = ins.Length;
            bool[,] mtx = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                char[] line = ins[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    if(line[j] == '1')
                    {
                        mtx[i, j] = true;
                    } else
                    {
                        mtx[i, j] = false;
                    }
                }

            }
            return mtx;
        }
    }
}

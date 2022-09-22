using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShellSort
{
    public static void Int_ShellSort(int[] array, int listLenght)
    {
        int i, j, pos, temp;

        pos = 3;

        while (pos > 0)
        {
            for (i = 0; i < listLenght; i++)
            {
                j = i;
                temp = array[i];
                while ((j >= pos) && (array[j - pos] > temp))
                {
                    array[j] = array[j - pos];
                    j = j - pos;
                }
                array[j] = temp;
            }
            if (pos / 2 != 0)
                pos = pos / 2;
            else if (pos == 1)
                pos = 0;
            else
                pos = 1;
        }
    }

    public static void Float_ShellSort(float[] array, int listLenght)
    {
        int i, j, pos;
        float temp;

        pos = 3;

        while (pos > 0)
        {
            for (i = 0; i < listLenght; i++)
            {
                j = i;
                temp = array[i];
                while ((j >= pos) && (array[j - pos] > temp))
                {
                    array[j] = array[j - pos];
                    j = j - pos;
                }
                array[j] = temp;
            }
            if (pos / 2 != 0)
                pos = pos / 2;
            else if (pos == 1)
                pos = 0;
            else
                pos = 1;
        }
    }
}

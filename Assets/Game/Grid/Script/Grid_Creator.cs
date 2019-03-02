using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Creator : MonoBehaviour
{
    int[,] data;

    private int[] lose;

    public int[,] getdata()
    {
        setData();
        return data;
    }
    
    public void print()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(data[i, 0] + "," + data[i, 1] + "," + data[i, 2] + "," + data[i, 3] + "," + data[i, 4] + "," +
                      data[i, 5] + "," + data[i, 6]);
        }
    }

    void setData()
    {
        data = new int[6, 7];
        lose = new[] {0, 2};

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i > 0)
                {
                    int top = data[i - 1, j];

                    if (j > 0)
                    {
                        int left = data[i, j - 1];

                        data[i, j] = key_in(left, top);
                    }
                    else
                    {
                        data[i, j] = key_in(top);
                    }
                }
                else
                {
                    if (j > 0)
                    {
                        int left = data[i, j - 1];

                        data[i, j] = key_in(left);
                    }
                    else
                    {
                        data[i, j] = Random.Range(0, 3);
                    }
                }
            }
        }
    }

    int key_in(params int[] list)
    {
        int value1 = list[0];

        if (value1 == 0)
        {
            if (list.Length == 1)
            {
                return Random.Range(1, 3);
            }
            else
            {
                int value2 = list[1];

                if (value2 == 0)
                    return Random.Range(1, 3);

                if (value2 == 1)
                    return 2;

                if (value2 == 2)
                    return 1;
            }
        }

        if (value1 == 1)
        {
            if (list.Length == 1)
            {
                return lose[Random.Range(0, 2)];
            }
            else
            {
                int value2 = list[1];

                if (value2 == 0)
                    return 2;

                if (value2 == 1)
                    return lose[Random.Range(0, 2)];

                if (value2 == 2)
                    return 0;
            }
        }

        if (value1 == 2)
        {
            if (list.Length == 1)
            {
                return Random.Range(0, 2);
            }
            else
            {
                int value2 = list[1];

                if (value2 == 0)
                    return 1;

                if (value2 == 1)
                    return 0;

                if (value2 == 2)
                    return Random.Range(0, 2);
            }
        }


        return 9;
    }

}

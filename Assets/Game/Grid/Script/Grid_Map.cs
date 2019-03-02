using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Map : MonoBehaviour
{
    private int[,] grid;

    public GameObject greenBlock_two_v;

    public Sprite[] marks;

    public Grid_Line[] grid_lines;

    [SerializeField] private Grid_Creator _gridCreator;

    private void Start()
    {
        grid = new int[6, 7];

        grid = _gridCreator.getdata();
        change();

        for (int i = 0; i < 7; i++)
        {
            Debug.Log(grid[0, i] + " " + grid[1, i] + " " + grid[2, i] + " " + grid[3, i] + " " + grid[4, i] + " " +
                      grid[5, i]);
        }
    }

    void change()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                int type = grid[i, j];

                grid_lines[j].grid_sprite[i].sprite = marks[type];
            }
        }
    }


    public void detector(params int[] value) // [0] 0: 橫的 1: 直的 帶入的是 方塊本身的值
    {
        if (value.Length == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int grid_value = grid[i, j];

                    if (grid_value == value[0])
                    {
                        if (i != 5)
                        {
                            if (grid[i + 1, j] == value[1])
                            {
                                detector_ground(0,2,i,j);
                            }
                        }
                    }
                }
            }
        }
    }

    void detector_ground(params int[] value) //第一格 0:橫 1:直 第二格 0:兩格 1: 三格
    {
        int x = value[2];
        int y = value[3];

        if (value[0] == 0) // 橫的
        {
            for (int i = 0; i < value[1]; i++)
            {
                if (y != 6)
                {
                    if (grid[x + i, y + 1] == 3)
                    {
                        createGreenBlock_v(x, x + 1, y);
                        break;
                    }
                }
                else
                {
                    createGreenBlock_v(x, x + 1, y);
                    break;
                }
            }
        }
        else // 直的
        {
        }
    }

    void createGreenBlock_v(int x1, int x2, int y)
    {
        GameObject greenblock_buffer = Instantiate(greenBlock_two_v);

        float x = grid_lines[y].grid_sprite[x1].transform.position.x +
                  grid_lines[y].grid_sprite[x2].transform.position.x;

        greenblock_buffer.GetComponent<GreenBlock>().key(x1, y, x2, y);
        greenblock_buffer.transform.position = new Vector2(x / 2, grid_lines[y].grid_sprite[x2].transform.position.y);
    }


    public void setExistsBlock(params int[] value)
    {
        grid[value[0], value[1]] = 3;
        grid[value[2], value[3]] = 3;

        if (value.Length == 6)
            grid[value[4], value[5]] = 3;

        for (int i = 0; i < 7; i++)
        {
            Debug.Log(grid[0, i] + " " + grid[1, i] + " " + grid[2, i] + " " + grid[3, i] + " " + grid[4, i] + " " +
                      grid[5, i]);
        }
    }
}
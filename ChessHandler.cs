using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChessHandler : MonoBehaviour
{
    //预制品-白色棋子
    public GameObject whiteChessItem;
    //预制品-青色棋子
    public GameObject emeraldChessItem;

    Vector3 nowPosition;
    Vector3 newWhiteItemPosition = new Vector3(7, 0, 3.2F);
    Vector3 newEmeraldItemPosition = new Vector3(-5, 0, 3.2F);

    static int[,] board = new int[11, 11]; // 棋盘 1:白色棋子 2:青色棋子 0:空格 原点在(4, 4)
    static int count = 1; //棋子计数
    /**
     * 实现的棋子移动时，位置吸附在棋盘格子交点处
     */
    public void absorbItemPosition()
    {
        nowPosition = GetComponent<Renderer>().transform.position;
        nowPosition.z = 3.49F;
        nowPosition.y = Mathf.Round(nowPosition.y);
        nowPosition.x = Mathf.Round(nowPosition.x);
        //将调整后的位置写回到当前棋子的属性
        GetComponent<Renderer>().transform.position = nowPosition;
        if (count % 2 != 0)
        {
            // 青色棋子
            board[(int)(4 - nowPosition.y), (int)(nowPosition.x + 4)] = 2;
            Debug.Log("x+4: " + (int)(nowPosition.x + 4));
            Debug.Log("4-y: " + (int)(4 - nowPosition.y));
            Debug.Log("board[" + (int)(nowPosition.x + 4) + "," + (int)(4 - nowPosition.y) + "] = " + board[(int)(nowPosition.x + 4), (int)(4 - nowPosition.y)]);
        }
        else
        {
            // 白色棋子
            board[(int)(4 - nowPosition.y), (int)(nowPosition.x + 4)] = 1;
        }
        Debug.Log("newPosition.x: " + nowPosition.x + " newPosition.y: " + nowPosition.y + ")");

        string boardContent = "";
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                // 以右对齐的方式格式化每个数字，假设每个单元格宽度为3（包括数字和空格）
                // 可根据实际情况调整宽度
                boardContent += board[i, j].ToString().PadLeft(3);
                // 如果不是最后一列，添加分隔符，这里使用制表符'\t'，也可以根据喜好调整
                if (j < 10) boardContent += " ";
            }
            // 换行
            boardContent += "\n";
        }
        Debug.Log(boardContent);

        // 检查是否有人获胜
        if (CheckWin(board, 1))
        {
            Debug.Log("白方获胜！");
            // 这里可以添加胜利后的处理逻辑
        }
        else if (CheckWin(board, 2))
        {
            Debug.Log("青方获胜！");
            // 这里可以添加胜利后的处理逻辑
        }
    }


    public void generateNewItem()
    {
        if (count % 2 == 0)
        {
            //创建青色棋子
            Instantiate(emeraldChessItem, newEmeraldItemPosition, Quaternion.identity);
        }
        else
        {
            //创建白色棋子
            Instantiate(whiteChessItem, newWhiteItemPosition, Quaternion.identity);
        }
        count = count + 1;
    }
    public bool CheckWin(int[,] board, int player)
    {
        int size = 11; // 棋盘大小为11x11

        // 检查水平方向
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= size - 5; j++) // 确保能检查到连续的5个
            {
                if (board[i, j] == player && board[i, j + 1] == player &&
                    board[i, j + 2] == player && board[i, j + 3] == player && board[i, j + 4] == player)
                {
                    return true;
                }
            }
        }

        // 检查垂直方向
        for (int i = 0; i <= size - 5; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (board[i, j] == player && board[i + 1, j] == player &&
                    board[i + 2, j] == player && board[i + 3, j] == player && board[i + 4, j] == player)
                {
                    return true;
                }
            }
        }

        // 检查正对角线方向
        for (int i = 0; i <= size - 5; i++)
        {
            for (int j = 0; j <= size - 5; j++)
            {
                if (board[i, j] == player && board[i + 1, j + 1] == player &&
                    board[i + 2, j + 2] == player && board[i + 3, j + 3] == player && board[i + 4, j + 4] == player)
                {
                    return true;
                }
            }
        }

        // 检查反对角线方向
        for (int i = 0; i <= size - 5; i++)
        {
            for (int j = 5; j < size; j++) // 从j=5开始，确保能向左上查找5个
            {
                if (board[i, j] == player && board[i + 1, j - 1] == player &&
                    board[i + 2, j - 2] == player && board[i + 3, j - 3] == player && board[i + 4, j - 4] == player)
                {
                    return true;
                }
            }
        }

        return false; // 没有找到五子连线
    }
}

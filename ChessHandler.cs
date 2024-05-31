using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessHandler : MonoBehaviour
{
    //预制品-白色棋子
    public GameObject whiteChessItem;
    //预制品-青色棋子
    public GameObject emeraldChessItem;

    Vector3 nowPosition;
    Vector3 newWhiteItemPosition = new Vector3(7, 0, 3.2F);
    Vector3 newEmeraldItemPosition = new Vector3(-5, 0, 3.2F);
    List<List<int>> board = new List<List<int>>(); //棋盘，1：白子，-1：青子，0：空格

    //初始化棋盘
    for (int i = 0; i < 11; i++)
    {
        board.Add(new List<int>(Enumerable.Repeat(0, 11)));
    }

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
}

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
    Vector3 newWhiteItemPosition = new Vector3(0, 0, 3.2F);
    Vector3 newEmeraldItemPosition = new Vector3(0, 0, 3.2F);
    static int count = 1;
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

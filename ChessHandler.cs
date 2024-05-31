using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessHandler : MonoBehaviour
{
    //Ԥ��Ʒ-��ɫ����
    public GameObject whiteChessItem;
    //Ԥ��Ʒ-��ɫ����
    public GameObject emeraldChessItem;

    Vector3 nowPosition;
    Vector3 newWhiteItemPosition = new Vector3(7, 0, 3.2F);
    Vector3 newEmeraldItemPosition = new Vector3(-5, 0, 3.2F);
    List<List<int>> board = new List<List<int>>(); //���̣�1�����ӣ�-1�����ӣ�0���ո�

    //��ʼ������
    for (int i = 0; i < 11; i++)
    {
        board.Add(new List<int>(Enumerable.Repeat(0, 11)));
    }

    static int count = 1; //���Ӽ���
    /**
     * ʵ�ֵ������ƶ�ʱ��λ�����������̸��ӽ��㴦
     */
    public void absorbItemPosition()
    {
        nowPosition = GetComponent<Renderer>().transform.position;
        nowPosition.z = 3.49F;
        nowPosition.y = Mathf.Round(nowPosition.y);
        nowPosition.x = Mathf.Round(nowPosition.x);
        //���������λ��д�ص���ǰ���ӵ�����
        GetComponent<Renderer>().transform.position = nowPosition;
    }


    public void generateNewItem()
    {
        if (count % 2 == 0)
        {
            //������ɫ����
            Instantiate(emeraldChessItem, newEmeraldItemPosition, Quaternion.identity);
        }
        else
        {
            //������ɫ����
            Instantiate(whiteChessItem, newWhiteItemPosition, Quaternion.identity);
        }
        count = count + 1;
    }
}

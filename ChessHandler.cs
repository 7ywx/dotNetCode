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
    Vector3 newWhiteItemPosition = new Vector3(0, 0, 3.2F);
    Vector3 newEmeraldItemPosition = new Vector3(0, 0, 3.2F);
    static int count = 1;
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

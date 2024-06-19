using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChessHandler : MonoBehaviour
{
    //Ԥ��Ʒ-��ɫ����
    public GameObject whiteChessItem;
    //Ԥ��Ʒ-��ɫ����
    public GameObject emeraldChessItem;

    Vector3 nowPosition;
    Vector3 newWhiteItemPosition = new Vector3(7, 0, 3.2F);
    Vector3 newEmeraldItemPosition = new Vector3(-5, 0, 3.2F);

    static int[,] board = new int[11, 11]; // ���� 1:��ɫ���� 2:��ɫ���� 0:�ո� ԭ����(4, 4)
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
        if (count % 2 != 0)
        {
            // ��ɫ����
            board[(int)(4 - nowPosition.y), (int)(nowPosition.x + 4)] = 2;
            Debug.Log("x+4: " + (int)(nowPosition.x + 4));
            Debug.Log("4-y: " + (int)(4 - nowPosition.y));
            Debug.Log("board[" + (int)(nowPosition.x + 4) + "," + (int)(4 - nowPosition.y) + "] = " + board[(int)(nowPosition.x + 4), (int)(4 - nowPosition.y)]);
        }
        else
        {
            // ��ɫ����
            board[(int)(4 - nowPosition.y), (int)(nowPosition.x + 4)] = 1;
        }
        Debug.Log("newPosition.x: " + nowPosition.x + " newPosition.y: " + nowPosition.y + ")");

        string boardContent = "";
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                // ���Ҷ���ķ�ʽ��ʽ��ÿ�����֣�����ÿ����Ԫ����Ϊ3���������ֺͿո�
                // �ɸ���ʵ������������
                boardContent += board[i, j].ToString().PadLeft(3);
                // ����������һ�У���ӷָ���������ʹ���Ʊ��'\t'��Ҳ���Ը���ϲ�õ���
                if (j < 10) boardContent += " ";
            }
            // ����
            boardContent += "\n";
        }
        Debug.Log(boardContent);

        // ����Ƿ����˻�ʤ
        if (CheckWin(board, 1))
        {
            Debug.Log("�׷���ʤ��");
            // ����������ʤ����Ĵ����߼�
        }
        else if (CheckWin(board, 2))
        {
            Debug.Log("�෽��ʤ��");
            // ����������ʤ����Ĵ����߼�
        }
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
    public bool CheckWin(int[,] board, int player)
    {
        int size = 11; // ���̴�СΪ11x11

        // ���ˮƽ����
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= size - 5; j++) // ȷ���ܼ�鵽������5��
            {
                if (board[i, j] == player && board[i, j + 1] == player &&
                    board[i, j + 2] == player && board[i, j + 3] == player && board[i, j + 4] == player)
                {
                    return true;
                }
            }
        }

        // ��鴹ֱ����
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

        // ������Խ��߷���
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

        // ��鷴�Խ��߷���
        for (int i = 0; i <= size - 5; i++)
        {
            for (int j = 5; j < size; j++) // ��j=5��ʼ��ȷ���������ϲ���5��
            {
                if (board[i, j] == player && board[i + 1, j - 1] == player &&
                    board[i + 2, j - 2] == player && board[i + 3, j - 3] == player && board[i + 4, j - 4] == player)
                {
                    return true;
                }
            }
        }

        return false; // û���ҵ���������
    }
}

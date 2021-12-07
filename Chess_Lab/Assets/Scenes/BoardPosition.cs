using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Board
{
    public class BoardPosition
    {
       Vector3 BoardPositionXMax;
       Vector3 BoardPositionXMin;
       Vector3 BoardPositionZMax;
       Vector3 BoardPositionZMin;
       Vector3 BoardPositionI;
       Vector3 BoardPositionII;
       Vector3 BoardPositionIII;
       Vector3 BoardPositionIV;
        bool ChessMoveRange;

       public bool BoardPositionRange(GameObject ChessMen, Vector3 maps, Vector3[] ChessMensPosition)
        {
           BoardPositionReset();
           switch (ChessMen.tag)
            {
                case "Pawn":
                    for(int i=0;i<ChessMensPosition.Length;i++)
                    {
                        if(ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x)
                                if (ChessMensPosition[i].z < BoardPositionZMax.z)
                                    BoardPositionZMax = ChessMensPosition[i];
                        }    
                    }
                    if (BoardPositionZMax.z > maps.z)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "Knight":
                    for (int i = 0; i < ChessMensPosition.Length; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {

                        }
                    }
                    break;
                case "Rook":
                    for(int i =0;i<ChessMensPosition.Length;i++)
                    {
                        if(ChessMensPosition[i].y == 0)
                        {
                            if(ChessMensPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (ChessMensPosition[i].x < BoardPositionXMax.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = ChessMensPosition[i];
                                if (ChessMensPosition[i].x > BoardPositionXMin.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = ChessMensPosition[i];
                            }
                            if(ChessMensPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (ChessMensPosition[i].z < BoardPositionZMax.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = ChessMensPosition[i];
                                if (ChessMensPosition[i].z > BoardPositionZMin.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = ChessMensPosition[i];
                            }
                        }
                    }
                    if (maps.x > BoardPositionXMin.x && maps.x < BoardPositionXMax.x)
                        ChessMoveRange = true;
                    else if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "bishop":
                    for(int i =0;i<ChessMensPosition.Length;i++)
                    {
                        if(ChessMensPosition[i].y == 0)
                        {
                            if((ChessMensPosition[i].x + ChessMensPosition[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if(ChessMensPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if (ChessMensPosition[i].x > BoardPositionII.x)
                                        BoardPositionII = ChessMensPosition[i];
                                }
                                if(ChessMensPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if(ChessMensPosition[i].x <BoardPositionIV.x)
                                        BoardPositionIV = ChessMensPosition[i];
                                }
                            }
                            if ((ChessMensPosition[i].x - ChessMensPosition[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if(ChessMensPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if(ChessMensPosition[i].x > BoardPositionIII.x)
                                        BoardPositionIII = ChessMensPosition[i];
                                }
                                if(ChessMensPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if(ChessMensPosition[i].x < BoardPositionI.x)
                                        BoardPositionI = ChessMensPosition[i];
                                }
                            }
                        }
                    }
                    if (maps.x > BoardPositionII.x && maps.x < BoardPositionIV.x && (maps.x + maps.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else if (maps.x > BoardPositionIII.x && maps.x < BoardPositionI.x && (maps.x - maps.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "Queen":
                    for (int i = 0; i < ChessMensPosition.Length; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (ChessMensPosition[i].x < BoardPositionXMax.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = ChessMensPosition[i];
                                if (ChessMensPosition[i].x > BoardPositionXMin.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = ChessMensPosition[i];
                            }
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (ChessMensPosition[i].z < BoardPositionZMax.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = ChessMensPosition[i];
                                if (ChessMensPosition[i].z > BoardPositionZMin.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = ChessMensPosition[i];
                            }
                            if ((ChessMensPosition[i].x + ChessMensPosition[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if (ChessMensPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if (ChessMensPosition[i].x > BoardPositionII.x)
                                        BoardPositionII = ChessMensPosition[i];
                                }
                                if (ChessMensPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if (ChessMensPosition[i].x < BoardPositionIV.x)
                                        BoardPositionIV = ChessMensPosition[i];
                                }
                            }
                            if ((ChessMensPosition[i].x - ChessMensPosition[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if (ChessMensPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if (ChessMensPosition[i].x > BoardPositionIII.x)
                                        BoardPositionIII = ChessMensPosition[i];
                                }
                                if (ChessMensPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if (ChessMensPosition[i].x < BoardPositionI.x)
                                        BoardPositionI = ChessMensPosition[i];
                                }
                            }
                        }
                    }
                    if (maps.x > BoardPositionXMin.x && maps.x < BoardPositionXMax.x)
                        ChessMoveRange = true;
                    else if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z)
                        ChessMoveRange = true;
                    if (maps.x > BoardPositionII.x && maps.x < BoardPositionIV.x && (maps.x + maps.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else if (maps.x > BoardPositionIII.x && maps.x < BoardPositionI.x && (maps.x - maps.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;   
                    break;
                case "King":
                    for (int i = 0; i < ChessMensPosition.Length; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if(ChessMensPosition[i].x == ChessMen.transform.position.x - 100)
                            {
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIII.z < ChessMensPosition[i].z)
                                        BoardPositionIII = ChessMensPosition[i];
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z )
                                    if (BoardPositionXMin.z < ChessMensPosition[i].z)
                                        BoardPositionXMin = ChessMensPosition[i];
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionII.z < ChessMensPosition[i].z)
                                        BoardPositionII = ChessMensPosition[i];
                            }
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionZMin.z < ChessMensPosition[i].z)
                                        BoardPositionZMin = ChessMensPosition[i];
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionZMax.z < ChessMensPosition[i].z)
                                        BoardPositionZMax = ChessMensPosition[i];
                            }
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x + 100)
                            {
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIV.z < ChessMensPosition[i].z)
                                        BoardPositionIV = ChessMensPosition[i];
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z)
                                    if (BoardPositionXMax.z < ChessMensPosition[i].z)
                                        BoardPositionXMax = ChessMensPosition[i];
                                if (ChessMensPosition[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionI.z < ChessMensPosition[i].z)
                                        BoardPositionI = ChessMensPosition[i];
                            }
                        }
                    }
                    if (maps.x > BoardPositionXMin.x && maps.x < BoardPositionXMax.x)
                        ChessMoveRange = true;
                    else if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z)
                        ChessMoveRange = true;
                    else if (maps.x > BoardPositionII.x && maps.x < BoardPositionIV.x && (maps.x + maps.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else if (maps.x > BoardPositionIII.x && maps.x < BoardPositionI.x && (maps.x - maps.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
            }
            return ChessMoveRange;
        }

        void BoardPositionReset()
        {
            BoardPositionXMax = new Vector3(800, 0, 0);
            BoardPositionXMin = new Vector3(-100, 0, 0);
            BoardPositionZMax = new Vector3(0, 0, 800);
            BoardPositionZMin = new Vector3(0, 0, -100);
            BoardPositionI = new Vector3(800, 0, 800);
            BoardPositionII = new Vector3(-100, 0, 800);
            BoardPositionIII = new Vector3(-100, 0, -100);
            BoardPositionIV = new Vector3(800, 0, -100);
        }
    }
}

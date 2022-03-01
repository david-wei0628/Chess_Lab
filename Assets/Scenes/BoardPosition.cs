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

       public bool BoardPositionRange(GameObject ChessMen, Vector3 maps, Vector3[] WhiteChessPosition, Vector3[] BlackChessPosition)
        {
           BoardPositionReset();
           switch (ChessMen.tag)
            {
                case "Pawn":
                    for(int i=0;i<WhiteChessPosition.Length;i++)
                    {
                        if(WhiteChessPosition[i].y == 0)
                        {
                            if (WhiteChessPosition[i].x == ChessMen.transform.position.x)
                                if (WhiteChessPosition[i].z < BoardPositionZMax.z && WhiteChessPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = WhiteChessPosition[i];
                        }    
                    }
                    if (BoardPositionZMax.z > maps.z && ChessMen.transform.position.x == maps.x)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "Knight":
                    for (int i = 0; i < WhiteChessPosition.Length; i++)
                    {
                        if (WhiteChessPosition[i].y == 0)
                        {
                            if (WhiteChessPosition[i].x == maps.x && WhiteChessPosition[i].z == maps.z)
                                ChessMoveRange = false;
                        }
                    }
                    break;
                case "Rook":
                    for(int i =0;i<WhiteChessPosition.Length;i++)
                    {
                        if(WhiteChessPosition[i].y == 0)
                        {
                            if(WhiteChessPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (WhiteChessPosition[i].x < BoardPositionXMax.x && WhiteChessPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].x > BoardPositionXMin.x && WhiteChessPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = WhiteChessPosition[i];
                            }
                            if(WhiteChessPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (WhiteChessPosition[i].z < BoardPositionZMax.z && WhiteChessPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z > BoardPositionZMin.z && WhiteChessPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = WhiteChessPosition[i];
                            }
                        }
                    }
                    if (maps.x > BoardPositionXMin.x && maps.x < BoardPositionXMax.x && maps.z == ChessMen.transform.position.z)
                        ChessMoveRange = true;
                    else if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z && maps.x == ChessMen.transform.position.x)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "bishop":
                    for(int i =0;i<WhiteChessPosition.Length;i++)
                    {
                        if(WhiteChessPosition[i].y == 0)
                        {
                            if((WhiteChessPosition[i].x + WhiteChessPosition[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if(WhiteChessPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if (WhiteChessPosition[i].x > BoardPositionII.x)
                                        BoardPositionII = WhiteChessPosition[i];
                                }
                                if(WhiteChessPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if(WhiteChessPosition[i].x <BoardPositionIV.x)
                                        BoardPositionIV = WhiteChessPosition[i];
                                }
                            }
                            if ((WhiteChessPosition[i].x - WhiteChessPosition[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if(WhiteChessPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if(WhiteChessPosition[i].x > BoardPositionIII.x)
                                        BoardPositionIII = WhiteChessPosition[i];
                                }
                                if(WhiteChessPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if(WhiteChessPosition[i].x < BoardPositionI.x)
                                        BoardPositionI = WhiteChessPosition[i];
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
                    for (int i = 0; i < WhiteChessPosition.Length; i++)
                    {
                        if (WhiteChessPosition[i].y == 0)
                        {
                            if (WhiteChessPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (WhiteChessPosition[i].x < BoardPositionXMax.x && WhiteChessPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].x > BoardPositionXMin.x && WhiteChessPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = WhiteChessPosition[i];
                            }
                            if (WhiteChessPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (WhiteChessPosition[i].z < BoardPositionZMax.z && WhiteChessPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z > BoardPositionZMin.z && WhiteChessPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = WhiteChessPosition[i];
                            }
                            if ((WhiteChessPosition[i].x + WhiteChessPosition[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if (WhiteChessPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if (WhiteChessPosition[i].x > BoardPositionII.x)
                                        BoardPositionII = WhiteChessPosition[i];
                                }
                                if (WhiteChessPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if (WhiteChessPosition[i].x < BoardPositionIV.x)
                                        BoardPositionIV = WhiteChessPosition[i];
                                }
                            }
                            if ((WhiteChessPosition[i].x - WhiteChessPosition[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if (WhiteChessPosition[i].x < ChessMen.transform.position.x)
                                {
                                    if (WhiteChessPosition[i].x > BoardPositionIII.x)
                                        BoardPositionIII = WhiteChessPosition[i];
                                }
                                if (WhiteChessPosition[i].x > ChessMen.transform.position.x)
                                {
                                    if (WhiteChessPosition[i].x < BoardPositionI.x)
                                        BoardPositionI = WhiteChessPosition[i];
                                }
                            }
                        }
                    }
                    if (maps.x > BoardPositionXMin.x && maps.x < BoardPositionXMax.x && maps.z == ChessMen.transform.position.z)
                        ChessMoveRange = true;
                    else if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z && maps.x == ChessMen.transform.position.x)
                        ChessMoveRange = true;
                    else if (maps.x > BoardPositionII.x && maps.x < BoardPositionIV.x && (maps.x + maps.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else if (maps.x > BoardPositionIII.x && maps.x < BoardPositionI.x && (maps.x - maps.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;   
                    break;
                case "King":
                    for (int i = 0; i < WhiteChessPosition.Length; i++)
                    {
                        if (WhiteChessPosition[i].y == 0)
                        {
                            if(WhiteChessPosition[i].x == ChessMen.transform.position.x - 100)
                            {
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIII.x < WhiteChessPosition[i].x)
                                        BoardPositionIII = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z )
                                    if (BoardPositionXMin.x < WhiteChessPosition[i].x)
                                        BoardPositionXMin = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionII.x < WhiteChessPosition[i].x)
                                        BoardPositionII = WhiteChessPosition[i];
                            }
                            if (WhiteChessPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionZMin.z < WhiteChessPosition[i].z)
                                        BoardPositionZMin = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionZMax.z > WhiteChessPosition[i].z)
                                        BoardPositionZMax = WhiteChessPosition[i];
                            }
                            if (WhiteChessPosition[i].x == ChessMen.transform.position.x + 100)
                            {
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIV.x > WhiteChessPosition[i].x)
                                        BoardPositionIV = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z)
                                    if (BoardPositionXMax.x > WhiteChessPosition[i].x)
                                        BoardPositionXMax = WhiteChessPosition[i];
                                if (WhiteChessPosition[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionI.x > WhiteChessPosition[i].x)
                                        BoardPositionI = WhiteChessPosition[i];
                            }
                        }
                    }
                    if (maps.x > BoardPositionXMin.x && maps.x < BoardPositionXMax.x && maps.z == ChessMen.transform.position.z)
                        ChessMoveRange = true;
                    else if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z && maps.x == ChessMen.transform.position.x)
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
            ChessMoveRange = true;
        }
    }
}

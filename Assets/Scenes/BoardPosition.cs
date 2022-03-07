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

       public bool BoardPositionRange(GameObject ChessMen, Vector3 maps, Vector3[] OwnPawn, Vector3[] EnemyPawn)
        {
           BoardPositionReset();
           switch (ChessMen.tag)
            {
                case "Pawn":
                    for(int i=0;i<OwnPawn.Length;i++)
                    {
                        if(OwnPawn[i].y == 0)
                        {
                            if (OwnPawn[i].x == ChessMen.transform.position.x)
                                if (OwnPawn[i].z < BoardPositionZMax.z && OwnPawn[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i];
                        }    
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].x == ChessMen.transform.position.x)
                            if (EnemyPawn[i].z < BoardPositionZMax.z && EnemyPawn[i].z > ChessMen.transform.position.z)
                                BoardPositionZMax = EnemyPawn[i];
                    }

                    if (BoardPositionZMax.z > maps.z && ChessMen.transform.position.x == maps.x)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "Knight":
                    for (int i = 0; i < OwnPawn.Length; i++)
                    {
                        if (OwnPawn[i].y == 0)
                        {
                            if (OwnPawn[i].x == maps.x && OwnPawn[i].z == maps.z)
                                ChessMoveRange = false;
                        }
                    }

                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].y == 0)
                        {
                            if (EnemyPawn[i].x == maps.x && EnemyPawn[i].z == maps.z)
                                ChessMoveRange = false;
                        }
                    }
                    break;
                case "Rook":
                    for(int i =0;i<OwnPawn.Length;i++)
                    {
                        if(OwnPawn[i].y == 0)
                        {
                            if(OwnPawn[i].z == ChessMen.transform.position.z)
                            {
                                if (OwnPawn[i].x < BoardPositionXMax.x && OwnPawn[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = OwnPawn[i];
                                if (OwnPawn[i].x > BoardPositionXMin.x && OwnPawn[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = OwnPawn[i];
                            }
                            if(OwnPawn[i].x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].z < BoardPositionZMax.z && OwnPawn[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i];
                                if (OwnPawn[i].z > BoardPositionZMin.z && OwnPawn[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = OwnPawn[i];
                            }
                        }
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].z == ChessMen.transform.position.z)
                        {
                            if (EnemyPawn[i].x < BoardPositionXMax.x && EnemyPawn[i].x > ChessMen.transform.position.x)
                                BoardPositionXMax.x = EnemyPawn[i].x + 100;
                            if (EnemyPawn[i].x > BoardPositionXMin.x && EnemyPawn[i].x < ChessMen.transform.position.x)
                                BoardPositionXMin.x = EnemyPawn[i].x - 100;
                        }
                        if (EnemyPawn[i].x == ChessMen.transform.position.x)
                        {
                            if (EnemyPawn[i].z < BoardPositionZMax.z && EnemyPawn[i].z > ChessMen.transform.position.z)
                                BoardPositionZMax.z = EnemyPawn[i].z + 100;
                            if (EnemyPawn[i].z > BoardPositionZMin.z && EnemyPawn[i].z < ChessMen.transform.position.z)
                                BoardPositionZMin.z = EnemyPawn[i].z - 100;
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
                    for(int i =0;i<OwnPawn.Length;i++)
                    {
                        if(OwnPawn[i].y == 0)
                        {
                            if((OwnPawn[i].x + OwnPawn[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if(OwnPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].x > BoardPositionII.x)
                                        BoardPositionII = OwnPawn[i];
                                }
                                if(OwnPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if(OwnPawn[i].x <BoardPositionIV.x)
                                        BoardPositionIV = OwnPawn[i];
                                }
                            }
                            if ((OwnPawn[i].x - OwnPawn[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if(OwnPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if(OwnPawn[i].x > BoardPositionIII.x)
                                        BoardPositionIII = OwnPawn[i];
                                }
                                if(OwnPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if(OwnPawn[i].x < BoardPositionI.x)
                                        BoardPositionI = OwnPawn[i];
                                }
                            }
                        }
                    }
                    for(int i =0;i< EnemyPawn.Length;i++)
                    {
                        if(EnemyPawn[i].y == 0)
                        {
                            if((EnemyPawn[i].x + EnemyPawn[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if(EnemyPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].x > BoardPositionII.x)
                                        BoardPositionII = EnemyPawn[i];
                                }
                                if(EnemyPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if(EnemyPawn[i].x <BoardPositionIV.x)
                                        BoardPositionIV = EnemyPawn[i];
                                }
                            }
                            if ((EnemyPawn[i].x - EnemyPawn[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if(EnemyPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if(EnemyPawn[i].x > BoardPositionIII.x)
                                        BoardPositionIII = EnemyPawn[i];
                                }
                                if(EnemyPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if(EnemyPawn[i].x < BoardPositionI.x)
                                        BoardPositionI = EnemyPawn[i];
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
                    for (int i = 0; i < OwnPawn.Length; i++)
                    {
                        if (OwnPawn[i].y == 0)
                        {
                            if (OwnPawn[i].z == ChessMen.transform.position.z)
                            {
                                if (OwnPawn[i].x < BoardPositionXMax.x && OwnPawn[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = OwnPawn[i];
                                if (OwnPawn[i].x > BoardPositionXMin.x && OwnPawn[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = OwnPawn[i];
                            }
                            if (OwnPawn[i].x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].z < BoardPositionZMax.z && OwnPawn[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i];
                                if (OwnPawn[i].z > BoardPositionZMin.z && OwnPawn[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = OwnPawn[i];
                            }
                            if ((OwnPawn[i].x + OwnPawn[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if (OwnPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].x > BoardPositionII.x)
                                        BoardPositionII = OwnPawn[i];
                                }
                                if (OwnPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].x < BoardPositionIV.x)
                                        BoardPositionIV = OwnPawn[i];
                                }
                            }
                            if ((OwnPawn[i].x - OwnPawn[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if (OwnPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].x > BoardPositionIII.x)
                                        BoardPositionIII = OwnPawn[i];
                                }
                                if (OwnPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].x < BoardPositionI.x)
                                        BoardPositionI = OwnPawn[i];
                                }
                            }
                        }
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].y == 0)
                        {
                            if (EnemyPawn[i].z == ChessMen.transform.position.z)
                            {
                                if (EnemyPawn[i].x < BoardPositionXMax.x && EnemyPawn[i].x > ChessMen.transform.position.x)
                                    BoardPositionXMax = EnemyPawn[i];
                                if (EnemyPawn[i].x > BoardPositionXMin.x && EnemyPawn[i].x < ChessMen.transform.position.x)
                                    BoardPositionXMin = EnemyPawn[i];
                            }
                            if (EnemyPawn[i].x == ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].z < BoardPositionZMax.z && EnemyPawn[i].z > ChessMen.transform.position.z)
                                    BoardPositionZMax = EnemyPawn[i];
                                if (EnemyPawn[i].z > BoardPositionZMin.z && EnemyPawn[i].z < ChessMen.transform.position.z)
                                    BoardPositionZMin = EnemyPawn[i];
                            }
                            if ((EnemyPawn[i].x + EnemyPawn[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if (EnemyPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].x > BoardPositionII.x)
                                        BoardPositionII = EnemyPawn[i];
                                }
                                if (EnemyPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].x < BoardPositionIV.x)
                                        BoardPositionIV = EnemyPawn[i];
                                }
                            }
                            if ((EnemyPawn[i].x - EnemyPawn[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if (EnemyPawn[i].x < ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].x > BoardPositionIII.x)
                                        BoardPositionIII = EnemyPawn[i];
                                }
                                if (EnemyPawn[i].x > ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].x < BoardPositionI.x)
                                        BoardPositionI = EnemyPawn[i];
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
                    for (int i = 0; i < OwnPawn.Length; i++)
                    {
                        if (OwnPawn[i].y == 0)
                        {
                            if(OwnPawn[i].x == ChessMen.transform.position.x - 100)
                            {
                                if (OwnPawn[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIII.x < OwnPawn[i].x)
                                        BoardPositionIII = OwnPawn[i];
                                if (OwnPawn[i].z == ChessMen.transform.position.z )
                                    if (BoardPositionXMin.x < OwnPawn[i].x)
                                        BoardPositionXMin = OwnPawn[i];
                                if (OwnPawn[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionII.x < OwnPawn[i].x)
                                        BoardPositionII = OwnPawn[i];
                            }
                            if (OwnPawn[i].x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionZMin.z < OwnPawn[i].z)
                                        BoardPositionZMin = OwnPawn[i];
                                if (OwnPawn[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionZMax.z > OwnPawn[i].z)
                                        BoardPositionZMax = OwnPawn[i];
                            }
                            if (OwnPawn[i].x == ChessMen.transform.position.x + 100)
                            {
                                if (OwnPawn[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIV.x > OwnPawn[i].x)
                                        BoardPositionIV = OwnPawn[i];
                                if (OwnPawn[i].z == ChessMen.transform.position.z)
                                    if (BoardPositionXMax.x > OwnPawn[i].x)
                                        BoardPositionXMax = OwnPawn[i];
                                if (OwnPawn[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionI.x > OwnPawn[i].x)
                                        BoardPositionI = OwnPawn[i];
                            }
                        }
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].y == 0)
                        {
                            if(EnemyPawn[i].x == ChessMen.transform.position.x - 100)
                            {
                                if (EnemyPawn[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIII.x < EnemyPawn[i].x)
                                        BoardPositionIII = EnemyPawn[i];
                                if (EnemyPawn[i].z == ChessMen.transform.position.z )
                                    if (BoardPositionXMin.x < EnemyPawn[i].x)
                                        BoardPositionXMin = EnemyPawn[i];
                                if (EnemyPawn[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionII.x < EnemyPawn[i].x)
                                        BoardPositionII = EnemyPawn[i];
                            }
                            if (EnemyPawn[i].x == ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionZMin.z < EnemyPawn[i].z)
                                        BoardPositionZMin = EnemyPawn[i];
                                if (EnemyPawn[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionZMax.z > EnemyPawn[i].z)
                                        BoardPositionZMax = EnemyPawn[i];
                            }
                            if (EnemyPawn[i].x == ChessMen.transform.position.x + 100)
                            {
                                if (EnemyPawn[i].z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIV.x > EnemyPawn[i].x)
                                        BoardPositionIV = EnemyPawn[i];
                                if (EnemyPawn[i].z == ChessMen.transform.position.z)
                                    if (BoardPositionXMax.x > EnemyPawn[i].x)
                                        BoardPositionXMax = EnemyPawn[i];
                                if (EnemyPawn[i].z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionI.x > EnemyPawn[i].x)
                                        BoardPositionI = EnemyPawn[i];
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

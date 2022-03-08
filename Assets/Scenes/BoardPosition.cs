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

       public bool BoardPositionRange(GameObject ChessMen, Vector3 maps, GameObject[] OwnPawn, GameObject[] EnemyPawn)
        {
           BoardPositionReset();
           switch (ChessMen.tag)
            {
                case "Pawn":
                    for(int i=0;i<OwnPawn.Length;i++)
                    {
                        if(OwnPawn[i].transform.position.y == 0)
                        {
                            if (OwnPawn[i].transform.position.x == ChessMen.transform.position.x)
                                if (OwnPawn[i].transform.position.z < BoardPositionZMax.z && OwnPawn[i].transform.position.z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i].transform.position;
                        }    
                    }

                    if (BoardPositionZMax.z > maps.z && ChessMen.transform.position.x == maps.x)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "Knight":
                    for (int i = 0; i < OwnPawn.Length; i++)
                    {
                        if (OwnPawn[i].transform.position.y == 0)
                        {
                            if (OwnPawn[i].transform.position.x == maps.x && OwnPawn[i].transform.position.z == maps.z)
                                ChessMoveRange = false;
                        }
                    }

                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].transform.position.y == 0)
                        {
                            if (EnemyPawn[i].transform.position.x == maps.x && EnemyPawn[i].transform.position.z == maps.z)
                                ChessMoveRange = false;
                        }
                    }
                    break;
                case "Rook":
                    for(int i =0;i<OwnPawn.Length;i++)
                    {
                        if(OwnPawn[i].transform.position.y == 0)
                        {
                            if(OwnPawn[i].transform.position.z == ChessMen.transform.position.z)
                            {
                                if (OwnPawn[i].transform.position.x < BoardPositionXMax.x && OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                    BoardPositionXMax = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.x > BoardPositionXMin.x && OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                    BoardPositionXMin = OwnPawn[i].transform.position;
                            }
                            if(OwnPawn[i].transform.position.x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].transform.position.z < BoardPositionZMax.z && OwnPawn[i].transform.position.z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z > BoardPositionZMin.z && OwnPawn[i].transform.position.z < ChessMen.transform.position.z)
                                    BoardPositionZMin = OwnPawn[i].transform.position;
                            }
                        }
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z)
                        {
                            if (EnemyPawn[i].transform.position.x < BoardPositionXMax.x && EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                                BoardPositionXMax.x = EnemyPawn[i].transform.position.x + 100;
                            if (EnemyPawn[i].transform.position.x > BoardPositionXMin.x && EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                                BoardPositionXMin.x = EnemyPawn[i].transform.position.x - 100;
                        }
                        if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x)
                        {
                            if (EnemyPawn[i].transform.position.z < BoardPositionZMax.z && EnemyPawn[i].transform.position.z > ChessMen.transform.position.z)
                                BoardPositionZMax.z = EnemyPawn[i].transform.position.z + 100;
                            if (EnemyPawn[i].transform.position.z > BoardPositionZMin.z && EnemyPawn[i].transform.position.z < ChessMen.transform.position.z)
                                BoardPositionZMin.z = EnemyPawn[i].transform.position.z - 100;
                        }
                    }

                    EnemyPaenActive(maps, EnemyPawn);
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
                        if(OwnPawn[i].transform.position.y == 0)
                        {
                            if((OwnPawn[i].transform.position.x + OwnPawn[i].transform.position.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if(OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].transform.position.x > BoardPositionII.x)
                                        BoardPositionII = OwnPawn[i].transform.position;
                                }
                                if(OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if(OwnPawn[i].transform.position.x <BoardPositionIV.x)
                                        BoardPositionIV = OwnPawn[i].transform.position;
                                }
                            }
                            if ((OwnPawn[i].transform.position.x - OwnPawn[i].transform.position.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if(OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if(OwnPawn[i].transform.position.x > BoardPositionIII.x)
                                        BoardPositionIII = OwnPawn[i].transform.position;
                                }
                                if(OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if(OwnPawn[i].transform.position.x < BoardPositionI.x)
                                        BoardPositionI = OwnPawn[i].transform.position;
                                }
                            }
                        }
                    }
                    for(int i =0;i< EnemyPawn.Length;i++)
                    {
                        if(EnemyPawn[i].transform.position.y == 0)
                        {
                            if((EnemyPawn[i].transform.position.x + EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if(EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].transform.position.x > BoardPositionII.x)
                                        BoardPositionII = EnemyPawn[i].transform.position;
                                }
                                if(EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if(EnemyPawn[i].transform.position.x <BoardPositionIV.x)
                                        BoardPositionIV = EnemyPawn[i].transform.position;
                                }
                            }
                            if ((EnemyPawn[i].transform.position.x - EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if(EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if(EnemyPawn[i].transform.position.x > BoardPositionIII.x)
                                        BoardPositionIII = EnemyPawn[i].transform.position;
                                }
                                if(EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if(EnemyPawn[i].transform.position.x < BoardPositionI.x)
                                        BoardPositionI = EnemyPawn[i].transform.position;
                                }
                            }
                        }
                    }

                    EnemyPaenActive(maps, EnemyPawn);
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
                        if (OwnPawn[i].transform.position.y == 0)
                        {
                            if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z)
                            {
                                if (OwnPawn[i].transform.position.x < BoardPositionXMax.x && OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                    BoardPositionXMax = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.x > BoardPositionXMin.x && OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                    BoardPositionXMin = OwnPawn[i].transform.position;
                            }
                            if (OwnPawn[i].transform.position.x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].transform.position.z < BoardPositionZMax.z && OwnPawn[i].transform.position.z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z > BoardPositionZMin.z && OwnPawn[i].transform.position.z < ChessMen.transform.position.z)
                                    BoardPositionZMin = OwnPawn[i].transform.position;
                            }
                            if ((OwnPawn[i].transform.position.x + OwnPawn[i].transform.position.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if (OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].transform.position.x > BoardPositionII.x)
                                        BoardPositionII = OwnPawn[i].transform.position;
                                }
                                if (OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].transform.position.x < BoardPositionIV.x)
                                        BoardPositionIV = OwnPawn[i].transform.position;
                                }
                            }
                            if ((OwnPawn[i].transform.position.x - OwnPawn[i].transform.position.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if (OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].transform.position.x > BoardPositionIII.x)
                                        BoardPositionIII = OwnPawn[i].transform.position;
                                }
                                if (OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if (OwnPawn[i].transform.position.x < BoardPositionI.x)
                                        BoardPositionI = OwnPawn[i].transform.position;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].transform.position.y == 0)
                        {
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z)
                            {
                                if (EnemyPawn[i].transform.position.x < BoardPositionXMax.x && EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                                    BoardPositionXMax = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.x > BoardPositionXMin.x && EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                                    BoardPositionXMin = EnemyPawn[i].transform.position;
                            }
                            if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.z < BoardPositionZMax.z && EnemyPawn[i].transform.position.z > ChessMen.transform.position.z)
                                    BoardPositionZMax = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.z > BoardPositionZMin.z && EnemyPawn[i].transform.position.z < ChessMen.transform.position.z)
                                    BoardPositionZMin = EnemyPawn[i].transform.position;
                            }
                            if ((EnemyPawn[i].transform.position.x + EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                            {
                                if (EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].transform.position.x > BoardPositionII.x)
                                        BoardPositionII = EnemyPawn[i].transform.position;
                                }
                                if (EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].transform.position.x < BoardPositionIV.x)
                                        BoardPositionIV = EnemyPawn[i].transform.position;
                                }
                            }
                            if ((EnemyPawn[i].transform.position.x - EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                            {
                                if (EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].transform.position.x > BoardPositionIII.x)
                                        BoardPositionIII = EnemyPawn[i].transform.position;
                                }
                                if (EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                                {
                                    if (EnemyPawn[i].transform.position.x < BoardPositionI.x)
                                        BoardPositionI = EnemyPawn[i].transform.position;
                                }
                            }
                        }
                    }

                    EnemyPaenActive(maps, EnemyPawn);
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
                        if (OwnPawn[i].transform.position.y == 0)
                        {
                            if(OwnPawn[i].transform.position.x == ChessMen.transform.position.x - 100)
                            {
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIII.x < OwnPawn[i].transform.position.x)
                                        BoardPositionIII = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z )
                                    if (BoardPositionXMin.x < OwnPawn[i].transform.position.x)
                                        BoardPositionXMin = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionII.x < OwnPawn[i].transform.position.x)
                                        BoardPositionII = OwnPawn[i].transform.position;
                            }
                            if (OwnPawn[i].transform.position.x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionZMin.z < OwnPawn[i].transform.position.z)
                                        BoardPositionZMin = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionZMax.z > OwnPawn[i].transform.position.z)
                                        BoardPositionZMax = OwnPawn[i].transform.position;
                            }
                            if (OwnPawn[i].transform.position.x == ChessMen.transform.position.x + 100)
                            {
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIV.x > OwnPawn[i].transform.position.x)
                                        BoardPositionIV = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z)
                                    if (BoardPositionXMax.x > OwnPawn[i].transform.position.x)
                                        BoardPositionXMax = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionI.x > OwnPawn[i].transform.position.x)
                                        BoardPositionI = OwnPawn[i].transform.position;
                            }
                        }
                    }
                    for (int i = 0; i < EnemyPawn.Length; i++)
                    {
                        if (EnemyPawn[i].transform.position.y == 0)
                        {
                            if(EnemyPawn[i].transform.position.x == ChessMen.transform.position.x - 100)
                            {
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIII.x < EnemyPawn[i].transform.position.x)
                                        BoardPositionIII = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z )
                                    if (BoardPositionXMin.x < EnemyPawn[i].transform.position.x)
                                        BoardPositionXMin = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionII.x < EnemyPawn[i].transform.position.x)
                                        BoardPositionII = EnemyPawn[i].transform.position;
                            }
                            if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionZMin.z < EnemyPawn[i].transform.position.z)
                                        BoardPositionZMin = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionZMax.z > EnemyPawn[i].transform.position.z)
                                        BoardPositionZMax = EnemyPawn[i].transform.position;
                            }
                            if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x + 100)
                            {
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                    if (BoardPositionIV.x > EnemyPawn[i].transform.position.x)
                                        BoardPositionIV = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z)
                                    if (BoardPositionXMax.x > EnemyPawn[i].transform.position.x)
                                        BoardPositionXMax = EnemyPawn[i].transform.position;
                                if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                    if (BoardPositionI.x > EnemyPawn[i].transform.position.x)
                                        BoardPositionI = EnemyPawn[i].transform.position;
                            }
                        }
                    }

                    EnemyPaenActive(maps, EnemyPawn);
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

        void EnemyPaenActive(Vector3 maps,GameObject[] EnemyPawn)
        {
            for (int i = 0; i < EnemyPawn.Length; i++)
            {
                if (maps == EnemyPawn[i].transform.position)
                {
                    EnemyPawn[i].active = !EnemyPawn[i].active;
                }
            }

        }
    }
}

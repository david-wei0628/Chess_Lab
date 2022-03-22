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
                            {
                                if (OwnPawn[i].transform.position.z < BoardPositionZMax.z && OwnPawn[i].transform.position.z > ChessMen.transform.position.z)
                                    BoardPositionZMax = OwnPawn[i].transform.position;
                                if (OwnPawn[i].transform.position.z > BoardPositionZMin.z && OwnPawn[i].transform.position.z < ChessMen.transform.position.z)
                                    BoardPositionZMin = OwnPawn[i].transform.position;
                            }
                        }    
                    }
                    for(int i=0;i< EnemyPawn.Length;i++)
                    {
                        if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x)
                        {
                            if (EnemyPawn[i].transform.position.z < BoardPositionZMax.z && EnemyPawn[i].transform.position.z > ChessMen.transform.position.z)
                                BoardPositionZMax.z = EnemyPawn[i].transform.position.z;
                            if (EnemyPawn[i].transform.position.z > BoardPositionZMin.z && EnemyPawn[i].transform.position.z < ChessMen.transform.position.z)
                                BoardPositionZMin.z = EnemyPawn[i].transform.position.z;
                        }
                    }

                    if (maps.z > BoardPositionZMin.z && maps.z < BoardPositionZMax.z && maps.x == ChessMen.transform.position.x)
                        ChessMoveRange = true;
                    else
                        ChessMoveRange = false;
                    break;
                case "Knight":
                    for (int i = 0; i < OwnPawn.Length; i++)
                    {
                        if (OwnPawn[i].transform.position.y == 0)
                        {
                            if (OwnPawn[i].transform.position == maps)
                                ChessMoveRange = false;
                        }
                    }

                    break;
                case "Rook":
                    for(int i = 0 ; i < OwnPawn.Length; i++)
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
                        if ((EnemyPawn[i].transform.position.x + EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                        {
                            if (EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x > BoardPositionII.x)
                                {
                                    BoardPositionII.x = EnemyPawn[i].transform.position.x - 100;
                                    BoardPositionII.z = EnemyPawn[i].transform.position.z + 100;
                                }
                            }
                            if (EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x < BoardPositionIV.x)
                                {
                                    BoardPositionIV.x = EnemyPawn[i].transform.position.x + 100;
                                    BoardPositionIV.z = EnemyPawn[i].transform.position.z - 100;
                                }
                            }
                        }
                        if ((EnemyPawn[i].transform.position.x - EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                        {
                            if (EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x > BoardPositionIII.x)
                                {
                                    BoardPositionIII.x = EnemyPawn[i].transform.position.x - 100;
                                    BoardPositionIII.z = EnemyPawn[i].transform.position.z - 100;
                                }
                            }
                            if (EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x < BoardPositionI.x)
                                {
                                    BoardPositionI.x = EnemyPawn[i].transform.position.x + 100;
                                    BoardPositionI.z = EnemyPawn[i].transform.position.z + 100;
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
                        if (OwnPawn[i].transform.position.y == 0)
                        {
                            if (OwnPawn[i].transform.position.z == ChessMen.transform.position.z)
                            {
                                if (OwnPawn[i].transform.position.x < BoardPositionXMax.x && OwnPawn[i].transform.position.x > ChessMen.transform.position.x)
                                    BoardPositionXMax.x = OwnPawn[i].transform.position.x + 100;
                                if (OwnPawn[i].transform.position.x > BoardPositionXMin.x && OwnPawn[i].transform.position.x < ChessMen.transform.position.x)
                                    BoardPositionXMin.x = OwnPawn[i].transform.position.x - 100;
                            }
                            if (OwnPawn[i].transform.position.x == ChessMen.transform.position.x)
                            {
                                if (OwnPawn[i].transform.position.z < BoardPositionZMax.z && OwnPawn[i].transform.position.z > ChessMen.transform.position.z)
                                    BoardPositionZMax.z = OwnPawn[i].transform.position.z + 100;
                                if (OwnPawn[i].transform.position.z > BoardPositionZMin.z && OwnPawn[i].transform.position.z < ChessMen.transform.position.z)
                                    BoardPositionZMin.z = OwnPawn[i].transform.position.z - 100;
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
                        if ((EnemyPawn[i].transform.position.x + EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x + ChessMen.transform.position.z))
                        {
                            if (EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x > BoardPositionII.x)
                                {
                                    BoardPositionII.x = EnemyPawn[i].transform.position.x - 100;
                                    BoardPositionII.z = EnemyPawn[i].transform.position.z + 100;
                                }
                            }
                            if (EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x < BoardPositionIV.x)
                                {
                                    BoardPositionIV.x = EnemyPawn[i].transform.position.x + 100;
                                    BoardPositionIV.z = EnemyPawn[i].transform.position.z - 100;
                                }
                            }
                        }
                        if ((EnemyPawn[i].transform.position.x - EnemyPawn[i].transform.position.z) == (ChessMen.transform.position.x - ChessMen.transform.position.z))
                        {
                            if (EnemyPawn[i].transform.position.x < ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x > BoardPositionIII.x)
                                {
                                    BoardPositionIII.x = EnemyPawn[i].transform.position.x - 100;
                                    BoardPositionIII.z = EnemyPawn[i].transform.position.z - 100;
                                }
                            }
                            if (EnemyPawn[i].transform.position.x > ChessMen.transform.position.x)
                            {
                                if (EnemyPawn[i].transform.position.x < BoardPositionI.x)
                                {
                                    BoardPositionI.x = EnemyPawn[i].transform.position.x + 100;
                                    BoardPositionI.z = EnemyPawn[i].transform.position.z + 100;
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
                        if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x - 100)
                        {
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                if (BoardPositionIII.x < EnemyPawn[i].transform.position.x)
                                {
                                    BoardPositionIII.x = EnemyPawn[i].transform.position.x - 100;
                                    BoardPositionIII.z = EnemyPawn[i].transform.position.z - 100;
                                }
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z)
                                if (BoardPositionXMin.x < EnemyPawn[i].transform.position.x)
                                    BoardPositionXMin.x = EnemyPawn[i].transform.position.x - 100;
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                if (BoardPositionII.x < EnemyPawn[i].transform.position.x)
                                {
                                    BoardPositionII.x = EnemyPawn[i].transform.position.x - 100;
                                    BoardPositionII.z = EnemyPawn[i].transform.position.z + 100;
                                }
                        }
                        if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x)
                        {
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                if (BoardPositionZMin.z < EnemyPawn[i].transform.position.z)
                                    BoardPositionZMin.z = EnemyPawn[i].transform.position.z - 100;
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                if (BoardPositionZMax.z > EnemyPawn[i].transform.position.z)
                                    BoardPositionZMax.z = EnemyPawn[i].transform.position.z + 100;
                        }
                        if (EnemyPawn[i].transform.position.x == ChessMen.transform.position.x + 100)
                        {
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z - 100)
                                if (BoardPositionIV.x > EnemyPawn[i].transform.position.x)
                                {
                                    BoardPositionIV.x = EnemyPawn[i].transform.position.x + 100;
                                    BoardPositionIV.z = EnemyPawn[i].transform.position.z - 100;
                                }
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z)
                                if (BoardPositionXMax.x > EnemyPawn[i].transform.position.x)
                                    BoardPositionXMax.x = EnemyPawn[i].transform.position.x + 100;
                            if (EnemyPawn[i].transform.position.z == ChessMen.transform.position.z + 100)
                                if (BoardPositionI.x > EnemyPawn[i].transform.position.x)
                                {
                                    BoardPositionI.x = EnemyPawn[i].transform.position.x + 100;
                                    BoardPositionI.z = EnemyPawn[i].transform.position.z + 100;
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

       public void EnemyPawnActive(GameObject ChessMen, GameObject[] EnemyPawn)
        {
            for (int i = 0; i < EnemyPawn.Length; i++)
            {
                if (EnemyPawn[i].transform.position == ChessMen.transform.position)
                {
                    //if (EnemyPawn[i].name[0] == 'B')
                    //    EnemyPawn[i].transform.position = new Vector3(50 * i, 0, -100);
                    //else if (EnemyPawn[i].name[0] == 'W')
                    //    EnemyPawn[i].transform.position = new Vector3(50 * i, 0, 800);

                    EnemyPawn[i].SetActive(false);
                }
            }
        }
        
       public bool PawnCatch(GameObject ChessMen, GameObject[] EnemyPawn, Vector3 maps)
        {
            if (ChessMen.name[0] == 'W')
            {
                for (int i = 0; i < EnemyPawn.Length; i++)
                {
                    if (EnemyPawn[i].transform.position.z - ChessMen.transform.position.z == 100 && EnemyPawn[i].transform.position == maps)
                    {
                        if (Mathf.Abs(EnemyPawn[i].transform.position.x - ChessMen.transform.position.x) == 100)
                        {
                            return true;
                        }
                    }
                } 
            }
            else if(ChessMen.name[0] == 'B')
            {
                for (int i = 0; i < EnemyPawn.Length; i++)
                {
                    if (ChessMen.transform.position.z - EnemyPawn[i].transform.position.z == 100 && EnemyPawn[i].transform.position == maps)
                    {
                        if (Mathf.Abs(EnemyPawn[i].transform.position.x - ChessMen.transform.position.x) == 100)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public Mesh PawnUp(GameObject ChessMen, GameObject[] OwnPawn)
        {
            Mesh Queen = ChessMen.GetComponent<Mesh>();
            for(int i = 0; i < OwnPawn.Length; i++)
            {
                if(OwnPawn[i].tag == "Queen")
                    return OwnPawn[i].GetComponent<MeshFilter>().mesh;
            }
            return Queen;
        }
    }
}

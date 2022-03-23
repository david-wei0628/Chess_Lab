﻿using System.Collections;
using UnityEngine;
using Chess.Board;

namespace Chess.ChessMen
{
    public class ChessMen_Move
    {
        BoardPosition BoardPosition = new BoardPosition();
        bool ChessMoveType = true;

        public GameObject SelectMove(GameObject ChessMen, Vector3 maps, string Lock_objext, GameObject[] OwnPawn, GameObject[] EnemyPawn)
        {
            ChessMoveType = BoardPosition.BoardPositionRange(ChessMen, maps, OwnPawn, EnemyPawn);
            switch (ChessMen.tag)
            {
                case "Pawn":
                    if (ChessMen.transform.position.x == maps.x && ChessMoveType && ChessMen.name[0] == 'W')
                    {
                        if (ChessMen.transform.position.z == 100)
                        {
                            if (maps.z - ChessMen.transform.position.z == 200 || maps.z - ChessMen.transform.position.z == 100)
                            {
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                            }
                        }
                        else if (maps.z - ChessMen.transform.position.z == 100)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                        }
                    }
                    else if (ChessMen.transform.position.x == maps.x && ChessMoveType && ChessMen.name[0] == 'B')
                    {
                        if (ChessMen.transform.position.z == 600)
                        {
                            if (maps.z - ChessMen.transform.position.z == -200 || maps.z - ChessMen.transform.position.z == -100)
                            {
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                            }
                        }
                        else if (maps.z - ChessMen.transform.position.z == -100)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                        }
                    }

                    if (BoardPosition.PawnCatch(ChessMen, EnemyPawn, maps))
                    {
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    }

                    if (ChessMen.transform.position.z == 700 || ChessMen.transform.position.z == 0)
                    {
                        PawnPromotion(ChessMen, OwnPawn);
                    }
                    break;
                case "Knight":
                    if (ChessMoveType)
                    {
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 200)
                        {
                            if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100)
                            {
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                            }
                        }
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100)
                        {
                            if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 200)
                            {
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                            }
                        }
                    }
                    break;
                case "Rook":
                    if (ChessMoveType)
                    {
                        if (maps.z == ChessMen.transform.position.z)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                        if (maps.x == ChessMen.transform.position.x)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                    }
                    break;
                case "bishop":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x))
                    {
                        if (ChessMoveType)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                    }
                    break;
                case "Queen":
                    if (ChessMoveType)
                    {
                        if (maps.z == ChessMen.transform.position.z)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                        else if (maps.x == ChessMen.transform.position.x)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x))
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                    }
                    break;
                case "King":
                    if (Mathf.Abs(maps.x - ChessMen.transform.position.x) <= 100 && Mathf.Abs(maps.z - ChessMen.transform.position.z) <= 100)
                    {
                        if (ChessMoveType)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                    }
                    break;
            }
            if (Lock_objext != "Board" && ChessMen.transform.position.y > 0)
            {
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y - 50, ChessMen.transform.position.z);
            }

            BoardPosition.EnemyPawnActive(ChessMen, EnemyPawn);
            return ChessMen;
        }

        void PawnPromotion(GameObject ChessMen, GameObject[] OwnPawn)
        {
            ChessMen.tag = "Queen";
            ChessMen.GetComponent<MeshFilter>().sharedMesh = BoardPosition.PawnUp(ChessMen, OwnPawn);
        }
    }

}
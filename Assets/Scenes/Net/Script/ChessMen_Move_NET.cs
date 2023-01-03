using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Board;

namespace Chess.ChessMen
{
    public class ChessMen_Move_NET
    {
        BoardPosition BoardPosition = new BoardPosition();
        bool ChessMoveType = true;
        public Mesh PawnUp;
        public string ChageTag;

        public GameObject SelectMove(GameObject ChessMen, Vector3 maps, string Lock_objext, List<GameObject> OwnPawn, List<GameObject> EnemyPawn)
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
                        PawnPromotion(ChessMen);
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
                        if (maps.z == ChessMen.transform.position.z || maps.x == ChessMen.transform.position.x)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                        //if (maps.x == ChessMen.transform.position.x)
                        //{
                        //    ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        //}
                    }
                    break;
                case "bishop":
                    if (ChessMoveType)
                    {
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x))
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                    }
                    break;
                case "Queen":
                    if (ChessMoveType)
                    {
                        if (maps.z == ChessMen.transform.position.z || maps.x == ChessMen.transform.position.x)
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                        //else if (maps.x == ChessMen.transform.position.x)
                        //{
                        //    ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        //}
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x))
                        {
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        }
                    }
                    break;
                case "King":
                    if (ChessMoveType)
                    {
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) <= 100 && Mathf.Abs(maps.z - ChessMen.transform.position.z) <= 100)
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

        void PawnPromotion(GameObject ChessMen)
        {
            ChessMen.tag = ChageTag;
            ChessMen.GetComponent<MeshFilter>().sharedMesh = PawnUp;
        }

    }

}
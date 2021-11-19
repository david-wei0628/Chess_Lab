using System.Collections;
using UnityEngine;

namespace Chess.ChessMen
{
    public class ChessMen_Move
    {
        Vector3 BoardPositionMaxRange = new Vector3(800, 0, 800);
        Vector3 BoardPositionMinRange = new Vector3(0, 0, 0);

        public GameObject Select_Move(GameObject ChessMen, Vector3 maps, string Lock_objext,Vector3[] ChessMensPosition)
        {
            ChessMoveMax(ChessMen, ChessMensPosition);
            switch (ChessMen.tag)
            {
                case "Pawn":
                    if (ChessMen.transform.position.z == 100 && ChessMen.transform.position.x == maps.x)
                    {
                        if (maps.z - ChessMen.transform.position.z == 200 || maps.z - ChessMen.transform.position.z == 100)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    }
                    if (maps.z - ChessMen.transform.position.z == 100 && maps.z <= BoardPositionMaxRange.z && ChessMen.transform.position.x == maps.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    break;
                case "Knight":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 200 && maps.z <= BoardPositionMaxRange.z && maps.z >= 0)
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= BoardPositionMaxRange.z && maps.z >= 0)
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 200)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "Rook":
                    if (maps.z == ChessMen.transform.position.z)
                        if(maps.x <= BoardPositionMaxRange.x && maps.x >= BoardPositionMinRange.x)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                     if (maps.x == ChessMen.transform.position.x)
                         if (maps.z <= BoardPositionMaxRange.z && maps.z >= BoardPositionMinRange.z)
                             ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "bishop":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x) 
                        && maps.z <= BoardPositionMaxRange.z && maps.x <= BoardPositionMaxRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "Queen":
                    if (maps.z == ChessMen.transform.position.z && maps.x <= BoardPositionMaxRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (maps.x == ChessMen.transform.position.x && maps.z <= BoardPositionMaxRange.z)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x) 
                        && maps.z <= BoardPositionMaxRange.z && maps.x <= BoardPositionMaxRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "King":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= BoardPositionMaxRange.z)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100 && maps.x <= BoardPositionMaxRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
            }
            if (Lock_objext != "Board" && ChessMen.transform.position.y > 0)
            {
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y - 50, ChessMen.transform.position.z);
                BoardPositionMaxRange = new Vector3(700, 0, 700);
            }
            return ChessMen;
        }

        void ChessMoveMax(GameObject ChessMen,Vector3[] ChessMensPosition)
        {
            int ChessMensPosition_size;
            ChessMensPosition_size = ChessMensPosition.Length;
            switch (ChessMen.tag)
            {
                case "Pawn":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            //if (ChessMen.transform.position.x == ChessMensPosition[i].x)
                            //    if (ChessMensPosition[i].z - ChessMen.transform.position.z == 100)
                            //        BoardPositionMaxRange.z = ChessMensPosition[i].z;
                        }
                    }
                    break;
                case "Knight":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {

                        }
                    }
                    break;
                case "Rook":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                                if (ChessMensPosition[i].z >= BoardPositionMinRange.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionMinRange.z = ChessMensPosition[i].z ;
                            }
                            if (ChessMensPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x ;
                            }
                        }
                    }
                    break;
                case "bishop":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            
                        }
                    }
                    break;
                case "Quent":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMen.transform.position.x == ChessMensPosition[i].x && ChessMensPosition[i].z <= BoardPositionMaxRange.z)
                            BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                        if (ChessMen.transform.position.z == ChessMensPosition[i].z && ChessMensPosition[i].x <= BoardPositionMaxRange.x)
                            BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                    }
                    break;
                case "King":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {

                        }
                    }
                    break;
            }
        }
    }
    
}
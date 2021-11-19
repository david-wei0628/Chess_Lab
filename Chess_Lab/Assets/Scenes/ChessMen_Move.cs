using System.Collections;
using UnityEngine;

namespace Chess.ChessMen
{
    public class ChessMen_Move
    {
        Vector3 BoardPositionMaxRange = new Vector3(700, 0, 700);
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
                    if (maps.z == ChessMen.transform.position.z && maps.x < BoardPositionMaxRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    else if (maps.x == ChessMen.transform.position.x && maps.z < BoardPositionMaxRange.z)
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
            switch(ChessMen.tag)
            {
                case "Pawn":
                    for (int i = 0; i < 16; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMen.transform.position.x == ChessMensPosition[i].x)
                                if (ChessMensPosition[i].z - ChessMen.transform.position.z == 100)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z;
                        }
                    }
                            break;
                case "Knight":
                    for (int i = 0; i < 16; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {

                        }
                    }
                    break;
                case "Rook":
                    for(int i = 0; i < 16  ; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMen.transform.position.x == ChessMensPosition[i].x && ChessMensPosition[i].z <= BoardPositionMaxRange.z)
                                if (ChessMen.transform.position.z != ChessMensPosition[i].z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                            if (ChessMen.transform.position.z == ChessMensPosition[i].z && ChessMensPosition[i].x <= BoardPositionMaxRange.x)
                                if (ChessMen.transform.position.x != ChessMensPosition[i].x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                        }
                    }
                    break;
                case "bishop":
                    for (int i = 0; i < 16; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {

                        }
                    }
                    break;
                case "Quent":
                    for (int i = 0; i < 16; i++)
                    {
                        if (ChessMen.transform.position.x == ChessMensPosition[i].x && ChessMensPosition[i].z <= BoardPositionMaxRange.z)
                            BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                        if (ChessMen.transform.position.z == ChessMensPosition[i].z && ChessMensPosition[i].x <= BoardPositionMaxRange.x)
                            BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                    }
                    break;
                case "King":
                    for (int i = 0; i < 16; i++)
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
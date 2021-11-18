using System.Collections;
using UnityEngine;

namespace Chess.ChessMen
{
    public class ChessMen_Move
    {
        Vector3 BoardPositionRange = new Vector3(700, 0, 700);

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
                    if (maps.z - ChessMen.transform.position.z == 100 && maps.z <= BoardPositionRange.z && ChessMen.transform.position.x == maps.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    break;
                case "Knight":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 200 && maps.z <= BoardPositionRange.z && maps.z >= 0)
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= BoardPositionRange.z && maps.z >= 0)
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 200)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "Rook":
                    if (maps.z == ChessMen.transform.position.z && maps.x <= BoardPositionRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    else if (maps.x == ChessMen.transform.position.x && maps.z <= BoardPositionRange.z)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "bishop":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x) 
                        && maps.z <= BoardPositionRange.z && maps.x <= BoardPositionRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "Queen":
                    if (maps.z == ChessMen.transform.position.z && maps.x <= BoardPositionRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (maps.x == ChessMen.transform.position.x && maps.z <= BoardPositionRange.z)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x) 
                        && maps.z <= BoardPositionRange.z && maps.x <= BoardPositionRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "King":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= BoardPositionRange.z)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100 && maps.x <= BoardPositionRange.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
            }
            if (Lock_objext != "Board" && ChessMen.transform.position.y > 0)
            {
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y - 50, ChessMen.transform.position.z);
                BoardPositionRange = new Vector3(700, 0, 700);
            }
            return ChessMen;
        }

        void ChessMoveMax(GameObject ChessMen,Vector3[] ChessMensPosition)
        {
            switch(ChessMen.tag)
            {
                case "Pawn":
                    break;
                case "Knight":
                    break;
                case "Rook":
                    for(int i = 0; i < 16  ; i++)
                    {   
                        if (ChessMen.transform.position.x == ChessMensPosition[i].x && ChessMensPosition[i].z <= BoardPositionRange.z)
                            BoardPositionRange.z = ChessMensPosition[i].z - 100;
                        if (ChessMen.transform.position.z == ChessMensPosition[i].z && ChessMensPosition[i].x <= BoardPositionRange.x)
                            BoardPositionRange.x = ChessMensPosition[i].x - 100;
                    }
                    break;
                case "bishop":
                    break;
                case "Quent":
                    for (int i = 0; i < 16; i++)
                    {
                        if (ChessMen.transform.position.x == ChessMensPosition[i].x && ChessMensPosition[i].z <= BoardPositionRange.z)
                            BoardPositionRange.z = ChessMensPosition[i].z - 100;
                        if (ChessMen.transform.position.z == ChessMensPosition[i].z && ChessMensPosition[i].x <= BoardPositionRange.x)
                            BoardPositionRange.x = ChessMensPosition[i].x - 100;
                    }
                    break;
                case "King":
                    break;
            }
        }
    }
    
}
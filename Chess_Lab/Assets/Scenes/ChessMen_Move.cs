using System.Collections;
using UnityEngine;

namespace Chess.ChessMen
{
    public class ChessMen_Move
    {
        Vector3 BoardPositionMaxRange;
        Vector3 BoardPositionMinRange;
        bool kChessTpye;

        public GameObject Select_Move(GameObject ChessMen, Vector3 maps, string Lock_objext,Vector3[] ChessMensPosition)
        {
            ChessMoveRange(ChessMen,maps, ChessMensPosition);
            switch (ChessMen.tag)
            {
                case "Pawn":
                    if (ChessMen.transform.position.x == maps.x && maps.z <= BoardPositionMaxRange.z)
                    {
                        if (ChessMen.transform.position.z == 100)
                        {
                            if (maps.z - ChessMen.transform.position.z == 200 || maps.z - ChessMen.transform.position.z == 100)
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                        }
                        else if (maps.z - ChessMen.transform.position.z == 100)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    }
                    break;
                case "Knight":
                    if (kChessTpye)
                    {
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 200 && maps.z <= BoardPositionMaxRange.z && maps.z >= BoardPositionMinRange.z)
                            if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100)
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                        if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= BoardPositionMaxRange.z && maps.z >= BoardPositionMinRange.z)
                            if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 200)
                                ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    break;
                case "Rook":
                    if (maps.z == ChessMen.transform.position.z)
                    {
                        if (maps.x <= BoardPositionMaxRange.x && maps.x >= BoardPositionMinRange.x)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    if (maps.x == ChessMen.transform.position.x)
                    {
                        if (maps.z <= BoardPositionMaxRange.z && maps.z >= BoardPositionMinRange.z)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    break;
                case "bishop":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x))
                    {
                        if (maps.z <= BoardPositionMaxRange.z && maps.x <= BoardPositionMaxRange.x)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    break;
                case "Queen":
                    if (maps.z == ChessMen.transform.position.z)
                    {
                        if (maps.x <= BoardPositionMaxRange.x && maps.x >= BoardPositionMinRange.x)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    if (maps.x == ChessMen.transform.position.x)
                    {
                        if (maps.z <= BoardPositionMaxRange.z && maps.z >= BoardPositionMinRange.z)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x))
                    {
                        if (maps.z <= BoardPositionMaxRange.z && maps.x <= BoardPositionMaxRange.x)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    }
                    break;
                case "King":
                    if (Mathf.Abs(maps.x - ChessMen.transform.position.x) <= 100 && Mathf.Abs(maps.z - ChessMen.transform.position.z) <= 100 && kChessTpye)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
            }
            if (Lock_objext != "Board" && ChessMen.transform.position.y > 0)
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y - 50, ChessMen.transform.position.z);

            return ChessMen;
        }

        void ChessMoveRange(GameObject ChessMen,Vector3 maps, Vector3[] ChessMensPosition)
        {
            int ChessMensPosition_size;
            ChessMensPosition_size = ChessMensPosition.Length;
            BoardPositionMaxRange = new Vector3(700, 0, 700);
            BoardPositionMinRange = new Vector3(0, 0, 0);
            kChessTpye = true;
            switch (ChessMen.tag)
            {
                case "Pawn":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                            }
                        }
                    }
                    break;
                case "Knight":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].x == maps.x && ChessMensPosition[i].z == maps.z)
                                kChessTpye = false;
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
                                    BoardPositionMinRange.z = ChessMensPosition[i].z + 100 ;
                            }
                            if (ChessMensPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x + 100;
                            }
                        }
                    }
                    break;
                case "bishop":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if((ChessMensPosition[i].x + ChessMensPosition[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z) && (ChessMen.transform.position.x + ChessMen.transform.position.z) == (maps.x + maps.z))
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                                if (ChessMensPosition[i].z >= BoardPositionMinRange.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionMinRange.z = ChessMensPosition[i].z + 100;
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x + 100;
                            }
                            else if ((ChessMensPosition[i].x - ChessMensPosition[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z) && (ChessMen.transform.position.x - ChessMen.transform.position.z) == (maps.x - maps.z))
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                                if (ChessMensPosition[i].z >= BoardPositionMinRange.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionMinRange.z = ChessMensPosition[i].z + 100;
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x + 100;
                            }
                        }
                    }
                    break;
                case "Queen":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].x == ChessMen.transform.position.x)
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                                if (ChessMensPosition[i].z >= BoardPositionMinRange.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionMinRange.z = ChessMensPosition[i].z + 100;
                            }
                            if (ChessMensPosition[i].z == ChessMen.transform.position.z)
                            {
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x + 100;
                            }
                            if ((ChessMensPosition[i].x + ChessMensPosition[i].z) == (ChessMen.transform.position.x + ChessMen.transform.position.z) && (ChessMen.transform.position.x + ChessMen.transform.position.z) == (maps.x + maps.z))
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                                if (ChessMensPosition[i].z >= BoardPositionMinRange.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionMinRange.z = ChessMensPosition[i].z + 100;
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x + 100;
                            }
                            else if ((ChessMensPosition[i].x - ChessMensPosition[i].z) == (ChessMen.transform.position.x - ChessMen.transform.position.z) && (ChessMen.transform.position.x - ChessMen.transform.position.z) == (maps.x - maps.z))
                            {
                                if (ChessMensPosition[i].z <= BoardPositionMaxRange.z && ChessMensPosition[i].z > ChessMen.transform.position.z)
                                    BoardPositionMaxRange.z = ChessMensPosition[i].z - 100;
                                if (ChessMensPosition[i].z >= BoardPositionMinRange.z && ChessMensPosition[i].z < ChessMen.transform.position.z)
                                    BoardPositionMinRange.z = ChessMensPosition[i].z + 100;
                                if (ChessMensPosition[i].x <= BoardPositionMaxRange.x && ChessMensPosition[i].x > ChessMen.transform.position.x)
                                    BoardPositionMaxRange.x = ChessMensPosition[i].x - 100;
                                if (ChessMensPosition[i].x >= BoardPositionMinRange.x && ChessMensPosition[i].x < ChessMen.transform.position.x)
                                    BoardPositionMinRange.x = ChessMensPosition[i].x + 100;
                            }
                        }
                    }
                    break;
                case "King":
                    for (int i = 0; i < ChessMensPosition_size; i++)
                    {
                        if (ChessMensPosition[i].y == 0)
                        {
                            if (ChessMensPosition[i].x == maps.x && ChessMensPosition[i].z == maps.z)
                                kChessTpye = false;
                        }
                    }
                    break;
            }
        }
    }
    
}
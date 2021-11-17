using System.Collections;
using UnityEngine;

namespace Chess.ChessMen
{
    public class ChessMen_Move : MonoBehaviour
    {
        public GameObject Select_Move(GameObject ChessMen,Vector3 maps,string Lock_objext)
        {

            switch (ChessMen.tag)
            {
                case "Pawn":
                    if (ChessMen.transform.position.z == 100 && ChessMen.transform.position.x == maps.x)
                    {
                        if (maps.z - ChessMen.transform.position.z == 200 || maps.z - ChessMen.transform.position.z == 100)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    }
                    if (maps.z - ChessMen.transform.position.z == 100 && maps.z <= 700 && ChessMen.transform.position.x == maps.x)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1.0f);
                    break;
                case "Knight":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 200 && maps.z <= 700 && maps.z >= 0)
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= 700 && maps.z >= 0)
                        if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 200)
                            ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "Rook":
                    if (maps.z == ChessMen.transform.position.z && maps.x <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    else if (maps.x == ChessMen.transform.position.x && maps.z <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "bishop":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x) && maps.z <= 700 && maps.x <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "Queen":
                    if (maps.z == ChessMen.transform.position.z && maps.x <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (maps.x == ChessMen.transform.position.x && maps.z <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == Mathf.Abs(maps.x - ChessMen.transform.position.x) && maps.z <= 700 && maps.x <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
                case "King":
                    if (Mathf.Abs(maps.z - ChessMen.transform.position.z) == 100 && maps.z <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    if (Mathf.Abs(maps.x - ChessMen.transform.position.x) == 100 && maps.x <= 700)
                        ChessMen.transform.position = Vector3.Lerp(ChessMen.transform.position, maps, 1f);
                    break;
            }
            if (Lock_objext != "Board" && ChessMen.transform.position.y > 0)
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y - 50, ChessMen.transform.position.z);

            return ChessMen;
        }

    }
    
}
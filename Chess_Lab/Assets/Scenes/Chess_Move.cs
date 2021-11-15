using Chess.ChessMen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lock_objext = "Board";
        ChessCollider = ChessMen.GetComponent<Collider>().enabled;
    }
    public Camera main_camear;
    GameObject ChessMen;
    string Lock_objext;
    Vector3 maps;
    Ray ray;
    RaycastHit hit;
    bool ChessCollider;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Lock_objext == "Board")
            Select_Chess();
        else if (Input.GetMouseButtonDown(0) && Lock_objext != "Board")
            Select_Move();
    }

    void Select_Chess()
    {
        if (Select_Ray())
        {
            ChessMen = GameObject.Find(hit.collider.name);
            Lock_objext = ChessMen.name;
            if (Lock_objext != "Board")
            { 
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y + 50, ChessMen.transform.position.z);
                ChessMen.GetComponent<Collider>().enabled = !ChessMen.GetComponent<Collider>().enabled;
            }
        }
    }

    void Select_Move()
    {
        Select_Ray();
        switch (ChessMen.tag)
        {
            case "Pawn":
                if (ChessMen.transform.position.z == 100)
                {
                    if (maps.z - ChessMen.transform.position.z == 200 || maps.z - ChessMen.transform.position.z == 100)
                        ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y, maps.z);
                }
                if (maps.z - ChessMen.transform.position.z == 100)
                    ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y, maps.z);
                break;
            case "Knight":
                if (maps.z - ChessMen.transform.position.z == 200 && maps.z <= 700)
                    if (maps.x - ChessMen.transform.position.x == 100 || maps.x - ChessMen.transform.position.x == -100)
                        ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                if (maps.z - ChessMen.transform.position.z == -200 && maps.z <= 700)
                    if (maps.x - ChessMen.transform.position.x == 100 || maps.x - ChessMen.transform.position.x == -100)
                        ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                if(maps.z - ChessMen.transform.position.z == 100 && maps.z <= 700)
                    if (maps.x - ChessMen.transform.position.x == 200 || maps.x - ChessMen.transform.position.x == -200)
                        ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                if(maps.z - ChessMen.transform.position.z == -100 && maps.z <= 700)
                    if (maps.x - ChessMen.transform.position.x == 200 || maps.x - ChessMen.transform.position.x == -200)
                        ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                break;
            case "Rook":
                if (maps.z == ChessMen.transform.position.z && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, ChessMen.transform.position.z);
                else if (maps.x == ChessMen.transform.position.x && maps.z <= 700)
                    ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y, maps.z);
                break;
            case "bishop":
                if (maps.z - ChessMen.transform.position.z == maps.x - ChessMen.transform.position.x && maps.z <= 700 && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                if (maps.z - ChessMen.transform.position.z == ChessMen.transform.position.x - maps.x && maps.z <= 700 && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                break;
            case "Queen":
                if (maps.z == ChessMen.transform.position.z && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, ChessMen.transform.position.z);
                if (maps.x == ChessMen.transform.position.x && maps.z <= 700)
                    ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y, maps.z);
                if (maps.z - ChessMen.transform.position.z == maps.x - ChessMen.transform.position.x && maps.z <= 700 && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                if (maps.z - ChessMen.transform.position.z == ChessMen.transform.position.x - maps.x && maps.z <= 700 && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, maps.z);
                break;
            case "King":
                if (maps.z - ChessMen.transform.position.z == 100 && maps.z <= 700)
                    ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y, maps.z);
                if (maps.z - ChessMen.transform.position.z == -100 && maps.z <= 700)
                    ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y, maps.z);
                if (maps.x - ChessMen.transform.position.x == 100 && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, ChessMen.transform.position.z);
                if (maps.x - ChessMen.transform.position.x == -100 && maps.x <= 700)
                    ChessMen.transform.position = new Vector3(maps.x, ChessMen.transform.position.y, ChessMen.transform.position.z);
                break;
        }
        ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y - 50, ChessMen.transform.position.z);
        ChessMen.GetComponent<Collider>().enabled = !ChessMen.GetComponent<Collider>().enabled;
        Lock_objext = "Board";
    }

    /// <summary>
    /// 棋盤座標棋格中心校準
    /// </summary>
    void Coordinate_correction()
    {
        maps.x = maps.x + 50;
        maps.x = maps.x - (maps.x % 100);
        maps.z = maps.z + 50;
        maps.z = maps.z - (maps.z % 100);
    }

    bool Select_Ray()
    {
        ray = main_camear.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 5000);
        maps = hit.point;
        Coordinate_correction();
        return Physics.Raycast(ray, out hit, 5000);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.ChessMen;

public class Chess_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lock_objext = "Board";
    }

    public Camera main_camear;
    public static GameObject ChessMen;
    public static string Lock_objext;
    public static Vector3 maps;
    public static Ray ray;
    public static RaycastHit hit;
    ChessMen_Move ChessMen_Move = new ChessMen_Move();
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Lock_objext == "Board")
            Select_Chess();
        else if (Input.GetMouseButtonDown(0) && Lock_objext != "Board")
        {
            Select_Ray();
            SetChessColliderEnabled();
            ChessMen = ChessMen_Move.Select_Move(ChessMen,maps,Lock_objext);
            Lock_objext = "Board";
            //Select_Move();
        }
    }

    /// <summary>
    /// 基礎完成後，此方法轉到ChessMen_Move.cs使用，因為有雙色棋用同方法
    /// </summary>
    void Select_Chess()
    {
        if (Select_Ray())
        {
            SetChessColliderEnabled();
            ChessMen = GameObject.Find(hit.collider.name);
            Lock_objext = ChessMen.name;
            if (Lock_objext != "Board")
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y + 50, ChessMen.transform.position.z);
        }
    }
    /// <summary>
    /// 基礎完成後，此方法轉到ChessMen_Move.cs使用，因為有雙色棋用同方法
    /// </summary>
    void Select_Move()
    {
        Select_Ray();
        SetChessColliderEnabled();
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
        maps.y = 0;
    }

    bool Select_Ray()
    {
        ray = main_camear.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 5000);
        maps = hit.point;
        Coordinate_correction();
        return Physics.Raycast(ray, out hit, 5000);
    }
    /// <summary>
    /// 基礎完成後，此方法轉到ChessMen_Move.cs使用，因為有雙色棋用同方法
    /// </summary>
    void SetChessColliderEnabled()
    {
        for (int i = 0; i < this.GetComponentsInChildren<Collider>().Length; i++)
            this.GetComponentsInChildren<Collider>()[i].enabled = !this.GetComponentsInChildren<Collider>()[i].enabled;
    }
    
}

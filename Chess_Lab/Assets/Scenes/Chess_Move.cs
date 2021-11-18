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
    GameObject ChessMen;
    string Lock_objext;
    Vector3 maps;
    Vector3[] WhiteChessposition = new Vector3[16];
    Ray ray;
    RaycastHit hit;
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
            ChessMen = ChessMen_Move.Select_Move(ChessMen,maps,Lock_objext,WhiteChessposition);
            Lock_objext = "Board";
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
        Physics.Raycast(ray, out hit, 3500);
        maps = hit.point;
        Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.9f, true);
        Coordinate_correction();
        return Physics.Raycast(ray, out hit, 3500);
    }
    /// <summary>
    /// 基礎完成後，此方法轉到ChessMen_Move.cs使用，因為有雙色棋用同方法
    /// </summary>
    void SetChessColliderEnabled()
    {
        for (int i = 0; i < this.GetComponentsInChildren<Collider>().Length; i++)
        {
            this.GetComponentsInChildren<Collider>()[i].enabled = !this.GetComponentsInChildren<Collider>()[i].enabled;
            WhiteChessposition[i] = this.GetComponentsInChildren<Collider>()[i].transform.position;
        }
    }
    
    
}

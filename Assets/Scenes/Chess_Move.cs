using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.ChessMen;
using Chess.Board;

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
    Vector3[] BlackChessposition = new Vector3[16];
    Ray ray;
    RaycastHit hit;
    ChessMen_Move ChessMen_Move = new ChessMen_Move();
    BoardPosition BoardPosition = new BoardPosition();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Lock_objext == "Board")
            Select_Chess();
        else if (Input.GetMouseButtonDown(0) && Lock_objext != "Board")
        {
            Select_Ray();
            SetChessColliderEnabled();
            ChessMen = ChessMen_Move.Select_Move(ChessMen,maps,Lock_objext,WhiteChessposition, BlackChessposition);
            Lock_objext = "Board";
        }

        if(Input.GetMouseButtonUp(2))
        {
            show();
        }
    }
    

    /// <summary>
    /// 黑白棋使用同方法，棋色差異無影響    
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
    /// 黑白棋統一碰撞體狀態
    /// </summary>
    void SetChessColliderEnabled()
    {
        int blackstar = 0;
        for (int i = 0; i < this.GetComponentsInChildren<Collider>().Length; i++)
        {
            this.GetComponentsInChildren<Collider>()[i].enabled = !this.GetComponentsInChildren<Collider>()[i].enabled;
            if (this.GetComponentsInChildren<Collider>()[i].name[0] == 'W')
            {
                WhiteChessposition[i] = this.GetComponentsInChildren<Collider>()[i].transform.position;
                blackstar++;
            }
            if (this.GetComponentsInChildren<Collider>()[i].name[0] == 'B')
            {
                BlackChessposition[i - blackstar] = this.GetComponentsInChildren<Collider>()[i].transform.position;
            }
        }
    }

    void show()
    {
        //for(int i=0;i<WhiteChessposition.Length && ChessMen.name[0] == 'W';i++)
        //{
        //    Debug.Log("W + " +i+" "+WhiteChessposition[i]);
        //}
        //for(int i=0;i<BlackChessposition.Length && ChessMen.name[0] == 'B'; i++)
        //{
        //    Debug.Log("B + " +i+" "+BlackChessposition[i]);
        //}

        if(ChessMen.name[0] == 'W')
        {
            Debug.Log(ChessMen.GetComponentInParent<Collider>().name);
        }
        else if(ChessMen.name[0] == 'B')
        {
            Debug.Log(ChessMen.GetComponentInParent<Collider>().name);
        }
    }
}

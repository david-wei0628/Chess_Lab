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
            ChessMen = ChessMen_Move.Select_Move(ChessMen,maps,Lock_objext,WhiteChessposition);
            Lock_objext = "Board";
        }

        if(Input.GetMouseButtonUp(2))
        {
            //show();
            Debug.Log(ChessMen.tag);
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
        //Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.9f, true);
        Coordinate_correction();
        return Physics.Raycast(ray, out hit, 3500);
    }
    /// <summary>
    /// 基礎完成後，此方法轉到ChessMen_Move.cs使用，因為有雙色棋用同方法
    /// </summary>
    void SetChessColliderEnabled()
    {
        if(this.name[9] == 'W')
        {
            for (int i = 0; i < this.GetComponentsInChildren<Collider>().Length; i++)
            {
                this.GetComponentsInChildren<Collider>()[i].enabled = !this.GetComponentsInChildren<Collider>()[i].enabled;
                WhiteChessposition[i] = this.GetComponentsInChildren<Collider>()[i].transform.position;
            }
        }
        //Debug.Log(this.GetComponentsInChildren<Collider>().Length + this.name);
        if(this.name[9] == 'B')
        {
            for (int i = 0; i < this.GetComponentsInChildren<Collider>().Length && this.name[9] == 'B'; i++)
            {
                this.GetComponentsInChildren<Collider>()[i].enabled = !this.GetComponentsInChildren<Collider>()[i].enabled;
                BlackChessposition[i] = this.GetComponentsInChildren<Collider>()[i].transform.position;
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
            Debug.Log(WhiteChessposition.Length);
        }
        else if(ChessMen.name[0] == 'B')
        {
            Debug.Log(this.name);
            Debug.Log(this.GetComponentsInChildren<Collider>().Length);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.ChessMen;
using Chess.Board;
using UnityEngine.UI;
using Mirror;

public class Chess_Move_NET : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lock_objext = "Board";
        UseChess.text = "White";
        UpMesh = MeshQueen;
        ChessMen_Move.ChageTag = "Queen";
        PawnUp.text = "PawnUP : Queen";
        //Net.text = ChoosePawn.ToString();
        //Aut = GetComponent<NetworkBehaviour>().isOwned;
        //main_camear.enabled = false;
        //CamearChange();
        //if (!Aut)
        //{
        //    //User_Camear.SetActive(Aut);
        //    //UserCame(Aut);
        //    return;
        //}
    }

    public Camera main_camear;
    public GameObject User_Camear;
    GameObject ChessMen;
    string Lock_objext;
    char ChoosePawn = 'W';
    //public char ChoosePawn = NetworkManager.CurrentSide;
    Vector3 maps;
    //GameObject[] WhiteChessposition = new GameObject[16];
    List<GameObject> WhiteChesslist = new List<GameObject>();
    //GameObject[] BlackChessposition = new GameObject[16];
    List<GameObject> BlackChesslist = new List<GameObject>();
    Vector3 ChossChess;
    Ray ray;
    RaycastHit hit;
    ChessMen_Move ChessMen_Move = new ChessMen_Move();
    Mesh UpMesh;
    public Mesh MeshQueen;
    public Mesh MeshKnight;
    public Mesh MeshBishop;
    public Mesh MeshRook;
    public Text UseChess;
    public Text PawnUp;
    public Text Net;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetMouseButtonDown(0) && NetworkClient.active)
        {
            if (Lock_objext == "Board")
                SelectChess();
            else if (Lock_objext != "Board")
                MoveChess();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        //Net.text = NetworkClient.CurrentSide.ToString();
        //Debug.Log(NetworkServer.CurrentSide.ToString());
    }

    /// <summary>
    /// 黑白棋使用同方法選則棋子，棋色差異無影響，加入判斷可選擇棋子顏色
    /// </summary>
    void SelectChess()
    {
        if (SelectRay())
        {
            SetChessColliderEnabled();
            ChessMen = GameObject.Find(hit.collider.name);
            Lock_objext = ChessMen.name;
            if (Lock_objext != "Board" && ChessMen.name[0] == ChoosePawn)
                ChessMen.transform.position = new Vector3(ChessMen.transform.position.x, ChessMen.transform.position.y + 50, ChessMen.transform.position.z);
        }
    }

    /// <summary>
    /// 棋子選擇後移動，黑白棋交替選擇
    /// </summary>
    void MoveChess()
    {
        SelectRay();
        SetChessColliderEnabled();
        ChossChess = ChessMen.transform.position;
        ChossChess.y = 0;
        if (ChoosePawn == 'W' && ChessMen.transform.position.y == 50)
        {
            ChessMen = ChessMen_Move.SelectMove(ChessMen, maps, Lock_objext, WhiteChesslist, BlackChesslist);
            if (ChossChess != ChessMen.transform.position)
            {
                //ChoosePawn = 'B';
                ChoosePawn = NetworkClient.Chess(ChoosePawn);
                //WhiteChesslist.Clear();
                //BlackChesslist.Clear();
                Invoke("CamearTrans", 0.5f);
            }
        }
        else if (ChoosePawn == 'B' && ChessMen.transform.position.y == 50)
        {
            ChessMen = ChessMen_Move.SelectMove(ChessMen, maps, Lock_objext, BlackChesslist, WhiteChesslist);
            if (ChossChess != ChessMen.transform.position)
            {
                //ChoosePawn = 'W';
                ChoosePawn = NetworkClient.Chess(ChoosePawn);
                //WhiteChesslist.Clear();
                //BlackChesslist.Clear();
                Invoke("CamearTrans", 0.5f);
            }
        }
        WhiteChesslist.Clear();
        BlackChesslist.Clear();
        Lock_objext = "Board";
    }

    /// <summary>
    /// 棋盤座標棋格中心校準
    /// </summary>
    void CoordinateCorrection()
    {
        maps.x = maps.x + 50;
        maps.x = maps.x - (maps.x % 100);
        maps.z = maps.z + 50;
        maps.z = maps.z - (maps.z % 100);
        maps.y = 0;
    }

    bool SelectRay()
    {
        ray = main_camear.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 3500);
        maps = hit.point;
        //if (hit.collider.name[0] == 'W')
        //    Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.blue, 0.5f, true);
        //else
        //    Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.5f, true);
        CoordinateCorrection();
        return Physics.Raycast(ray, out hit, 3500);
    }

    /// <summary>
    /// 黑白棋統一碰撞體狀態
    /// </summary>
    void SetChessColliderEnabled()
    {
        for (int i = 0; i < this.GetComponentsInChildren<Collider>().Length; i++)
        {
            this.GetComponentsInChildren<Collider>()[i].enabled = !this.GetComponentsInChildren<Collider>()[i].enabled;
            if (this.GetComponentsInChildren<Collider>()[i].name[0] == 'W')
            {
                //WhiteChessposition[i] = this.GetComponentsInChildren<Collider>()[i].gameObject;
                WhiteChesslist.Add(this.GetComponentsInChildren<Collider>()[i].gameObject);
            }
            if (this.GetComponentsInChildren<Collider>()[i].name[0] == 'B')
            {
                //BlackChessposition[i - blackstar] = this.GetComponentsInChildren<Collider>()[i].gameObject;
                BlackChesslist.Add(this.GetComponentsInChildren<Collider>()[i].gameObject);
            }
        }
    }

    void CamearTrans()
    {
        if (ChoosePawn == 'W')
        {
            //Net.text = "a";
            UseChess.text = "White";
            main_camear.transform.position = new Vector3(350, 940, -225);
            main_camear.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
        else if (ChoosePawn == 'B')
        {
            //Net.text = "b";
            UseChess.text = "Black";
            main_camear.transform.position = new Vector3(350, 940, 930);
            main_camear.transform.rotation = Quaternion.Euler(60, 180, 0);
        }
        ChessMen_Move = new ChessMen_Move();
        //UIText();
    }

    void PawnMesh(string v)
    {
        switch(v)
        {
            case "bishop":
                UpMesh = MeshBishop;
                break;
            case "Queen":
                UpMesh = MeshQueen;
                break;
            case "Rook":
                UpMesh = MeshRook;
                break;
            case "Knight":
                UpMesh = MeshKnight;
                break;
        }
        ChessMen_Move.ChageTag = v;
        ChessMen_Move.PawnUp = UpMesh;
    }

    public void MeshBtnOnClick(Button v)
    {        
        PawnMesh(v.tag);
        PawnUp.text = "PawnUP : " + ChessMen_Move.ChageTag.ToString();
        
    } 

    void CamearChange()
    {
        User_Camear.transform.position = main_camear.transform.position;
        //User_Camear.transform.localRotation = main_camear.transform.localRotation;
        //main_camear.enabled = false;
    }

    void UserCame(bool type)
    {
        User_Camear.SetActive(type);
    }

    void UIText()
    {
        //Net.text = NetworkClient.active.ToString() + " " + NetworkServer.active.ToString();
        //Net.text = ChoosePawn.ToString();
    }



}

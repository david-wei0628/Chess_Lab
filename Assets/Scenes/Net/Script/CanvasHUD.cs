using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //buttonHost.onClick.AddListener(ButtonHost);
        val = 1;
    }

    public Button buttonHost;
    public Text text;
    int val;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonHost()
    {
        //NetworkManager.singleton.StartHost();
        text.text = (val + val).ToString();
        val = val + val;
    }
}

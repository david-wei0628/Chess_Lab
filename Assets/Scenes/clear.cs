using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public delegate void testDelegeta();

    private testDelegeta testDelegetaFun;
    
    // Start is called before the first frame update
    void Start()
    {
        testDelegetaFun = () => { Debug.Log("Lamb"); };
        testDelegetaFun();
    }

    private void Awake()
    {
        testDelegetaFun = () => { Debug.Log("XXLamb"); };
        testDelegetaFun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

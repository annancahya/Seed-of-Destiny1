using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
   
    public GameObject Panel;
    public GameObject Menu;
    void Start()
    {
        
        // Menu.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        Panel.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
        }
    }
}

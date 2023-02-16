using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private GameObject NoteObject;
    public static bool iSOpen=false;
    // Start is called before the first frame update
    void Start()
    {
        NoteObject = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;
    }


    private void OnMouseDown()
    {
        if(iSOpen==false)
        NoteObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

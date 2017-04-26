using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPopup : MonoBehaviour {

    public GameObject target;


    public void Quit()
    {
        Application.Quit();

        Debug.Log("mäh");
    }

    public void Return()
    {
        target.SetActive(false);
    }

    private void Start()
    {
        target.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            target.SetActive(true);            
        }
      
        
	}
}

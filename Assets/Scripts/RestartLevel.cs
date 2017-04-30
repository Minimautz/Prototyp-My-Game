using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

    private int start_count;
    
	void Start () {
        start_count = SaveStatus.count;
        transform.parent.gameObject.SetActive(false);
	}

    public void restartCurrent()
    {
        SaveStatus.count = start_count;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

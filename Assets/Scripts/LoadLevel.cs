using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string levelname;

    public void OnLoadLevel()
    {
        SceneManager.LoadScene(levelname); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShowHide : MonoBehaviour {

    public GameObject target;
    public string comparetag;

	// Use this for initialization
	void Start () {
        target.SetActive(false);	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(comparetag))
        {
            target.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(comparetag))
        {
            target.SetActive(false);
        }
    }
}

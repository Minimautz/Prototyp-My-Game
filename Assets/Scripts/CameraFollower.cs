using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform player;



	// Update is called once per frame
	void Update () {


        float xbla = player.localPosition.x - transform.localPosition.x;
        if (xbla > 0)
        {
            transform.localPosition = new Vector3(player.localPosition.x, player.localPosition.y, transform.localPosition.z); // will da die Koordinaten von Kotzi nutzen
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, player.localPosition.y, transform.localPosition.z);
        }

      
    }
}
      


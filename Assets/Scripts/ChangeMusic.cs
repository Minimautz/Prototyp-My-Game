using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {

    public AudioSource old_music, new_music;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        old_music.Stop();
        new_music.Play();
    }
}

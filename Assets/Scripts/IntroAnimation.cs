using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour {

    public GameObject kotzi;
    public GameObject ui;
    public string levelname;

    private Animator animator;
    
    enum STATE
    {
        enter,
        down,
        wait,
        up,
        exit
    };

    private STATE state = STATE.enter;

	// Use this for initialization
	void Start () {
        animator = kotzi.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        switch (state)
        {
            case STATE.enter:
                {
                    kotzi.transform.Translate(0.05f, 0, 0);
                    if (kotzi.transform.position.x >= 0)
                    {
                        state = STATE.down;
                        animator.SetBool("reached_center", true);
                    }
                    break;
                }
            case STATE.down:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("sitting"))
                    {
                        ui.SetActive(true);
                        state = STATE.wait;
                    }
                    break;
                }
            case STATE.up:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("funkiwalk"))
                        state = STATE.exit;
                    break;
                }
            case STATE.exit:
                {
                    kotzi.transform.Translate(0.05f, 0, 0);
                    if (kotzi.transform.position.x >= 10)
                        SceneManager.LoadScene(levelname);
                    break;
                }
            
        }
    }

    public void StartGame()
    {
        ui.SetActive(false);
        animator.SetBool("reached_center", false);
        animator.SetBool("done", true);

        state = STATE.up;
    }
}

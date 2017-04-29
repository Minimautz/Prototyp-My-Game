using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    enum STATE
    {
        outside,
        enter,
        wait,
        leave
    };

    private STATE state = STATE.outside;
    public GameObject popup;
    public GameObject bird;
	
	// Update is called once per frame
	void FixedUpdate () {
		switch(state)
        {
            case STATE.enter:
                {
                    bird.transform.Translate(0.05f,-0.02f,0);
                    if (bird.transform.position.x - transform.position.x >= 2)
                    {
                        state = STATE.wait;
                        popup.SetActive(true);
                    }
                    break;
                }
            case STATE.leave:
                {
                    bird.transform.Translate(-0.05f, 0.02f, 0);
                    if (bird.transform.position.x - transform.position.x <= -3)
                    {
                        state = STATE.outside;
                    }
                    break;
                }
        }
	}

    public void activate()
    {
        bird.transform.localScale = new Vector2(Mathf.Abs(bird.transform.localScale.x), bird.transform.localScale.y);
        if(state== STATE.outside)
            bird.transform.position = new Vector2(transform.position.x-3, transform.position.y+7);
        state = STATE.enter;
    }

    public void deactivate()
    {
        popup.SetActive(false);

        bird.transform.localScale = new Vector2(- Mathf.Abs(bird.transform.localScale.x), bird.transform.localScale.y);
        state = STATE.leave;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        activate();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        deactivate();
    }
}

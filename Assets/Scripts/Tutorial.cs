using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject player;
    float prevSpeed;
    private Animator animator;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    void Start()
    {
        animator = player.GetComponent<Animator>();
        StartCoroutine(stopanimation());
        StartCoroutine(DelayBeforePause());
    }
    IEnumerator stopanimation()
    {
        yield return new WaitForSeconds(1);
        anim1.enabled = false;
        anim2.enabled = false;
        anim3.enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim1.enabled = true;
            anim2.enabled = true;
            anim3.enabled = true;
        }
    }

    IEnumerator DelayBeforePause()
    {
        yield return new WaitForSeconds(2);
        player.GetComponent<Automove>().Speed_X = 0.2f;
        prevSpeed = animator.speed;
        animator.speed = 0.1f;
        StartCoroutine(DelayDuringPause());
    }

    IEnumerator DelayDuringPause()
    {
        yield return new WaitForSeconds(4);
        player.GetComponent<Automove>().Speed_X = 3f;
        animator.speed = prevSpeed;
    }
}

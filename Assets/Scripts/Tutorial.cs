using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject player;
    float prevSpeed;
    private Animator animator;
    void Start()
    {
        animator = player.GetComponent<Animator>();
        StartCoroutine(DelayBeforePause());
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

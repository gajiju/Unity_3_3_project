using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Animator animator;
    [SerializeField] private StartGame startGame;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0, 0.5f);
            animator.SetBool("Stop", true);

            //startGame.OnMenu(true);
            startGame.OnButton = true;
        }
        transform.position += new Vector3(0, 0, Time.deltaTime * 4);
    }
}

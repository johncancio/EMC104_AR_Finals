using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animationWave()
    {
        animator.SetTrigger("Wave");
    }

    public void animationWalk()
    {
        animator.SetTrigger("Walk");
    }

    public void animationDance()
    {
        animator.SetTrigger("Dance");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControllerSpriter : MonoBehaviour
{
    public Animator PlayerAnimator;

    public void IdleAnimation()
    {
        PlayerAnimator.Play("IdleAnimation");
    }
    public void AtackAnimation()
    {
        PlayerAnimator.Play("AtackAnimations");
    }
    public void BlockAnimation()
    {
        PlayerAnimator.Play("BlockAnimation");
    }


    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("a"))
        // {
        //     AtackAnimation();
        // }
        // if (Input.GetKeyDown("s"))
        // {
        //     BlockAnimation();
        // }

        var input = Input.inputString;
        switch (input)
        {
            case "a":
                AtackAnimation();
                break;

            case "s":
                BlockAnimation();

                break;
                
            default:
                IdleAnimation();
                break;
        }
    }
}

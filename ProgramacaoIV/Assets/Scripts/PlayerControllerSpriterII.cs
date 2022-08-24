using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSpriterII : MonoBehaviour
{
    public Animator PlayerAnimatorII;
    public void IdleAnimation()
    {
        PlayerAnimatorII.Play("IdlePIIAnimation");        
    }
    public void AtackAnimation()
    {
        PlayerAnimatorII.Play("AtackPIIAnimation");
    }
    public void BlockAnimation()
    {
        PlayerAnimatorII.Play("BlockPIIAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        BlockAnimation();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Customer owner, string name) : base(owner, name) { }

    public override void OnEnter()
    {
        owner.movement.Stop();
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }
}

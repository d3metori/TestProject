using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Character
{
    public Cat()
    {
        forceSpeed = 500f;
        rotationSpeed = 700f;
        isRotating = false;
    }

    public override void Move()
    {
        float randFloat = Random.Range(-10f, 10f);
        charRigidbody.AddForce(new Vector2(randFloat, forceSpeed));
        animator.SetTrigger("isBoom");
    }

}
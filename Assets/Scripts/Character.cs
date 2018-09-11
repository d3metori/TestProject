using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    protected Rigidbody2D charRigidbody;
    protected Animator animator;

    public float forceSpeed;
    public float rotationSpeed;
    protected bool isRotating;

    public virtual void Start()
    {
        if(charRigidbody == null)
            charRigidbody = GetComponent<Rigidbody2D>();

        if(animator == null)
            animator = GetComponent<Animator>();
    }

    public virtual void FixedUpdate()
    {
        GroundChecker();
        RotateChar();
    }

    public void GroundChecker()
    {
        if (transform.localRotation.z != 0 && transform.position.y < -3)
        {
            int layerMask = LayerMask.GetMask("Ground", "Obstacle");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, layerMask);

            if (hit != false)
            {
                if (hit.transform.tag == "Ground")
                {
                    if (!isRotating)
                        isRotating = true;
                }
            }
        }
        else
        {
            if (isRotating)
                isRotating = false;
        }
    }

    public void RotateChar()
    {
        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(this.transform.rotation.x, this.transform.rotation.y, 0, 1), step);
        }
    }


    public abstract void Move();

}

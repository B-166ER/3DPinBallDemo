using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Rigidbody selfRigidBody;
    [SerializeField] float anyDirectionLimit;
    [SerializeField] float breakAmount;
    [SerializeField] float zVelocity;
    [SerializeField] float yMaxVelocity;
    float newVelocity;
    
    Vector3 velocityCache;

    void Start()
    {
        selfRigidBody = gameObject.GetComponent<Rigidbody>();
        // which value should apply when velocity passes the threshold.
        newVelocity = anyDirectionLimit - breakAmount;
        // push the ball at the begining.
        selfRigidBody.AddForce(0f, 0f, 100f);

    }

    //Bounciness gets inifintly fast.
    //Limiting Velocity.
    private void FixedUpdate()
    {
        // dont make triple each update. try else if 3 frames to set velocities enough
        velocityCache = selfRigidBody.velocity;
        if (velocityCache.x > anyDirectionLimit)
            velocityCache.x = newVelocity;

        if (Mathf.Abs( velocityCache.y ) > yMaxVelocity)
            velocityCache.y = yMaxVelocity * Mathf.Sign(velocityCache.y);



        if (velocityCache.z < 0)
            velocityCache.z = -newVelocity;
        if (velocityCache.z > 0)
            velocityCache.z = newVelocity;
        selfRigidBody.velocity = velocityCache;
    }

    void Update()
    {
        
    }
}

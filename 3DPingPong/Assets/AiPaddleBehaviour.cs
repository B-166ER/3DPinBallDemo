using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPaddleBehaviour : MonoBehaviour
{
    [SerializeField] BallBehaviour ball;
    [SerializeField] float aiPaddleZPosition;
    Vector3 newPosition;
    private void Start()
    {
        aiPaddleZPosition = transform.position.z;
    }
    private void FixedUpdate()
    {
        newPosition = ball.transform.position;
        newPosition.z = aiPaddleZPosition;
        transform.position = newPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ai bounce");
    }
}

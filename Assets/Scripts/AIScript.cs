using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    [SerializeField] private Transform aiTransform;
    [SerializeField]private Rigidbody body;
    [SerializeField] private float movementVelocity;
    [SerializeField] private Transform pelota;

    private void Start()
    {
        body=GetComponent<Rigidbody>();
       // pelota=GetComponent<Transform>();
    }

    private void Update()
    {
        aiTransform.position=new Vector2(aiTransform.position.x,pelota.position.y);
    }
}

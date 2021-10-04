using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField]
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private Animator controller;

    // Update is called once per frame
    void Update()
    {
        controller.SetFloat("Fast blend", Mathf.Clamp(rigidbody.velocity.x, 0,15) / 15);
    }
}

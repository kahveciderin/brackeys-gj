using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoAnimation : MonoBehaviour
{

    Animator animator;

    SpriteRenderer spriteRenderer;

    public Sprite sprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.sprite = sprite;
    }

}

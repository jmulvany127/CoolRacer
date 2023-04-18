using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Start(){
        _spriteRenderer.sprite = sprite;        
    }
   
}

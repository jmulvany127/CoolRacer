using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VTruck : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Missile"){
            Destroy(this.gameObject);
        }
    }
}

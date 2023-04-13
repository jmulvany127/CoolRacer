using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traffic : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    public string Level1, Level2, Level3;

    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == Level1) {
            _spriteRenderer.sprite = sprites[Random.Range(0, 2)];        
        }
        else if (scene.name == Level2) {
            _spriteRenderer.sprite = sprites[Random.Range(2, 5)];        
        }
        else if (scene.name == Level3) {
            _spriteRenderer.sprite = sprites[Random.Range(5, 8)];        
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Missile"){
            Destroy(this.gameObject);
        }
    }
}

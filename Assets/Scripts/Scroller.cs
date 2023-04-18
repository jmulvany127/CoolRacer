using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;
    public float speed;

    void Start(){
        speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(speed,_y) * Time.deltaTime,_img.uvRect.size);
        if(speed < 2f){
            speed = speed + 0.00005f;
        }

    }
}

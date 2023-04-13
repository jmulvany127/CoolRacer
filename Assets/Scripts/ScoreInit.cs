using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreInit : MonoBehaviour
{
    public GameObject ScoreGen;
    public GameObject Display;
    void start(){
        Instantiate(ScoreGen);
        Instantiate(Display);
    }
    void update(){
        
    }
    
}

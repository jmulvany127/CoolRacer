using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collison : MonoBehaviour
{
    

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //blackole has tag Player
        if(collision.gameObject.tag == "Player")
        {
            //Destroy (collision.gameObject);
            //Debug.Log("Hit Enemy");
            //SceneManager.LoadScene(SceneManager.GetActiveScene());


            //if collision happens get the name of active scene and reload it
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }


    }
}

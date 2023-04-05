using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using TMPro;

public class LoginScript : MonoBehaviour
{
    public TMP_InputField input_email;
    public TMP_InputField input_password;

    public void BeginLogIn() { 
        //todo add log in functionality 

    }

    public void onEndEditEmail() {
        // todo log email
        Debug.Log("EMAIL " + input_email.text);
    } 

    public void onRegisterSelect() {
        // todo
        Debug.Log("REGISTER");
    }

    public void onEndEditPassword() {
        // todo log email
        Debug.Log("PASSWORD " + input_password.text); 
    }
}

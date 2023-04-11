using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;

public class LoginScript : MonoBehaviour
{
    public TMP_InputField input_email;
    public TMP_InputField input_password;
    private FirebaseAuth auth;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseApp.Create();
            InitializeFirebaseAuth();
        });
    }

    void InitializeFirebaseAuth()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void BeginLogIn()
    {
        string email = input_email.text;
        string password = input_password.text;
        SignInWithEmailAndPassword(email, password);
    }

    void SignInWithEmailAndPassword(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }

    public void onEndEditEmail()
    {
        Debug.Log("EMAIL " + input_email.text);
    }

    public void onRegisterSelect()
    {
        string email = input_email.text;
        string password = input_password.text;
        RegisterWithEmailAndPassword(email, password);
    }

    void RegisterWithEmailAndPassword(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }

    public void onEndEditPassword()
    {
        Debug.Log("PASSWORD " + input_password.text);
    }
}



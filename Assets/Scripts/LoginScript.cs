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

    private string user_email;
    private string user_password;
    private bool isValidEmail;

    void Start()
    {
        user_email = "*";
        user_password = "*";
        isValidEmail = false;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
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
        string email = user_email;
        string password = user_password;
        if (email.Equals("*") || password.Equals("*"))
        {
            Debug.Log("not logging in");
        }
        else
        {
            Debug.Log("logging in");
            SignInWithEmailAndPassword(email, password);
            CloudManager.Instance.statsTable(FlowManager.Instance.email); // so that table can update
        }
    }

    void SignInWithEmailAndPassword(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
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
        user_email = input_email.text;
        CloudManager.Instance.username = user_email;
        FlowManager.Instance.email = user_email;
        isValidEmail = CloudManager.Instance.isEmailRegistered(user_email);
    }

    public void onRegisterSelect()
    {
        string email = user_email;
        string password = user_password;
        if (email.Equals("*") || password.Equals("*"))
        {
            Debug.Log("not registering");
        }
        else
        {
            if (!isValidEmail) {
                Debug.Log("not registering, user found");
            } else {
                Debug.Log("registering");
                RegisterWithEmailAndPassword(email, password);
                CloudManager.Instance.SaveData();
            }
        }
    }

    void RegisterWithEmailAndPassword(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
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
        user_password = input_password.text;
        Debug.Log("PASSWORD " + input_password.text);
    }
}



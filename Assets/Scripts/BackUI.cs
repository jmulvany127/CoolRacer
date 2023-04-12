using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackUI : MonoBehaviour
{
    // string varaible
    [SerializeField] private string goBack = "track_menu_1";

    public void BackButton()
    {
        SceneManager.LoadScene(goBack);
    }
}

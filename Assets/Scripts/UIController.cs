using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public Button startButton;
    public Button quitButton;

    void OnEnable(){
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");
        quitButton = root.Q<Button>("quit-button");

        //subscribes start and quit game functions to button events
        startButton.clicked += StartGame;
        quitButton.clicked += QuitGame;
    }

    void QuitGame(){ //exits the game (in build)
        Application.Quit();
    }

    void StartGame(){
        SceneManager.LoadScene("Gameplay");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

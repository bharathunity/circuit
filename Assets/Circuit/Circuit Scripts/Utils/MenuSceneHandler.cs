using Circuit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneHandler : MonoBehaviour
{
    [SerializeField] Button startGameButton;

    private SceneHandler _sceneHandler;

    private void Awake()
    {
        _sceneHandler = new SceneHandler();
        startGameButton.onClick.AddListener(StartGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartGame()
    {

        _sceneHandler.ChangeScene(SceneHandler.Scene.Game);
        Debug.Log($"{nameof(StartGame)}");

    }

    
}

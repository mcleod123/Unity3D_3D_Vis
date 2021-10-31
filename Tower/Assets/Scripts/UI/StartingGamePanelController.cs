using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingGamePanelController : MonoBehaviour
{

    [SerializeField] private Button _startGameButton;



    // Start is called before the first frame update
    void Start()
    {
        _startGameButton.onClick.AddListener(StartGameButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void StartGameButtonOnClick()
    {
        gameObject.SetActive(false);
        GameController.Instance.StartGame();
    }









}

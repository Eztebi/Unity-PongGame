using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    GameManager gameManager;
    public static GameManager instance { get; private set; }

    //Eventos puerta
    public event Action player1Score;
    public event Action player2Score;
    public bool Score1;
    public bool Score2;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        Score1 = false;
        Score2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Player _player;
    public Player Player
    {
        get
        {
            if (_player == null) _player = FindObjectOfType<Player>();
            return _player;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ideas for code came from Brackeys https://www.youtube.com/watch?v=xppompv1DBg&t=1s

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}

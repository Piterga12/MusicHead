using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayButton : MonoBehaviour
{

    public static event Action<int> changeScene = delegate { };

    void OnMouseDown()
    {
        changeScene(1);
    }
}

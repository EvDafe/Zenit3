using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

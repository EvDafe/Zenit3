using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneChooseHandler : MonoBehaviour
{
    public static int PlaneIndex = 0;

    public void SelectPlane(int index)
    {
        PlaneIndex = index;
    }
}

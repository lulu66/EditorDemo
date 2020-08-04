using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [HideInInspector]
    [SerializeField]
    Rect mMyRect;
    public Rect MyRect
    {
        get { return mMyRect; }
        set { mMyRect = value; }
    }
    [HideInInspector]
    [SerializeField]
    Texture mMyTexture;

    public Texture MyTexture
    {
        get { return mMyTexture; }
        set { mMyTexture = value; }
    }
}

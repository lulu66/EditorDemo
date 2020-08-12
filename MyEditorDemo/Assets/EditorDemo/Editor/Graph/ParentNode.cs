using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class ParentNode : ScriptableObject {

    [SerializeField]
    private Rect mPosition;

    [SerializeField]
    private int mUniqueId;

    [SerializeField]
    private Rect mLastPosition;

    [SerializeField]
    protected GUIContent mContent;
    protected Rect mCachedPostion;          //为什么要添加一个CachedPos

    //输入槽

    //输出槽


    public Rect Position { get { return mPosition; } }
    public Rect CachedPosition { get { return mCachedPostion; } }

    //定义一堆跟node有关的事件
    public delegate void OnNodeEvent();
    public delegate void OnNodeGenericEvent();

    public event OnNodeEvent OnNodeStoppedMovingEvent;
    public OnNodeGenericEvent OnNodeChangeSizeEvent;

    public ParentNode()
    {
        mPosition = new Rect(0,0,0,0);
        mContent = new GUIContent(GUIContent.none);
    }

}

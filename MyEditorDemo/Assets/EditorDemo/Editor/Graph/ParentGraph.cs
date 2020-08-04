using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class ParentGraph : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<ParentNode> mNodes = new List<ParentNode>();

    private MainWindow mParentWindow;
    public MainWindow ParentWindow
    {
        set { mParentWindow = value; }
        get { return mParentWindow; }
    }

    private NodeGrid mNodeGrid;


    public void CleanGraph()
    {

    }

    public void OnAfterDeserialize()
    {
        throw new NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}

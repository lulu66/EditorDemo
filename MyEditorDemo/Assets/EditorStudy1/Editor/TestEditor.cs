using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
[ExecuteInEditMode]
public class TestEditor : Editor {

    public override void OnInspectorGUI()
    {
        Test myTest = target as Test;
        myTest.MyRect = EditorGUILayout.RectField("窗口坐标", myTest.MyRect);
        myTest.MyTexture = EditorGUILayout.ObjectField("纹理", myTest.MyTexture, typeof(Texture), true) as Texture;
    }
}

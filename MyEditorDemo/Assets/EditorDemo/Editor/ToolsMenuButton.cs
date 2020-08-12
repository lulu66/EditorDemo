using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;



public sealed class ToolsMenuButton{

    public delegate void ButtonPressed(ToolButtonType buttonType);
    public event ButtonPressed ButtonPressedEvt;

    private GUIContent buttonContent;
    private MainWindow mainWindow;
    private Rect buttonArea;
    private ToolButtonType buttonType;
    private GUIStyle buttonStyle;

    public ToolsMenuButton(MainWindow _mainWindow, float _x, float _y, float _width, float _height, string _content, string _tooltipTex,ToolButtonType _buttonType)
    {
        mainWindow = _mainWindow;
        buttonArea = new Rect(_x, _y, _width, _height);
        buttonContent = new GUIContent(_content, _tooltipTex);
        buttonType = _buttonType;
    }

    public void Init()
    {
        //init button style
        buttonStyle = new GUIStyle(GUI.skin.textArea);
        buttonStyle.stretchHeight = true;
        buttonStyle.stretchWidth = true;
        buttonStyle.fontSize = 13;
        buttonStyle.fontStyle = FontStyle.Normal;
    }

    public void Destroy()
    {
        ButtonPressedEvt = null;
    }
    public void Draw(float x, float y)
    {
        buttonArea.x = x;
        buttonArea.y = y;
        if(GUILayout.Button(buttonContent) && ButtonPressedEvt!=null)
        {
            ButtonPressedEvt(buttonType);
        }
    }

    public bool IsInside(Vector2 pos)
    {
        return buttonArea.Contains(pos);
    }
}

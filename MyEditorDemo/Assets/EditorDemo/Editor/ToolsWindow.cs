using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

//怎么判断鼠标在某一个按钮上？
public enum ToolButtonType
{
    Update,
    Live,
    OpenSourceCode,
    ClearUnusedNode,
    ShowInfo,
    FoucusOnMasterNode,
    FoucusOnSelection,
    None,
};

[Serializable]
public sealed class ToolsWindow{

    private MainWindow mainWindow;
    ToolsMenuButton.ButtonPressed buttonPressedEvt;
    ToolsMenuButton updateButton;
    ToolsMenuButton liveButton;
    ToolsMenuButton openSourceButton;
    ToolsMenuButton clearUnusedNodeButton;
    ToolsMenuButton showInfoButton;
    ToolsMenuButton foucusOnMasterNodeButton;
    ToolsMenuButton foucusOnSelectionButton;

    public ToolsWindow(MainWindow _mainWindow)
    {
        mainWindow = _mainWindow;
        updateButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "update", "update", ToolButtonType.Update);
        updateButton.ButtonPressedEvt += OnButtonPressedEvt;
        liveButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "live", "live", ToolButtonType.Live);
        liveButton.ButtonPressedEvt += OnButtonPressedEvt;
        openSourceButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "openSource", "openSource", ToolButtonType.OpenSourceCode);
        openSourceButton.ButtonPressedEvt += OnButtonPressedEvt;
        clearUnusedNodeButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "clearUnused", "clearUnused", ToolButtonType.ClearUnusedNode);
        clearUnusedNodeButton.ButtonPressedEvt += OnButtonPressedEvt;
        showInfoButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "showInfo", "showInfo", ToolButtonType.ShowInfo);
        showInfoButton.ButtonPressedEvt += OnButtonPressedEvt;
        foucusOnMasterNodeButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "foucusOnMasterNode", "foucusOnMasterNode", ToolButtonType.ShowInfo);
        foucusOnMasterNodeButton.ButtonPressedEvt += OnButtonPressedEvt;
        foucusOnSelectionButton = new ToolsMenuButton(_mainWindow, 0, 0, -1, -1, "foucusOnSelection", "foucusOnSelection", ToolButtonType.ShowInfo);
        foucusOnSelectionButton.ButtonPressedEvt += OnButtonPressedEvt;
    }

    void OnButtonPressedEvt(ToolButtonType buttonType)
    {
        if (buttonPressedEvt != null)
            buttonPressedEvt(buttonType);
    }
    public void Draw(Rect buttonArea, Vector2 mousePosition, int mouseId, bool hasKeyboardFocus)
    {
        //响应条件
        if(mainWindow.CurrentEvent.type == EventType.MouseDrag && mainWindow.CurrentEvent.button > 0)
        {

        }
    }
}

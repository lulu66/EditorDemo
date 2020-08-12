using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainWindow : SearchableEditorWindow {

    

    [SerializeField]
    private ParentGraph mainGraphInstance;

    private ToolsWindow toolsWindow;

    private string mText;
    private Texture mTexture;
    
    private Event mCurrentEvent;

    public Event CurrentEvent
    {
        get { return mCurrentEvent; }
    }

    [MenuItem("Window/MyEditor/Open")]
    static void OpenMainWindow()
    {
        MainWindow mainWindow = ShowWindow();
        //将graph放到window中
        mainWindow.CreateNewGraph("Empty");

    }

    static MainWindow ShowWindow()
    {
        MainWindow mainWindow = EditorWindow.CreateInstance<MainWindow>();
        mainWindow.minSize = new Vector2(480, 270);
        mainWindow.titleContent.text = "Empty";
        mainWindow.titleContent.image = Utils.ShaderIcon;
        mainWindow.wantsMouseMove = true;               //鼠标移动的时候可以返回鼠标的位置，不会自动调用Repaint函数，要手动调用
        mainWindow.Show();
        return mainWindow;
    }

    private void CreateNewGraph(string graphName)
    {
        if (mainGraphInstance == null)
        {
            mainGraphInstance = CreateInstance<ParentGraph>();
            mainGraphInstance.ParentWindow = this;
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        toolsWindow = new ToolsWindow(this);
    }

    private void OnGUI()
    {
        mCurrentEvent = Event.current;
    }

}

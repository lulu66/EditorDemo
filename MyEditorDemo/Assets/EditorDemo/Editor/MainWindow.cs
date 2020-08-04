using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainWindow : SearchableEditorWindow {

    public static Texture ShaderIcon { get { return EditorGUIUtility.IconContent("Shader Icon").image; } }

    [SerializeField]
    private ParentGraph mainGraphInstance;

    private Rect mCameraInfo;
    private Rect mGraphArea;
    private Texture2D mGraphBgTexture;
    private Texture2D mGraphFgTexture;


    private string mText;
    private Texture mTexture;

    [MenuItem("Window/MyEditor/Open")]
    static void OpenMainWindow()
    {
        MainWindow mainWindow = EditorWindow.CreateInstance<MainWindow>();
        mainWindow.minSize = new Vector2(300,200);
        mainWindow.titleContent.text = "Empty";
        mainWindow.titleContent.image = ShaderIcon;
        mainWindow.wantsMouseMove = true;               //鼠标移动的时候可以返回鼠标的位置，不会自动调用Repaint函数，要手动调用
        //将graph放到window中
        mainWindow.CreateNewGraph("Empty");
        mainWindow.Show();
    }

    private void Awake()
    {
        mTexture = Resources.Load<Texture>("/colorTex/blue");
    }
    private void CreateNewGraph(string graphName)
    {
        if(mainGraphInstance == null)
        {
            mainGraphInstance = CreateInstance<ParentGraph>();
            mainGraphInstance.ParentWindow = this;
        }
    }

    private void Init()
    {
        mGraphBgTexture = AssetDatabase.LoadAssetAtPath("Assets//EditorDemo//EditorResources//UI//Canvas//Grid128.png", typeof(Texture2D)) as Texture2D;
        if(mGraphBgTexture!=null)
        {
            mGraphFgTexture = AssetDatabase.LoadAssetAtPath("Assets//EditorDemo//EditorResources//UI//Canvas//TransparentOverlay.png", typeof(Texture2D)) as Texture2D;
        }
        mCameraInfo = position;
        mGraphArea = new Rect(0, 0, mCameraInfo.width, mCameraInfo.height);
    }
    private void OnGUI()
    {
        mText = EditorGUILayout.TextField("输入文字：",mText);
        EditorGUILayout.LabelField("Mouse Position:", Event.current.mousePosition.ToString());

        if(GUILayout.Button("打开通知",GUILayout.Width(200)))
        {
            this.ShowNotification(new GUIContent("This is a Notification."));
        }
        if (GUILayout.Button("关闭通知", GUILayout.Width(200)))
        {
            //关闭通知栏
            this.RemoveNotification();
        }
        mTexture = EditorGUILayout.ObjectField("添加贴图", mTexture, typeof(Texture), true) as Texture;
        if(GUILayout.Button("关闭窗口",GUILayout.Width(200)))
        {
            this.Close();
        }

    }
    void OnFocus()
    {
        Debug.Log("当窗口获得焦点时调用一次");
    }

    void OnLostFocus()
    {
        Debug.Log("当窗口丢失焦点时调用一次");
    }

    private void OnInspectorUpdate()
    {
        this.Repaint();
    }
}

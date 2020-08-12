using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainWindow : SearchableEditorWindow {

    

    [SerializeField]
    private ParentGraph mainGraphInstance;

    private ToolsWindow toolsWindow;

    private string mText;
    private Texture2D mFgTexture;
	private Texture2D mBgTexture;

    private Event mCurrentEvent;
	private Rect mGraphArea;

	private bool mInitialized = false;
	[SerializeField]
	private Vector2 mCameraOffset;

	[SerializeField]
	private float mCameraZoom;

	private Rect mCameraInfo;

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
		mCameraOffset = new Vector2(0,0);
		mCameraZoom = 1;

	}

	void init()
	{
		mGraphArea = new Rect(0,0,position.width, position.height);
		mCameraInfo = position;
		mBgTexture = AssetDatabase.LoadAssetAtPath("Assets\\EditorDemo\\EditorResources\\UI\\Canvas\\Grid128.png", typeof(Texture2D)) as Texture2D;
		if(mBgTexture)
		{
			mFgTexture = AssetDatabase.LoadAssetAtPath("Assets\\EditorDemo\\EditorResources\\UI\\Canvas\\TransparentOverlay.png", typeof(Texture2D)) as Texture2D;
		}
		mInitialized = mBgTexture != null && mFgTexture != null;
	}
    private void OnGUI()
    {
        mCurrentEvent = Event.current;
		if(!mInitialized)
		{
			init();
		}
		GUI.DrawTextureWithTexCoords(mGraphArea, mBgTexture, new Rect((-mCameraOffset.x / mBgTexture.width),
								(mCameraOffset.y / mBgTexture.height) - mCameraZoom * mCameraInfo.height / mBgTexture.height,
								mCameraZoom * mCameraInfo.width / mBgTexture.width,
								mCameraZoom * mCameraInfo.height / mBgTexture.height));
		Color col = GUI.color;
		GUI.color = new Color(1, 1, 1, 0.7f);
		GUI.DrawTexture(mGraphArea, mFgTexture, ScaleMode.StretchToFill, true);
		GUI.color = col;

	}

	private void Destroy()
	{
		Resources.UnloadAsset(mFgTexture);
		Resources.UnloadAsset(mBgTexture);
	}
}

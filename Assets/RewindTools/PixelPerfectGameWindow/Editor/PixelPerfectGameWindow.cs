using UnityEditor;
using UnityEngine;
using System.Collections;

[InitializeOnLoad]
public static class FullscreenPlayMode {

	//The size of the toolbar above the game view, excluding the OS border.
	private static int tabHeight = 22;
	public static Vector2 gameSize;
	public static Vector2 gamePosition;
	private static KeyCode quitKeycode;
	private static bool fspEnabled;
	
	static bool quitting = false;
	
	static FullscreenPlayMode()
	{
		UpdateEditorPrefs();
		EditorApplication.playmodeStateChanged -= CheckPlayModeState;
		EditorApplication.playmodeStateChanged += CheckPlayModeState;
		EditorApplication.update += CheckExitKey;
	}
	
	static void CheckExitKey()
	{
		if (EditorApplication.isPlaying && fspEnabled)
		{
			if (Input.GetKey(quitKeycode) && !quitting)
			{
				quitting = true;
				EditorApplication.isPlaying = false;
			}
		}
	}
	
	static void CheckPlayModeState()
	{
		if (fspEnabled)
		{
			if (EditorApplication.isPlayingOrWillChangePlaymode)
			{
				SaveGameViewSettings();
			}
			else
			{
				CloseGameWindow();
				quitting = false;
			}
			
			if (EditorApplication.isPlaying)
			{
				FullScreenGameWindow();
			}
		}
	}
	
	static EditorWindow GetMainGameView(){
		EditorApplication.ExecuteMenuItem("Window/Game");
		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetMainGameView = T.GetMethod("GetMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetMainGameView.Invoke(null,null);
		return (EditorWindow)Res;
	}
	
	static void UpdateEditorPrefs()
	{
		gameSize = new Vector2(EditorPrefs.GetInt("PPGW_GameSizeX"),EditorPrefs.GetInt("PPGW_GameSizeY"));
		gamePosition = new Vector2(EditorPrefs.GetInt("PPGW_GamePosX"),EditorPrefs.GetInt("PPGW_GamePosY"));
		SetQuitKey(EditorPrefs.GetInt("PPGW_QuitKeyIndex"));
		fspEnabled = EditorPrefs.GetBool("PPGW_Enabled");
	}
	
	static void SetQuitKey(int p_Index)
	{
		switch (p_Index)
		{
		 case 0:
		 quitKeycode = KeyCode.Escape;
		 break;
		 case 1:
		 quitKeycode = KeyCode.F1;
		 break;
		 case 2:
		 quitKeycode = KeyCode.End;
		 break;
		 case 3:
		 quitKeycode = KeyCode.KeypadMinus;
		 break;
		}
	}	
	
	static void FullScreenGameWindow(){
		
		UpdateEditorPrefs ();
	
		/*
		EditorWindow gameView = GetMainGameView ();
	
		gameView.title = "Game (Fullscreen)";
		
		Rect newPos = new Rect (gamePosition.x, gamePosition.y - tabHeight, gameSize.x, gameSize.y + tabHeight);
		
		gameView.position = newPos;
		gameView.minSize = new Vector2 (gameSize.x, gameSize.y + tabHeight);
		gameView.maxSize = gameView.minSize;
		gameView.position = newPos;	
*/
		SetGameWindow (gameSize, gamePosition);
		
	}

	public static void SetGameWindow(Vector2 p_Size, Vector2 p_Position)
	{
		EditorWindow gameView = GetMainGameView();


		Rect newPos = new Rect(p_Position.x, p_Position.y - tabHeight, p_Size.x, p_Size.y + tabHeight);
		
		gameView.position = newPos;
		gameView.minSize = new Vector2(p_Size.x, p_Size.y + tabHeight);
		gameView.maxSize = gameView.minSize;
		gameView.position = newPos;	
	}
	
	static void SaveGameViewSettings()
	{
		System.Type T = System.Type.GetType("UnityEditor.WindowLayout,UnityEditor");
		System.Reflection.MethodInfo SaveLayoutMethod = T.GetMethod("SaveWindowLayout", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
		SaveLayoutMethod.Invoke(null,new object[] { "PPGW_PreviousLayout" });
	}
	
	static void CloseGameWindow()
	{
		System.Type T = System.Type.GetType("UnityEditor.WindowLayout,UnityEditor");
		System.Reflection.MethodInfo SaveLayoutMethod = T.GetMethod("LoadWindowLayout");
		SaveLayoutMethod.Invoke(null,new object[] { "PPGW_PreviousLayout", false }); 
	} 
}

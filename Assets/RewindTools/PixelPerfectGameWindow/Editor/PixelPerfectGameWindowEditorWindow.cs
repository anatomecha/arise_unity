using UnityEditor;
using UnityEngine;
using System.Collections;

namespace RWDTools
{
	public class PixelPerfectGameWindowEditorWindow : EditorWindow
	{
		[MenuItem ("Window/Pixel Perfect Game Window")]
		static void OpenPopup() {

			PPGWWindow = (PixelPerfectGameWindowEditorWindow) (EditorWindow.GetWindow(typeof(PixelPerfectGameWindowEditorWindow)));

			Vector2 minSize = new Vector2(300, 228);

			PPGWWindow.minSize = minSize;
			PPGWWindow.maxSize = minSize;

			//PPGWWindow.titleContent = new GUIContent("Pixel Perfect Game Window Settings");

			PPGWWindow.ShowPopup();
		}

		static PixelPerfectGameWindowEditorWindow PPGWWindow;

		private static Vector2 _gameSize;
		static Vector2 gameSize {
			get { return _gameSize; }
			set 
			{ 
				_gameSize = value; 
				EditorPrefs.SetInt("PPGW_GameSizeX",Mathf.RoundToInt(_gameSize.x));
				EditorPrefs.SetInt("PPGW_GameSizeY",Mathf.RoundToInt(_gameSize.y));
			}
		}
	
		private static Vector2 _gamePosition;
		static Vector2 gamePosition {
			get { return _gamePosition; }
			set 
			{ 
				_gamePosition = value; 
				EditorPrefs.SetInt("PPGW_GamePosX",Mathf.RoundToInt(_gamePosition.x));
				EditorPrefs.SetInt("PPGW_GamePosY",Mathf.RoundToInt(_gamePosition.y));
			}
		}
	
		private static int _quitKeyIndex;
		static int quitKeyIndex {
			get { return _quitKeyIndex; }
			set 
			{ 
				_quitKeyIndex = value; 
				EditorPrefs.SetInt("PPGW_QuitKeyIndex",_quitKeyIndex);
			}
		}

		private static int _presetIndex;
		static int presetIndex {
			get { return _presetIndex; }
			set 
			{ 
				_presetIndex = value; 
				EditorPrefs.SetInt("PPGW_PresetIndex",_presetIndex);
			}
		}
	
		public static string[] viableQuitKeycodes = new string[] { "Escape" , "F1" , "End" , "Keypad Minus"  };
		KeyCode quitKeycode;
	
		private static bool _ppgwEnabled = false;
		static bool ppgwEnabled {
			get { return _ppgwEnabled; }
			set 
			{ 
				_ppgwEnabled = value; 
				EditorPrefs.SetBool("PPGW_Enabled",_ppgwEnabled);
			}
		}

		void OnEnable()
		{
			LoadEditorPrefs();
		
			if (gameSize == Vector2.zero)
			{
				gameSize = new Vector2(Screen.currentResolution.width,Screen.currentResolution.height);
			}		
		}
	
		void LoadEditorPrefs()
		{
			_gameSize = new Vector2(EditorPrefs.GetInt("PPGW_GameSizeX"),EditorPrefs.GetInt("PPGW_GameSizeY"));
			_gamePosition = new Vector2(EditorPrefs.GetInt("PPGW_GamePosX"),EditorPrefs.GetInt("PPGW_GamePosY"));
			_quitKeyIndex = EditorPrefs.GetInt("PPGW_QuitKeyIndex");
			_ppgwEnabled = EditorPrefs.GetBool("PPGW_Enabled");
			_presetIndex = EditorPrefs.GetInt("PPGW_PresetIndex");
		}

		void LoadPreset(int p_Index)
		{
			int width = EditorPrefs.GetInt ("PPGW_Preset_" + p_Index + "_Width");
			int height = EditorPrefs.GetInt ("PPGW_Preset_" + p_Index + "_Height");
			int posx = EditorPrefs.GetInt ("PPGW_Preset_" + p_Index + "_PosX");
			int posy = EditorPrefs.GetInt ("PPGW_Preset_" + p_Index + "_PosY");

			gameSize = new Vector2 (width, height);
			gamePosition = new Vector2 (posx, posy);
		}

		void SavePreset(int p_Index)
		{
			EditorPrefs.SetInt ("PPGW_Preset_" + p_Index + "_Width", (int) gameSize.x);
			EditorPrefs.SetInt ("PPGW_Preset_" + p_Index + "_Height", (int)  gameSize.y);
			EditorPrefs.SetInt ("PPGW_Preset_" + p_Index + "_PosX", (int)  gamePosition.x);
			EditorPrefs.SetInt ("PPGW_Preset_" + p_Index + "_PosY", (int)  gamePosition.y);

		}
	
		void OnGUI()
		{
			GUILayout.Label ("Pixel Perfect Game Window Settings", RWDStyles.Heading);

			GUILayout.BeginVertical(RWDStyles.Section);

			GUIContent PresetTitle = new GUIContent("Presets", "Presets \n\nYou can save and load presets here.");
			GUILayout.Label(PresetTitle, RWDStyles.SubHeading);

			GUILayout.BeginHorizontal();
			presetIndex = EditorGUILayout.Popup(presetIndex, new string[] { "Preset 1", "Preset 2", "Preset 3", "Preset 4", "Preset 5" });
			if (GUI.changed)
			{
				LoadPreset(presetIndex);
			}
			if (GUILayout.Button("Save Preset"))
			{
				SavePreset(presetIndex);
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();

			GUILayout.BeginVertical (RWDStyles.Section);

			GUIContent PlayModeTitle = new GUIContent("Play Mode Settings", "Play Mode Settings \n\nThese settings are applied when you press the play button.");
			GUILayout.Label(PlayModeTitle, RWDStyles.SubHeading);

			ppgwEnabled = EditorGUILayout.Toggle("Play Mode", ppgwEnabled);
			quitKeyIndex = EditorGUILayout.Popup("Exit Play Mode", quitKeyIndex, viableQuitKeycodes);

			GUILayout.EndVertical();

		

			GUILayout.BeginVertical (RWDStyles.Section);

			GUILayout.BeginHorizontal(GUIStyle.none);
			GUIContent SizeTitle = new GUIContent("Size", "Size \n\nThe size, in pixels, of your game window.");
			GUILayout.Label(SizeTitle, RWDStyles.SubHeading, GUILayout.Width(60));

			Vector2 newGameSize = EditorGUILayout.Vector2Field("",new Vector2((int)gameSize.x, (int)gameSize.y), GUILayout.Height(12));
			if ((newGameSize != gameSize))
			{
				gameSize = new Vector2((int) (newGameSize.x > 1 ? newGameSize.x : 1), (int) (newGameSize.y > 1 ? newGameSize.y : 1));
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(GUIStyle.none);

			GUIContent PositionTitle = new GUIContent("Position", "Position \n\nThe position, relative to the top left of your primary monitor, in pixels, of the top left of the game window.");
			GUILayout.Label(PositionTitle, RWDStyles.SubHeading, GUILayout.Width(60));

			Vector2 newGamePosition = EditorGUILayout.Vector2Field("", new Vector2((int)gamePosition.x, (int)gamePosition.y), GUILayout.Height(12));
			if ((newGamePosition != gamePosition))
			{
				gamePosition = new Vector2((int)newGamePosition.x, (int)newGamePosition.y);
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical ();


			GUILayout.BeginHorizontal (RWDStyles.Section);
			GUIContent OverrideTitle = new GUIContent("Override Editor Position", "Override Editor Position \n\nThis button will set your game window to the specified position and size, whether in play more or not.");
			if (GUILayout.Button (OverrideTitle)) 
			{
				FullscreenPlayMode.SetGameWindow(gameSize,gamePosition);
				PPGWWindow.Focus();
			}
			GUILayout.EndHorizontal ();
			
		}
	
		static void CloseGameWindow()
		{
			System.Type T = System.Type.GetType("UnityEditor.WindowLayout,UnityEditor");
			System.Reflection.MethodInfo SaveLayoutMethod = T.GetMethod("LoadWindowLayout");
			SaveLayoutMethod.Invoke(null,new object[] { "PPGW_PreviousLayout", false }); 
		}
	}
}
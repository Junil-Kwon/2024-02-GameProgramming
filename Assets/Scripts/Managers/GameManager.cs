using UnityEngine;

#if UNITY_EDITOR
	using UnityEditor;
	using static UnityEditor.EditorGUILayout;
#endif



// ====================================================================================================
// Game Manager Editor
// ====================================================================================================

#if UNITY_EDITOR
	[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
	public class GameManagerEditor : Editor {

		GameManager I => target as GameManager;

		void OnEnable() {
		}

		public override void OnInspectorGUI() {
			serializedObject.Update();
			Space();
			serializedObject.ApplyModifiedProperties();
			if (GUI.changed) EditorUtility.SetDirty(target);
		}
	}
#endif



// ====================================================================================================
// Game Manager
// ====================================================================================================

public class GameManager : MonoSingleton<GameManager> {

	// Serialized Fields



	// Properties



	// Methods



	// Lifecycle

	Vector2 pointPosition;
	Vector3 rotation;

	void Update() {
		if (UIManager.I.ActiveCanvas == CanvasType.Game) {
			if (InputManager.I.GetKeyDown(KeyAction.LeftClick)) {
				Ray ray = CameraManager.I.ScreenPointToRay(InputManager.I.PointPosition);
				if (Physics.Raycast(ray, out RaycastHit hit)) {
					Debug.Log(hit.point);
				}
			}
			if (InputManager.I.GetKeyDown(KeyAction.RightClick)) {
				pointPosition = InputManager.I.PointPosition;
				rotation = CameraManager.I.Rotation;
			}
			if (InputManager.I.GetKey(KeyAction.RightClick)) {
				float mouseSensitivity = UIManager.I.MouseSensitivity;
				float delta = InputManager.I.PointPosition.x - pointPosition.x;
				CameraManager.I.Rotation = rotation + new Vector3(0, delta * mouseSensitivity, 0);
			}
		}
		{
			Vector3 direction = new();
			direction += CameraManager.I.transform.right   * InputManager.I.MoveDirection.x;
			direction += CameraManager.I.transform.forward * InputManager.I.MoveDirection.y;
			direction.y = 0;
			direction.Normalize();
			transform.position += direction * 4 * Time.deltaTime;
		}
	}
}

using UnityEngine;



public class MonoSingleton<T> : MonoBehaviour where T : Object {
    
	public static T Instance { get; set; }

	void Awake() {
		if (Instance == null) {
			Instance = this as T;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}

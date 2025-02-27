using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
	#region Properties
	public event Action OnKeyDamage;
	public event Action OnKeyHeal;
	public event Action OnKeyPoints;
	public event Action OnKeyLevel;

	#endregion
	#region Fields
	//[SerializeField] private EventSystem _eventSystem;

	#endregion


	#region Unity Callbacks
	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyUp(KeyCode.Return))
			OnKeyDamage?.Invoke();
		if (Input.GetKeyUp(KeyCode.Space))
			OnKeyHeal?.Invoke();
		if (Input.GetKeyUp(KeyCode.Escape))
			OnKeyPoints?.Invoke();
		if (Input.GetKeyUp(KeyCode.Backspace))
			OnKeyLevel?.Invoke();
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion

}

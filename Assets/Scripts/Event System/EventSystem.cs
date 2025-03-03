using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Points _points;
	[SerializeField] private Health _payerHealth;
	[SerializeField] private UIControllerInventory _ui;
	[SerializeField] private SoundController _sound;
	[SerializeField] private InputSystem _inputSystem;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		//Event Listener
		_payerHealth.OnGetDamage += OnGetDamage;
		_payerHealth.OnGetHeal += OnGetHeal;
		_payerHealth.OnDie += OnDie;
		_points.OnGetPoints += OnAddPoints;
		_points.OnAddLevel += OnAddLevel;

		_inputSystem.OnKeyDamage += OnKeyDamage;
		_inputSystem.OnKeyHeal += OnKeyHeal;
		_inputSystem.OnKeyPoints += OnKeyPoints;
		_inputSystem.OnKeyLevel += OnKeyLevel;
	}

	#endregion

	#region Public Methods
	public void OnKeyDamage()
	{		
		_payerHealth.GetDamage(20);
	}
	public void OnKeyHeal()
	{
		_payerHealth.GetHeal(20);
	}
	public void OnKeyPoints()
	{
		_points.AddPoints(200);
	}
	public void OnKeyLevel()
	{
		_points.AddLevel(1);
	}

	#endregion
	#region Private Methods
	private void OnGetDamage()
	{
		_sound.PlayDamageSound();
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
		
	}
	private void OnGetHeal()
	{
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
		Destroy(_payerHealth.gameObject);
	}
	private void OnAddPoints()
	{
		_ui.UpdatePoints(_points.CurrentPoints);
	}
	private void OnAddLevel()
	{
		_ui.UpdateLevel(_points.CurrentLevel);
	}
	#endregion

}

using System;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(IDamageApplier))]
	public class HideOnDamageApplied : MonoBehaviour
	{
		[SerializeField] private GameObject _visual;
		[SerializeField] private Collider2D _collider2D;
		
		private IDamageApplier _damageApplier;

		public event Action<GameObject> OnHide;

		private void Awake()
		{
			_damageApplier = GetComponent<IDamageApplier>();
		}
		
		private void OnEnable()
		{
			_damageApplier.OnDamageApplied += HandleDamageApplied;
		}

		private void OnDisable()
		{
			_damageApplier.OnDamageApplied -= HandleDamageApplied;
		}
		
		private void HandleDamageApplied(Health _)
		{
			_collider2D.enabled = false;
			_visual.SetActive(false);
			
			OnHide?.Invoke(_visual);
		}
	}
}
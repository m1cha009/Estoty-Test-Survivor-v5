using System;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(Stats))]
	public class Health : MonoBehaviour
	{
		[field: SerializeField] public float CurrentHealth { get; private set; }
		[field: SerializeField] public float MaxHealth { get; private set; }
		
		private Stats _stats;
		private float _healMultiplier = 1;
		
		public bool IsDead => CurrentHealth <= 0;
		
		public event Action<float> OnHealthChanged;
		public event Action OnDeath;

		private void Awake()
		{
			_stats = GetComponent<Stats>();
			
			_stats.OnStatChanged += HandleStatChanged;
		}

		private void OnDestroy()
		{
			_stats.OnStatChanged -= HandleStatChanged;
		}

		public void SetupCurrentHealth()
		{
			CurrentHealth = _stats.GetStat(StatType.MaxHealth);
		}
		
		public void ApplyDamage(float damage)
		{
			float change = Mathf.Clamp(damage, 0, CurrentHealth);
			CurrentHealth -= change;
			
			OnHealthChanged?.Invoke(change);

			if (IsDead)
			{
				OnDeath?.Invoke();
			}
		}

		public void Heal(float healAmount)
		{
			float change = Mathf.Clamp(healAmount * _healMultiplier, 0, MaxHealth - CurrentHealth);
			CurrentHealth += change;
			
			OnHealthChanged?.Invoke(change);
		}
		
		public void SetHealMultiplier(float healMultiplier) => _healMultiplier = healMultiplier;

		private void HandleStatChanged(StatType statType, float value)
		{
			if (statType == StatType.MaxHealth)
			{
				MaxHealth = value;
			}
		}
	}
}
using System;
using Code.Gameplay.LevelUp.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Lifetime.Behaviours
{
	public class Xp : MonoBehaviour
	{
		private ILevelUpService _levelUpService;
		private float _currentXp;

		[field: SerializeField] public float CurrentXp { get; private set; }
		
		[field: SerializeField] public float MaxXp { get; private set; }

		[Inject]
		private void Construct(ILevelUpService levelUpService)
		{
			_levelUpService = levelUpService;
			
			_levelUpService.OnLevelChanged += OnLevelChanged;
		}

		private void Start()
		{
			MaxXp = _levelUpService.GetMaxXp();
		}

		private void OnDestroy()
		{
			_levelUpService.OnLevelChanged -= OnLevelChanged;
		}

		private void OnLevelChanged(float newLevel)
		{
			CurrentXp = 0;
			MaxXp = _levelUpService.GetMaxXp();
		}

		public void AddXp(float xp)
		{
			CurrentXp += xp;
			
			_levelUpService.SetXp(CurrentXp);
		}
	}
}
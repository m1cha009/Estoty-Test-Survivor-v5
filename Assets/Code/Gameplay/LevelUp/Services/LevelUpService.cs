using System;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.ConfigsManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelUp.Services
{
	public class LevelUpService : ILevelUpService
	{
		private IHeroProvider _heroProvider;
		private IConfigsService _configsService;

		public event Action<float> OnLevelChanged;

		[Inject]
		private void Construct(IConfigsService configsService ,IHeroProvider heroProvider)
		{
			_configsService = configsService;
			_heroProvider = heroProvider;
		}

		public void SetXp(float newXp)
		{
			if (newXp >= GetMaxXp())
			{
				_heroProvider.Level.CurrentLevel++;
				
				OnLevelChanged?.Invoke(_heroProvider.Level.CurrentLevel);
			}
		}

		public float GetLevel()
		{
			return _heroProvider.Level.CurrentLevel;
		}

		public float GetMaxXp()
		{
			return _configsService.LevelUpConfig.LevelOneMaxXp * Mathf.Pow(_configsService.LevelUpConfig.ExponentialLevelMultiplier, _heroProvider.Level.CurrentLevel - 1);
		}

	}
}
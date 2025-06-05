using System;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Difficulty.Services;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Difficulty.Behaviours
{
	[RequireComponent(typeof(Stats))]
	public class DifficultyEnemyComponent : MonoBehaviour
	{
		private IDifficultyService _difficultyService;
		private Stats _stats;

		[Inject]
		private void Construct(IDifficultyService difficultyService)
		{
			_difficultyService = difficultyService;
		}

		private void Awake()
		{
			_stats = GetComponent<Stats>();
		}

		public void Setup(EnemyConfig enemyConfig)
		{
			ApplyDifficulty(enemyConfig);
		}

		private void ApplyDifficulty(EnemyConfig enemyConfig)
		{
			if (enemyConfig == null)
			{
				return;
			}

			var enemyModifiers = _difficultyService.GetDifficultyModifiers(enemyConfig);

			foreach (var statModifier in enemyModifiers)
			{
				_stats.AddStatModifier(statModifier);
			}
		}
	}
}
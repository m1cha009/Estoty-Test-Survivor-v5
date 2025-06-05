using System.Collections.Generic;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Difficulty.Configs;
using Code.Gameplay.UnitStats;
using UnityEngine;

namespace Code.Gameplay.Difficulty.Services
{
	public class DifficultyService : IDifficultyService
	{
		private float _gameTime;
		
		public float GameTime => _gameTime;


		public void UpdateGameTime(float gameTime)
		{
			_gameTime += gameTime;
		}
		
		public List<StatModifier> GetDifficultyModifiers(EnemyConfig enemyConfig)
		{
			var modifiers = new List<StatModifier>();

			foreach (var difficultyModifier in enemyConfig.DifficultyModifiers)
			{
				var modifiedValue = CalculateModifiedValue(difficultyModifier);

				if (modifiedValue <= 0)
				{
					continue;
				}
				
				modifiers.Add(new StatModifier(difficultyModifier.StatType, modifiedValue));
			}

			return modifiers;
		}

		private float CalculateModifiedValue(DifficultyModifier modifier)
		{
			if (modifier.GrowthInterval <= 0)
			{
				return 0;
			}
			
			float modifiedValue = Mathf.FloorToInt(_gameTime / modifier.GrowthInterval) * modifier.GrowthRate;
			
			return modifiedValue;
		}
	}
}
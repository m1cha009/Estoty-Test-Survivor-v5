using System.Collections.Generic;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.UnitStats;

namespace Code.Gameplay.Difficulty.Services
{
	public interface IDifficultyService
	{
		public float GameTime { get; }
		public void UpdateGameTime(float time);
		public List<StatModifier> GetDifficultyModifiers(EnemyConfig enemyConfig);

	}
}
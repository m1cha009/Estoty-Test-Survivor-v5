using System;
using Code.Gameplay.UnitStats;

namespace Code.Gameplay.Difficulty.Configs
{
	[Serializable]
	public class DifficultyModifier
	{
		public StatType StatType;
		public float GrowthRate;
		public float GrowthInterval;
	}
}
using System;

namespace Code.Gameplay.LevelUp.Services
{
	public interface ILevelUpService
	{
		public event Action<float> OnLevelChanged;
		
		public void SetXp(float newXp);
		public float GetLevel();
		public float GetMaxXp();
	}
}
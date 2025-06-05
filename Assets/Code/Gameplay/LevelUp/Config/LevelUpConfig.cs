using UnityEngine;

namespace Code.Gameplay.LevelUp.Config
{
	[CreateAssetMenu(fileName = "LevelUpConfig", menuName = Constants.GameName + "/Configs/LevelUp", order = 0)]
	public class LevelUpConfig : ScriptableObject
	{
		public float LevelOneMaxXp;
		public float ExponentialLevelMultiplier;
	}
}
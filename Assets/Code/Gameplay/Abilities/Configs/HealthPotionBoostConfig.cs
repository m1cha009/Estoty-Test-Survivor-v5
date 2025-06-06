using UnityEngine;

namespace Code.Gameplay.Abilities.Configs
{
	[CreateAssetMenu(fileName = "HealthPotionBoost", menuName = Constants.GameName + "/Configs/Abilities/HealthPotionBoost")]
	public class HealthPotionBoostConfig : ScriptableObject, IAbilityConfig
	{
		[field: SerializeField] public AbilityType AbilityType { get; private set; }
		[field: SerializeField] public bool IsStackable { get; private set; }
		[field: SerializeField] public string Description { get; private set; }
		[field: SerializeField] public float Multiplier { get; private set; } = 1;
	}
}
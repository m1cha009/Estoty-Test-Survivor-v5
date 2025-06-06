using UnityEngine;

namespace Code.Gameplay.Abilities.Configs
{
	[CreateAssetMenu(fileName = "HealUpAbility", menuName = Constants.GameName + "/Configs/Abilities/HealUpAbility")]
	public class HealUpAbilityConfig : ScriptableObject, IAbilityConfig
	{
		[field:SerializeField] public AbilityType AbilityType { get; private set; }
		[field: SerializeField] public bool IsStackable { get; private set; }
		[field: SerializeField] public string Description { get; private set; }
		[field: SerializeField] public float Modifier { get; private set; }
	}
}
using UnityEngine;

namespace Code.Gameplay.Abilities.Configs
{
	[CreateAssetMenu(fileName = "BouncingProjectiles", menuName = Constants.GameName + "/Configs/Abilities/BouncingProjectiles")]
	public class BouncingProjectilesConfig : ScriptableObject, IAbilityConfig
	{
		[field: SerializeField] public AbilityType AbilityType { get; private set; }
		[field: SerializeField] public bool IsStackable { get; private set; }
		[field: SerializeField] public string Description { get; private set; }
		[field: SerializeField] public float BounceAmount { get; private set; }
	}
}
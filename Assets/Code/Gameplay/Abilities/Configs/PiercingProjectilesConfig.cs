using UnityEngine;

namespace Code.Gameplay.Abilities.Configs
{
	[CreateAssetMenu(fileName = "PiercingProjectiles", menuName = Constants.GameName + "/Configs/Abilities/PiercingProjectiles")]
	public class PiercingProjectilesConfig : ScriptableObject, IAbilityConfig
	{
		[field: SerializeField] public AbilityType AbilityType { get; private set; }
		[field: SerializeField] public bool IsStackable { get; private set; }
		[field: SerializeField] public string Description { get; private set; }
	}
}
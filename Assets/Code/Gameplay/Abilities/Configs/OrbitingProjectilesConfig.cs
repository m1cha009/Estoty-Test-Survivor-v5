using UnityEngine;

namespace Code.Gameplay.Abilities.Configs
{
	[CreateAssetMenu(fileName = "OrbitingProjectiles", menuName = Constants.GameName + "/Configs/Abilities/OrbitingProjectiles")]
	public class OrbitingProjectilesConfig : ScriptableObject, IAbilityConfig
	{
		[field: SerializeField] public AbilityType AbilityType { get; private set; }
		[field: SerializeField] public bool IsStackable { get; private set; }
		[field: SerializeField] public string Description { get; private set; }
		[field: SerializeField] public float OrbitsAmount { get; private set; }
		[field: SerializeField] public float OrbitsRadius { get; private set; }
		[field: SerializeField] public float OrbitsSpeed { get; private set; }
	}
}
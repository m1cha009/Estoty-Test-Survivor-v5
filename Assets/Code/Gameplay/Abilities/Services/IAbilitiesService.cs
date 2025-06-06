using System.Collections.Generic;
using Code.Gameplay.Abilities.Configs;

namespace Code.Gameplay.Abilities.Services
{
	public interface IAbilitiesService
	{
		public List<IAbilityConfig> GetRandomAbilities(int count);
		public void ApplyAbility(IAbilityConfig abilityConfig);
	}
}
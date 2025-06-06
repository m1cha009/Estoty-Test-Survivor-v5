using Code.Gameplay.Abilities.Configs;
using Code.Gameplay.Abilities.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Abilities.Behaviours
{
	public class UiAbility : MonoBehaviour
	{
		private IAbilitiesService _abilitiesService;
		private IAbilityConfig _abilityConfig;

		[Inject]
		private void Construct(IAbilitiesService abilitiesService)
		{
			_abilitiesService = abilitiesService;
		}
		
		public void Setup(IAbilityConfig abilityConfig)
		{
			_abilityConfig = abilityConfig;
		}

		public void ApplyAbility()
		{
			if (_abilityConfig == null)
			{
				return;
			}
			
			_abilitiesService.ApplyAbility(_abilityConfig);
		}
	}
}
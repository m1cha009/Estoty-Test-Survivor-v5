using System.Collections.Generic;
using Code.Gameplay.Abilities.Services;
using Code.Infrastructure.UIManagement;
using Code.UI.Elements;
using UnityEngine;
using Zenject;

namespace Code.UI
{
	public class LevelUpWindow : WindowBase
	{
		[SerializeField] private List<UiCard> _uiCards;
		
		private IAbilitiesService _abilitiesService;
		
		public override bool IsUserCanClose => true;

		[Inject]
		private void Construct(IAbilitiesService abilityConfig)
		{
			_abilitiesService = abilityConfig;
		}

		protected override void OnOpen()
		{
			var randomAbilityConfigs = _abilitiesService.GetRandomAbilities(3);
			
			for (int i = 0; i < _uiCards.Count; i++)
			{
				if (i < randomAbilityConfigs.Count)
				{
					_uiCards[i].Setup(randomAbilityConfigs[i]);
				}
				else
				{
					_uiCards[i].Setup(null);
				}
			}
		}
	}
}
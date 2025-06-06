using Code.Gameplay.Abilities.Behaviours;
using Code.Gameplay.Abilities.Configs;
using Code.Infrastructure.UIManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Elements
{
	[RequireComponent(typeof(UiAbility))]
	public class UiCard : MonoBehaviour
	{
		[SerializeField] private Button _card;
		[SerializeField] private TMP_Text _abilityDescription;
		
		private IUiService _uiService;
		private UiAbility _uiAbility;

		[Inject]
		private void Construct(IUiService uiService)
		{
			_uiService = uiService;
		}

		private void Awake()
		{
			_card.onClick.AddListener(OnCardClick);
		}

		private void OnDestroy()
		{
			_card.onClick.RemoveListener(OnCardClick);
		}

		public void Setup(IAbilityConfig abilityConfig)
		{
			ResetCard();

			if (abilityConfig == null)
			{
				return;
			}
			
			_uiAbility.Setup(abilityConfig);
			
			_abilityDescription.SetText(abilityConfig.Description);
			
			gameObject.SetActive(true);
		}

		private void ResetCard()
		{
			if (!_uiAbility)
			{
				_uiAbility = GetComponent<UiAbility>();
			}
			
			_uiAbility.Setup(null);
			_abilityDescription.SetText(string.Empty);
			
			gameObject.SetActive(false);
		}

		private void OnCardClick()
		{
			if (_uiAbility)
			{
				_uiAbility.ApplyAbility();
			}
			
			_uiService.CloseWindow<LevelUpWindow>();
		}
	}
}
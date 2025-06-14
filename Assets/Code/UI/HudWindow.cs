using Code.Gameplay.Characters.Enemies.Services;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.UIManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
	public class HudWindow : WindowBase
	{
		[SerializeField] private Slider _healthBar;
		[SerializeField] private Text _killedEnemiesText;
		[SerializeField] private Slider _xpBar;
		
		private IHeroProvider _heroProvider;
		private IEnemyDeathTracker _enemyDeathTracker;

		public override bool IsUserCanClose => false;

		[Inject]
		private void Construct(IHeroProvider heroProvider, IEnemyDeathTracker enemyDeathTracker)
		{
			_enemyDeathTracker = enemyDeathTracker;
			_heroProvider = heroProvider;
		}

		protected override void OnUpdate()
		{
			UpdateHealthBar();
			UpdateKilledEnemiesText();
			UpdateXpBar();
		}

		private void UpdateKilledEnemiesText()
		{
			_killedEnemiesText.text = _enemyDeathTracker.TotalKilledEnemies.ToString();
		}
		
		private void UpdateHealthBar()
		{
			if (_heroProvider.Hero != null)
				_healthBar.value = _heroProvider.Health.CurrentHealth / _heroProvider.Health.MaxHealth;
			else
				_healthBar.value = 0;
		}

		private void UpdateXpBar()
		{
			if (_heroProvider.Hero != null)
				_xpBar.value = _heroProvider.Xp.CurrentXp / _heroProvider.Xp.MaxXp;
			else
				_xpBar.value = 0;
		}
	}
}
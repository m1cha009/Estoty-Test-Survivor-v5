using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Abilities.Configs;
using Code.Gameplay.Characters.Enemies;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Characters.Heroes.Configs;
using Code.Gameplay.LevelUp.Config;
using Code.Gameplay.PickUps;
using Code.Gameplay.PickUps.Configs;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.ConfigsManagement
{
	public class ConfigsService : IConfigsService
	{
		private readonly IAssetsService _assets;

		private Dictionary<EnemyId, EnemyConfig> _enemiesById = new();
		private Dictionary<PickUpId, PickUpConfig> _pickupsById = new();
		private List<IAbilityConfig> _allAbilitiesConfigs = new();

		public HeroConfig HeroConfig { get; private set; }
		public LevelUpConfig LevelUpConfig { get; private set; }

		public ConfigsService(IAssetsService assets)
		{
			_assets = assets;
		}
		
		public void Load()
		{
			LoadHeroConfig();
			LoadEnemyConfigs();
			LoadPickUpConfigs();
			LoadLevelUpConfig();
			LoadAbilitiesConfigs();
		}

		private void LoadPickUpConfigs()
		{
			var pickUpConfigs = _assets.LoadAssetsFromResources<PickUpConfig>("Configs/PickUps");
			_pickupsById = pickUpConfigs.ToList().ToDictionary(x => x.Id, x => x);
		}

		private void LoadHeroConfig()
		{
			HeroConfig = _assets.LoadAssetFromResources<HeroConfig>("Configs/HeroConfig");
		}
		
		private void LoadLevelUpConfig()
		{
			LevelUpConfig = _assets.LoadAssetFromResources<LevelUpConfig>("Configs/LevelUp/LevelUpConfig");
		}

		private void LoadEnemyConfigs()
		{
			var enemyConfigs = _assets.LoadAssetsFromResources<EnemyConfig>("Configs/Enemies");
			_enemiesById = enemyConfigs.ToList().ToDictionary(x => x.Id, x => x);
		}
		
		private void LoadAbilitiesConfigs()
		{
			var enemyConfigs = _assets.LoadAssetsFromResources<ScriptableObject>("Configs/Abilities");
			_allAbilitiesConfigs = enemyConfigs.OfType<IAbilityConfig>().ToList();
		}
		
		public List<IAbilityConfig> GetAllAbilitiesConfigs() => _allAbilitiesConfigs;

		public EnemyConfig GetEnemyConfig(EnemyId id)
		{
			if (_enemiesById.TryGetValue(id, out EnemyConfig enemyConfig))
				return enemyConfig;

			throw new KeyNotFoundException($"Enemy config with id {id} not found");
		}
		
		public PickUpConfig GetPickUpConfig(PickUpId id)
		{
			if (_pickupsById.TryGetValue(id, out PickUpConfig pickUpConfig))
				return pickUpConfig;

			throw new KeyNotFoundException($"PickUp config with id {id} not found");
		}
	}
}
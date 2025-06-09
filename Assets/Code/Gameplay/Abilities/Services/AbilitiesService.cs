using System.Collections.Generic;
using Code.Gameplay.Abilities.Configs;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.Guns.Behaviours;
using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Infrastructure.ConfigsManagement;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Abilities.Services
{
	public class AbilitiesService : IAbilitiesService
	{
		private IConfigsService _configsService;
		private IHeroProvider _heroProvider;

		[Inject]
		private void Construct(IConfigsService configsService, IHeroProvider heroProvider)
		{
			_configsService = configsService;
			_heroProvider = heroProvider;
		}
		
		public List<IAbilityConfig> GetCurrentAppliedAbilities()
		{
			return null;
		}
		
		public List<IAbilityConfig> GetRandomAbilities(int count)
		{
			var allAbilities = _configsService.GetAllAbilitiesConfigs();
			
			var randAbilityConfigs = new List<IAbilityConfig>(allAbilities);
			
			for (int i = 0; i < count; i++)
			{
				var randomIndex = Random.Range(0, randAbilityConfigs.Count);
				(randAbilityConfigs[i], randAbilityConfigs[randomIndex]) = (randAbilityConfigs[randomIndex], randAbilityConfigs[i]);
			}

			return randAbilityConfigs.GetRange(0, count);
		}

		public void ApplyAbility(IAbilityConfig abilityConfig)
		{
			if (abilityConfig is HealthPotionBoostConfig healthPotionBoosConfig)
			{
				ApplyHealthPotionsBoostAbility(healthPotionBoosConfig);
			}
			else if (abilityConfig is PiercingProjectilesConfig piercingProjectilesConfig)
			{
				ApplyPiercingProjectileAbility(piercingProjectilesConfig);
			}
			else if (abilityConfig is BouncingProjectilesConfig bouncingProjectilesConfig)
			{
				ApplyBouncingProjectileAbility(bouncingProjectilesConfig);
			}
			else if (abilityConfig is OrbitingProjectilesConfig orbitingProjectilesConfig)
			{
				ApplyOrbitingProjectileAbility(orbitingProjectilesConfig);
			}
			else if (abilityConfig is AgilityUpAbilityConfig agilityUpAbilityConfig)
			{
				ApplyAgilityUpAbility(agilityUpAbilityConfig);
			}
			else if (abilityConfig is HealUpAbilityConfig healAbilityConfig)
			{
				ApplyHealUpAbility(healAbilityConfig);
			}
			else if (abilityConfig is DamageUpAbilityConfig damageUpAbilityConfig)
			{
				ApplyDamageUpAbility(damageUpAbilityConfig);
			}
		}
		
		private void ApplyHealthPotionsBoostAbility(HealthPotionBoostConfig healthPotionBoostConfig)
		{
			_heroProvider.Health.SetHealMultiplier(healthPotionBoostConfig.Multiplier);
		}
		
		private void ApplyPiercingProjectileAbility(PiercingProjectilesConfig piercingProjectilesConfig)
		{
			var statModifier = new StatModifier(StatType.PiercingAmount, piercingProjectilesConfig.PiercingAmount);
			
			_heroProvider.Stats.AddStatModifier(statModifier);
		}
		
		private void ApplyBouncingProjectileAbility(BouncingProjectilesConfig bouncingProjectilesConfig)
		{
			var statModifier = new StatModifier(StatType.BounceAmount, bouncingProjectilesConfig.BounceAmount);
			
			_heroProvider.Stats.AddStatModifier(statModifier);
		}
		
		private void ApplyOrbitingProjectileAbility(OrbitingProjectilesConfig orbitingProjectilesConfig)
		{
			_heroProvider.Health
				.GetComponentInChildren<OrbitProjectiles>()
				.Setup(orbitingProjectilesConfig.OrbitsAmount, 
					orbitingProjectilesConfig.OrbitsRadius, 
					orbitingProjectilesConfig.OrbitsSpeed,
					_heroProvider.Stats);
		}
		
		private void ApplyAgilityUpAbility(AgilityUpAbilityConfig agilityUpAbilityConfig)
		{
			var statModifier = new StatModifier(StatType.RotationSpeed, agilityUpAbilityConfig.Modifier);
			
			_heroProvider.Hero.GetComponent<GunOwner>().OwnedGun.GetComponent<Stats>().AddStatModifier(statModifier);
		}
		
		private void ApplyHealUpAbility(HealUpAbilityConfig healUpAbilityConfig)
		{
			var statModifier = new StatModifier(StatType.MaxHealth, healUpAbilityConfig.Modifier);
			
			_heroProvider.Stats.AddStatModifier(statModifier);
		}
		
		private void ApplyDamageUpAbility(DamageUpAbilityConfig damageAbilityConfig)
		{
			var statModifier = new StatModifier(StatType.Damage, damageAbilityConfig.Modifier);
			
			_heroProvider.Stats.AddStatModifier(statModifier);
		}
	}
}
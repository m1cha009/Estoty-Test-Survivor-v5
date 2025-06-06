using Code.Gameplay.Identification.Behaviours;
using Code.Gameplay.Movement.Behaviours;
using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.Teams;
using Code.Gameplay.Teams.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identification;
using Code.Infrastructure.Instantiation;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Services
{
	public class ProjectileFactory : IProjectileFactory
	{	
		private readonly IInstantiateService _instantiateService;
		private readonly IIdentifierService _identifiers;
		private readonly IAssetsService _assetsService;

		public ProjectileFactory(
			IInstantiateService instantiateService,
			IIdentifierService identifiers,
			IAssetsService assetsService)
		{
			_instantiateService = instantiateService;
			_identifiers = identifiers;
			_assetsService = assetsService;
		}
		
		public Projectile CreateProjectile(Vector3 at, Vector2 direction, TeamType teamType, Stats stats)
		{
			var prefab = _assetsService.LoadAssetFromResources<Projectile>("Projectiles/Projectile");
			Projectile projectile = _instantiateService.InstantiatePrefabForComponent(prefab, at, Quaternion.FromToRotation(Vector3.up, direction));
			
			projectile.GetComponent<Id>()
				.Setup(_identifiers.Next());

			projectile.GetComponent<Stats>()
				.SetBaseStat(StatType.VisionRange, stats.GetStat(StatType.VisionRange))
				.SetBaseStat(StatType.MovementSpeed, stats.GetStat(StatType.MovementSpeed))
				.SetBaseStat(StatType.Damage, stats.GetStat(StatType.Damage))
				.SetBaseStat(StatType.PiercingAmount, stats.GetStat(StatType.PiercingAmount))
				.SetBaseStat(StatType.BounceAmount, stats.GetStat(StatType.BounceAmount));
			
			projectile.GetComponent<Team>()
				.Type = teamType;
			
			projectile.GetComponent<IMovementDirectionProvider>()
				.SetDirection(direction);
			
			return projectile;
		}
	}
}
using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.Teams;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Services
{
	public interface IProjectileFactory
	{
		Projectile CreateProjectile(Vector3 at, Vector2 direction, TeamType teamType, Stats stats);
	}
}
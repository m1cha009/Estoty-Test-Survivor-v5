using System.Collections.Generic;
using Code.Gameplay.Projectiles.Services;
using Code.Gameplay.Teams;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Projectiles.Behaviours
{
	public class OrbitProjectiles : MonoBehaviour
	{
		private Stats _ownerStats;
		private float _orbitAmount = 3;
		private float _orbitRadius = 5;
		private float _orbitSpeed = 30;
		
		private IProjectileFactory _projectileFactory;
		
		private readonly List<OrbitProjectile> _orbitProjectiles = new();

		[Inject]
		private void Construct(IProjectileFactory projectileFactory)
		{
			_projectileFactory = projectileFactory;
		}
		
		public void Setup(float orbitAmount, float orbitRadius, float orbitSpeed, Stats ownerStats)
		{
			_orbitAmount = orbitAmount;
			_orbitRadius = orbitRadius;
			_orbitSpeed = orbitSpeed;
			_ownerStats = ownerStats;
			
			for (int i = 0; i < _orbitAmount; i++)
			{
				var projectile = _projectileFactory.CreateOrbitProjectile(Vector3.zero, Vector2.zero, TeamType.Hero, _ownerStats);
				
				var angle= i * (360 / _orbitAmount);
				
				projectile.CurrentAngle = angle;
				
				_orbitProjectiles.Add(projectile);
			}
		}

		private void Update()
		{
			if (_orbitProjectiles.Count <= 0)
			{
				return;
			}

			foreach (var orbitProjectile in _orbitProjectiles)
			{
				orbitProjectile.CurrentAngle += _orbitSpeed * Time.deltaTime;
                
				float x = transform.position.x + Mathf.Cos(orbitProjectile.CurrentAngle * Mathf.Deg2Rad) * _orbitRadius;
				float y = transform.position.y + Mathf.Sin(orbitProjectile.CurrentAngle * Mathf.Deg2Rad) * _orbitRadius;
				
				orbitProjectile.transform.position = new Vector2(x, y);
			}
		}
	}
}
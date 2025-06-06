using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(IDamageApplier))]
	[RequireComponent(typeof(Stats))]
	[RequireComponent(typeof(ProjectileBounce))]
	public class DestroyOnDamageApplied : MonoBehaviour
	{
		[SerializeField] private float _delay;
		
		private IDamageApplier _damageApplier;
		private ProjectileBounce _projectileBounce;
		private ProjectilePiercing _projectilePiercing;
		
		private void Awake()
		{
			_damageApplier = GetComponent<IDamageApplier>();
			_projectileBounce = GetComponent<ProjectileBounce>();
			_projectilePiercing = GetComponent<ProjectilePiercing>();
		}

		private void OnEnable()
		{
			_damageApplier.OnDamageApplied += HandleDamageApplied;
		}

		private void OnDisable()
		{
			_damageApplier.OnDamageApplied -= HandleDamageApplied;
		}

		private void HandleDamageApplied(Health _)
		{
			if (_projectileBounce.BouncesLeft > 0 || _projectilePiercing.PiercingLeft > 0)
			{
				return;
			}
			
			Destroy(gameObject, _delay);
		}
	}
}
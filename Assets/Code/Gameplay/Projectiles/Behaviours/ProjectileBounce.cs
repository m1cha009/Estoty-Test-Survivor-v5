using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.Movement.Behaviours;
using Code.Gameplay.Teams;
using Code.Gameplay.Teams.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Gameplay.Vision.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Behaviours
{
	[RequireComponent(typeof(Stats))]
	[RequireComponent(typeof(IMovementDirectionProvider))]
	[RequireComponent(typeof(VisionSight))]
	[RequireComponent(typeof(IDamageApplier))]
	public class ProjectileBounce : MonoBehaviour
	{
		private Stats _stats;
		private IMovementDirectionProvider _directionProvider;
		private VisionSight _visionSight;
		private IDamageApplier _damageApplier;

		private float _bounceAmountLeft;

		public float BouncesLeft => _bounceAmountLeft;

		private void Awake()
		{
			_stats = GetComponent<Stats>();
			_directionProvider = GetComponent<IMovementDirectionProvider>();
			_visionSight = GetComponent<VisionSight>();
		}

		private void Start()
		{
			_bounceAmountLeft = _stats.GetStat(StatType.BounceAmount);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (_bounceAmountLeft <= 0)
			{
				return;
			}
			
			if (other.TryGetComponent(out Team otherTeam) == false || otherTeam.Type == TeamType.Hero)
			{
				return;
			}
			
			BounceToAnotherEnemy(other.gameObject);
		}

		private void BounceToAnotherEnemy(GameObject currentEnemy)
		{
			var closestEnemy = _visionSight.GetClosestEnemy(currentEnemy);

			if (closestEnemy != null)
			{
				Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
				_directionProvider.SetDirection(direction);
			}
			
			_bounceAmountLeft--;
		}
	}
}
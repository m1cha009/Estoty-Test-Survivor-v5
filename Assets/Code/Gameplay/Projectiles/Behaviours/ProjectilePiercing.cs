using Code.Gameplay.Teams;
using Code.Gameplay.Teams.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Behaviours
{
	[RequireComponent(typeof(Stats))]
	public class ProjectilePiercing : MonoBehaviour
	{
		private Stats _stats;
		private float _piercingAmountLeft;

		public float PiercingLeft => _piercingAmountLeft;

		private void Awake()
		{
			_stats = GetComponent<Stats>();
		}
		
		private void Start()
		{
			_piercingAmountLeft = _stats.GetStat(StatType.PiercingAmount);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (_piercingAmountLeft <= 0)
			{
				return;
			}
			
			if (other.TryGetComponent(out Team otherTeam) == false || otherTeam.Type == TeamType.Hero)
			{
				return;
			}

			_piercingAmountLeft--;
		}
	}
}
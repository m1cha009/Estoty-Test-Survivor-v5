using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	public class Xp : MonoBehaviour
	{
		private float _currentXp;

		public void AddXp(float xp)
		{
			_currentXp += xp;
		}
	}
}
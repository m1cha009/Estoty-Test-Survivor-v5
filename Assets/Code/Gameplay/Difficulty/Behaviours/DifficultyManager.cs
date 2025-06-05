using Code.Gameplay.Difficulty.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Difficulty.Behaviours
{
	public class DifficultyManager : MonoBehaviour
	{
		private IDifficultyService _difficultyService;

		[Inject]
		private void Construct(IDifficultyService difficultyService)
		{
			_difficultyService = difficultyService;
		}

		private void Update()
		{
			_difficultyService?.UpdateGameTime(Time.deltaTime);
		}
	}
}
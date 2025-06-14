using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.UnitStats.Behaviours;

namespace Code.Gameplay.Characters.Heroes.Services
{
	public interface IHeroProvider
	{
		Behaviours.Hero Hero { get; }
		Health Health { get; }
		Stats Stats { get; }
		Xp Xp { get; }
		Level Level { get; }
		void SetHero(Behaviours.Hero hero);
	}
}
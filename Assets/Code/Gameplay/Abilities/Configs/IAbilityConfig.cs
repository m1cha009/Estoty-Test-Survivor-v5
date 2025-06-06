namespace Code.Gameplay.Abilities.Configs
{
	public interface IAbilityConfig
	{
		public AbilityType AbilityType { get; }
		public bool IsStackable { get; }
		public string Description { get; }
	}
}


namespace Assets.Scripts.Game.Bonuses.Implementations
{
    class SmallPlatformBonus : CollectableBonus

    {
        public override void Apply()
        {
            Game.Instance.Player.DecreaseSize();
        }
    }
}

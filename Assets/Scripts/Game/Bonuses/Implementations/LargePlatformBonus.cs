using Assets.Scripts.Serialization;

namespace Assets.Scripts.Game.Bonuses.Implementations {
    class LargePlatformBonus : CollectableBonus {
        public override void Apply() {
            Game.Instance.Player.IncreaseSize();
        }

        public override BonusType Type {
            get {
                return BonusType.IncreasePlatform;
            }
        }
    }
}

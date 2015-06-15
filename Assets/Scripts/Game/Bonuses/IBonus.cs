using Assets.Scripts.Serialization;

namespace Assets.Scripts.Game.Bonuses {
    interface IBonus {
        void Apply();
        void Lose();
        BonusType Type { get; }
    }
}

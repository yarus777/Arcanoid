using Assets.Scripts.Engine.Subscription;

namespace Assets.Scripts.Game.State.WinReasons {
    public delegate void WinReasonDelegate(IWinReason reason);

    public interface IWinReason : ISubscribable {
        event WinReasonDelegate Win;
    }
}

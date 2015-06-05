using Assets.Scripts.Engine.Subscription;

namespace Assets.Scripts.Game.State.FailReasons {
    public delegate void FailReasonDelegate(IFailReason reason);

    public interface IFailReason : ISubscribable {
        event FailReasonDelegate Failed;
    }
}

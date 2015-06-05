namespace Assets.Scripts.Game.State.FailReasons {
    public delegate void FailReasonDelegate(IFailReason reason);

    public interface IFailReason {
        event FailReasonDelegate Failed;
    }
}

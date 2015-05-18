namespace Assets.Scripts.Game.State {
    public delegate void FailReasonDelegate();

    interface IFailReason {
        event FailReasonDelegate Failed;
    }
}

namespace Assets.Scripts.Game.State.FailReasons {
    public delegate void FailReasonDelegate();

    interface IFailReason {
        event FailReasonDelegate Failed;
    }
}

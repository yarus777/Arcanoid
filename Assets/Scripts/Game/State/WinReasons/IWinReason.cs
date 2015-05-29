namespace Assets.Scripts.Game.State.WinReasons {
    public delegate void WinReasonDelegate();
    interface IWinReason {
        event WinReasonDelegate Win;
    }
}

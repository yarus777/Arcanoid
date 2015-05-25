namespace Assets.Scripts.Serialization {
    interface IRestorable<in T> where T: SavedInfo {
        void Restore(T info);
    }
}

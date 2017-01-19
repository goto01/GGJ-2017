namespace Assets.Scripts.Staff.Singleton
{
    public interface ISingletonMonoBehaviour
    {
        bool IsSingleton { get; }

        void AwakeSingleton();
    }
}

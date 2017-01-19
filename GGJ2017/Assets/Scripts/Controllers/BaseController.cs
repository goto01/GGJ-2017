namespace Assets.Scripts.Controllers
{
    public abstract class BaseController<T> : Staff.Singleton.SingletonMonoBehaviour<T> 
        where T : BaseController<T>
    {
        private const string Tag = "Game controller";

        protected virtual void Reset()
        {
            gameObject.tag = Tag;
        }
    }
}

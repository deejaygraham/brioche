
namespace brioche
{
    public class DefaultTypeContainer : TypeContainer
    {
        public DefaultTypeContainer()
            : base(new SimpleTypeRegistry(), new SimpleInstanceCreator())
        {
        }
    }
}

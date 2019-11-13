using XPike.IoC;

namespace XPike.Settings
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeSettings(IDependencyCollection collection) =>
            collection.LoadPackage(new XPike.Settings.Package());
    }
}
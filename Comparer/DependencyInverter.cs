using HashComparerInterfaces;

namespace HashComparer
{
    internal class DependencyInverter
    {
        internal IHashCheckerFactory HashCheckerFactory {  get; }
        internal IArgsStorage ArgsStorage {  get; }

        private DependencyInverter(IHashCheckerFactory hashCheckerFactory, IArgsStorage argsStorage)
        {
            HashCheckerFactory = hashCheckerFactory;
            ArgsStorage = argsStorage;
        }

        internal static DependencyInverter Create()
        {
            var parser = new ParametersParser();
            var argsStorage = new ArgsStorage(parser);
            var filesListCreator = new FilesListCreator(argsStorage);
            var checkerFactory = new HashCheckerFactory(argsStorage, filesListCreator);
            var result = new DependencyInverter(checkerFactory, argsStorage);
            return result;
        }
    }
}
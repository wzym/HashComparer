namespace HashComparer
{
    public static class HashComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparedHash"></param>
        /// <param name="startPath"></param>
        /// <param name="hashType"></param>
        /// <returns></returns>
        /// <exception cref="ParametersNotValidException"></exception>
        public static IEnumerable<FileInfo> Compare(
            string comparedHash, string startPath, string hashType)
        {
            var inverter = DependencyInverter.Create();
            
            inverter.ArgsStorage.TryParse(comparedHash, startPath, hashType);
            using var checker = inverter.HashCheckerFactory.GetHashChecker();
            return checker.FindMatches();
        }
    }
}
using AdventOfCode2025.Interfaces;

namespace AdventOfCode2025.Abstraction
{
    internal abstract class DaySolutionGeneric : IDaySolution
    {
        private string _inputFilePath;
        
        public DaySolutionGeneric()
        {
            _inputFilePath = GetInputFilePath();
        }
        public string[] ReadInput()
        {
            return File.ReadAllLines(_inputFilePath);
        }

        public string GenerateOutput()
        {
            return SolveProblem();
        }

        protected abstract string SolveProblem();
        protected abstract string GetInputFilePath();
    }
}

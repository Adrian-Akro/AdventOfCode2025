using AdventOfCode2025.Abstraction;

namespace AdventOfCode2025.Days
{
    internal class DayThreePartOne : DaySolutionGeneric
    {
        protected override string GetInputFilePath()
        {
            return "Days/Day03/Input.txt";
        }

        protected override string SolveProblem()
        {
            string[] energyBankArray = ReadInput();
            int sumOfEnergyBankPowers = 0;
            int GetHighestPowerCombinationInBank(string energyBank)
            {
                int[] activeBankBatteries = [0, 0];

                foreach (char batteryPower in energyBank) 
                {
                    int highestValueInActiveBatteries = Math.Max(activeBankBatteries[0], activeBankBatteries[1]);
                    if (int.TryParse(batteryPower.ToString(), out int batteryPowerValue))
                    {
                        if (int.Parse($"{activeBankBatteries[0]}{activeBankBatteries[1]}") 
                            < int.Parse($"{highestValueInActiveBatteries}{batteryPowerValue}")) 
                        {
                            (activeBankBatteries[0], activeBankBatteries[1]) = (highestValueInActiveBatteries, batteryPowerValue);
                        }
                    }
                }

                return int.Parse($"{activeBankBatteries[0]}{activeBankBatteries[1]}");
            }

            foreach (string energyBank in energyBankArray) {
                sumOfEnergyBankPowers += GetHighestPowerCombinationInBank(energyBank);
            }

            return sumOfEnergyBankPowers.ToString();
        }
    }
}

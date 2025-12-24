using AdventOfCode2025.Abstraction;

namespace AdventOfCode2025.Days
{
    internal class DayThreePartTwo : DaySolutionGeneric
    {
        protected override string GetInputFilePath()
        {
            return "Days/Day03/Input.txt";
        }

        protected override string SolveProblem()
        {
            string[] energyBankArray = ReadInput();
            long sumOfEnergyBankPowers = 0;
            long GetHighestPowerCombinationFromBank(string energyBank)
            {
                Stack<int>[] positionOfBatteryPowers = new Stack<int>[9];
                for (int indexOfBatteryPowers = 0; indexOfBatteryPowers < positionOfBatteryPowers.Length; indexOfBatteryPowers++)
                {
                    positionOfBatteryPowers[indexOfBatteryPowers] = new Stack<int>();
                }

                for (int indexOfBattery = energyBank.Length - 1; indexOfBattery >= 0; indexOfBattery--)
                {
                    if (int.TryParse(energyBank[indexOfBattery].ToString(), out int batteryPowerValue)) 
                    {
                        positionOfBatteryPowers[batteryPowerValue-1].Push(indexOfBattery);
                    }
                }

                long highestValue = long.Parse(GetHighestPowerCombinationFromPositions(
                    positionOfBatteryPowers, 
                    currentPositionInBank: 0,
                    activeBatteries: string.Empty,
                    requiredActiveBatteries: 12,
                    lengthOfEnergyBank: energyBank.Length
                    ));

                return highestValue;
            }

            string GetHighestPowerCombinationFromPositions(
                Stack<int>[] positionOfBatteryPowers,
                int currentPositionInBank,
                string activeBatteries,
                int requiredActiveBatteries,
                int lengthOfEnergyBank
                )
            {

                if (currentPositionInBank >= lengthOfEnergyBank || activeBatteries.Length == requiredActiveBatteries)
                {
                    return activeBatteries;
                }

                for (int batteryPower = 9; batteryPower > 0; batteryPower--) 
                { 
                    while (positionOfBatteryPowers[batteryPower - 1].TryPeek(out int powerPosition))
                    {
                        if (powerPosition < currentPositionInBank)
                        {
                            positionOfBatteryPowers[batteryPower - 1].Pop();
                            continue;
                        }
                        else if (lengthOfEnergyBank < powerPosition + requiredActiveBatteries - activeBatteries.Length)
                        {
                            break;
                        }

                        positionOfBatteryPowers[batteryPower - 1].Pop();
                        currentPositionInBank = powerPosition;
                        activeBatteries += $"{batteryPower}";

                        return GetHighestPowerCombinationFromPositions(
                            positionOfBatteryPowers,
                            currentPositionInBank,
                            activeBatteries,
                            requiredActiveBatteries,
                            lengthOfEnergyBank
                        );
                    }
                }

                return activeBatteries;
            }

            foreach (string energyBank in energyBankArray) {
                sumOfEnergyBankPowers += GetHighestPowerCombinationFromBank(energyBank);
            }

            return sumOfEnergyBankPowers.ToString();
        }
    }
}

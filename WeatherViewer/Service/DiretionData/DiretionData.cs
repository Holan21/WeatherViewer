namespace WetherViewer.Service.DiretionData
{
    internal class DirectionData : IDirectionData
    {
        public string GetDiretion(int direction)
        {
            switch (direction)
            {
                case < 45:
                    return "NORTH";
                case < 90:
                    return "NORTH-EAST";
                case < 135:
                    return "EAST";
                case < 180:
                    return "SOUTH";
                case < 225:
                    return "SOUTH-WEST";
                case < 270:
                    return "WEST";
                case < 360:
                    return "NORTH-WEST";
                case 360:
                    return "NORTH";

            }
            throw new Exception();
        }
    }
}

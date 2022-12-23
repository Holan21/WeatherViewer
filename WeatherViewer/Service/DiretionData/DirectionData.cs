namespace WetherViewer.Service.DiretionData
{
    internal class DirectionData : IDirectionData
    {
        public string GetDiretion(int direction)
        {
            return direction switch
            {
                < 45 => "NORTH",
                < 90 => "NORTH-EAST",
                < 135 => "EAST",
                < 180 => "SOUTH",
                < 225 => "SOUTH-WEST",
                < 270 => "WEST",
                < 360 => "NORTH-WEST",
                360 => "NORTH",
                _ => "NA",
            };
        }
    }
}
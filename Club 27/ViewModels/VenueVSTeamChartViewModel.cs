namespace Club_27.ViewModels
{
    public class VenueVSTeamChartViewModel
    {

        public string VenueName { get; set; }
        public string VenueActivityName { get; set; }
        public string TeamName { get; set; }
        public List<string> TeamNameList { get; set; }
        public int TeamCount { get; set; }
        public List<TeamFlag> TeamFlagList { get; set; }
    }

    public class TeamFlag
    {
        public string TeamFlagName { get; set; }
        public int FlagValue { get; set; }
    }
}


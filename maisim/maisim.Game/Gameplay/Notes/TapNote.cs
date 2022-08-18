namespace maisim.Game.Gameplay.Notes
{
    /// <summary>
    /// The normal TAP note.
    /// </summary>
    public class TapNote : INote
    {
        public NoteLane Lane { get; set; }

        public double TargetTime { get; set; }

        public string GetEncodeString()
        {
            return "1," + NoteLaneExtension.GetNumberByNoteLane(Lane) + "," + TargetTime;
        }
    }
}

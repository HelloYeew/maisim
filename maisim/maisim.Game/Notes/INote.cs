using maisim.Game.Component.Gameplay.Notes;

namespace maisim.Game.Notes
{
    /// <summary>
    /// Interface for a note.
    /// </summary>
    public interface INote
    {
        /// <summary>
        /// A <see cref="NoteLane"/> of the note.
        /// </summary>
        NoteLane Lane { get; set; }

        /// <summary>
        /// Target time that this note should be hit.
        /// </summary>
        double TargetTime { get; set; }

        /// <summary>
        /// Get string representation of the note in beatmap file.
        /// </summary>
        /// <returns>A string use in beatmap encoder</returns>
        string GetEncodeString();
    }
}

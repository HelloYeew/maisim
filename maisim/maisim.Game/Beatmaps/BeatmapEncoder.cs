using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using maisim.Game.Component.Gameplay.Notes;
using osu.Framework.Logging;

namespace maisim.Game.Beatmaps
{
    public class BeatmapEncoder
    {
        public BeatmapSet BeatmapSet { get; set; }

        public TrackMetadata TrackMetadata { get; set; }

        public List<KeyValuePair<Beatmap, List<DrawableNote>>> Beatmaps { get; set; }

        public BeatmapEncoder(BeatmapSet beatmapSet, TrackMetadata trackMetadata)
        {
            TrackMetadata = trackMetadata;
            BeatmapSet = beatmapSet;
            Beatmaps = new List<KeyValuePair<Beatmap, List<DrawableNote>>>();
        }

        public void AddBeatmap(Beatmap beatmap, List<DrawableNote> notes)
        {
            Beatmaps.Add(new KeyValuePair<Beatmap, List<DrawableNote>>(beatmap, notes));
        }

        public void Encode()
        {
            // Before encode we need to check that beatmap is available
            if (Beatmaps.Count == 0)
                throw new Exception("No beatmaps to encode");

            // Check if target directory exists
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "maisim", "beatmaps",
                    $"{BeatmapSet.DatabaseID.ToString()} {BeatmapSet.TrackMetadata.Artist} - {BeatmapSet.TrackMetadata.Title}")))
            {
                Directory.CreateDirectory(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", "beatmaps",
                    $"{BeatmapSet.DatabaseID.ToString()} {BeatmapSet.TrackMetadata.Artist} - {BeatmapSet.TrackMetadata.Title}"));
            }

            // Encode each beatmaps
            foreach (var beatmap in Beatmaps)
            {
                using (StreamWriter file = File.CreateText(Path.Combine(
                           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", "beatmaps",
                           $"{BeatmapSet.DatabaseID.ToString()} {BeatmapSet.TrackMetadata.Artist} - {BeatmapSet.TrackMetadata.Title}",
                           $"{beatmap.Key.DatabaseID.ToString()}.msbm")))
                {
                    file.WriteLine("maisim beatmap file version 1");
                    file.WriteLine("");

                    // Add every property in beatmap object to the file using property name: value
                    foreach (PropertyInfo property in beatmap.Key.GetType().GetProperties())
                    {
                        if (property.Name != "DatabaseID" && property.Name != "TrackMetadata" &&
                            property.Name != "BeatmapSet")
                        {
                            file.WriteLine(property.Name + ": " + property.GetValue(beatmap.Key));
                        }
                    }

                    // Write all beatmap track metadata to the file
                    file.WriteLine("");
                    foreach (PropertyInfo property in TrackMetadata.GetType().GetProperties())
                    {
                        if (property.Name != "ID" && property.Name != "ConnectBeatmapSet")
                        {
                            file.WriteLine(property.Name + ": " + property.GetValue(TrackMetadata));
                        }
                    }

                    // Write all beatmap set metadata to the file
                    file.WriteLine("");
                    foreach (PropertyInfo property in BeatmapSet.GetType().GetProperties())
                    {
                        if (property.Name != "DatabaseID" && property.Name != "TrackMetadata" && property.Name != "Beatmaps")
                        {
                            file.WriteLine(property.Name + ": " + property.GetValue(BeatmapSet));
                        }
                    }

                    // Write all notes to the file
                    file.WriteLine("");
                    foreach (var note in beatmap.Value)
                    {
                        file.WriteLine(note.GetEncodeString());
                    }

                    file.Close();
                }
            }

            using (StreamWriter file = File.CreateText(Path.Combine(
                       Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", "beatmaps",
                       $"{BeatmapSet.DatabaseID.ToString()} {BeatmapSet.TrackMetadata.Artist} - {BeatmapSet.TrackMetadata.Title}",
                       $"{BeatmapSet.DatabaseID.ToString()}.msbs")))
            {
                file.WriteLine("maisim beatmap set file version 1");
                file.WriteLine("");

                foreach (PropertyInfo property in BeatmapSet.GetType().GetProperties())
                {
                    if (property.Name != "DatabaseID" && property.Name != "TrackMetadata" &&
                        property.Name != "Beatmaps")
                    {
                        file.WriteLine(property.Name + ": " + property.GetValue(BeatmapSet));
                    }
                }

                file.WriteLine("");
                foreach (PropertyInfo property in TrackMetadata.GetType().GetProperties())
                {
                    if (property.Name != "ID" && property.Name != "ConnectBeatmapSet")
                    {
                        file.WriteLine(property.Name + ": " + property.GetValue(TrackMetadata));
                    }
                }
            }

            Logger.LogPrint("Encoding complete, file saved to " + Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", "beatmaps",
                $"{BeatmapSet.DatabaseID.ToString()} {BeatmapSet.TrackMetadata.Artist} - {BeatmapSet.TrackMetadata.Title}",
                $"{BeatmapSet.DatabaseID.ToString()}.msbs"));
        }
    }
}

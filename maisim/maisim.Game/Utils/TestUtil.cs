using System;
using System.Collections.Generic;
using System.Linq;
using maisim.Game.Beatmaps;
using maisim.Game.Scores;

namespace maisim.Game.Utils
{
    /// <summary>
    /// Class working as helper for create mock object using in the test.
    /// </summary>
    public class TestUtil
    {
        private static Random random = new Random();

        /// <summary>
        /// List of full <see cref="TrackMetadata"/> detail that has texture available and can be use for full testing.
        /// </summary>
        public static readonly TrackMetadata[] FULL_TRACK_METADATA_LIST = {
            new TrackMetadata
            {
                Title = "Diamond City Lights",
                Artist = "LazuLight",
                Bpm = 185,
                CoverPath = "Test/diamond-city-lights.jpg"
            },
            new TrackMetadata
            {
                Title = "光線チューニング",
                Artist = "ナユタン星人 feat. 000",
                Bpm = 100,
                CoverPath = "Test/nayutalien.jpg"
            },
            new TrackMetadata
            {
                Title = "only my railgun",
                Artist = "fripSide",
                Bpm = 143,
                CoverPath = "Test/only-my-railgun.jpg"
            },
            new TrackMetadata
            {
                Title = "RAISE MY SWORD",
                Artist = "GALNERYUS",
                Bpm = 220,
                CoverPath = "Test/raise-my-sword.jpg"
            },new TrackMetadata
            {
                Title = "시간을 달려서 (ROUGH)",
                Artist = "GFRIEND",
                Bpm = 112,
                CoverPath = "Test/snowflake.jpg"
            },new TrackMetadata
            {
                Title = "Sukino Skill",
                Artist = "Wake Up, Girls!",
                Bpm = 120,
                CoverPath = "Test/sukino-skill.jpg"
            },new TrackMetadata
            {
                Title = "Tenkai e no Kippu",
                Artist = "Dragon Guardian",
                Bpm = 190,
                CoverPath = "Test/tenkai-e-no-kippu.jpg"
            }
        };

        /// <summary>
        /// List of random name that can be use for testing.
        /// </summary>
        public static readonly string[] RANDOM_NAME_LIST = {
            "GIGACHAD",
            "Pogpega",
            "EduardoLinguino",
            "Tutel",
            "SUSSY",
            "PogU"
        };

        /// <summary>
        /// Get a random <see cref="TrackMetadata"/> from <see cref="FULL_TRACK_METADATA_LIST"/>.
        /// </summary>
        public static TrackMetadata GetRandomTrackMetadata()
        {
            return FULL_TRACK_METADATA_LIST[new Random().Next(FULL_TRACK_METADATA_LIST.Length)];
        }

        /// <summary>
        /// Get a random <see cref="DifficultyLevel"/>.
        /// </summary>
        public static DifficultyLevel GetRandomDifficultyLevel()
        {
            return (DifficultyLevel)new Random().Next(Enum.GetValues(typeof(DifficultyLevel)).Length);
        }

        /// <summary>
        /// Get a random name from <see cref="RANDOM_NAME_LIST"/>.
        /// </summary>
        public static string GetRandomName()
        {
            return RANDOM_NAME_LIST[new Random().Next(RANDOM_NAME_LIST.Length)];
        }

        /// <summary>
        /// Return a <see cref="Beatmap"/> with complete random data.
        /// You can put <see cref="TrackMetadata"/> as parameter if you want to use a specific <see cref="TrackMetadata"/> as property for this <see cref="Beatmap"/>.
        /// </summary>
        public static Beatmap CreateMockBeatmap(TrackMetadata trackMetadata = null)
        {
            return new Beatmap()
            {
                TrackMetadata = trackMetadata ?? GetRandomTrackMetadata(),
                DifficultyLevel = GetRandomDifficultyLevel(),
                DifficultyRating = random.Next(1, 10),
                NoteDesigner = GetRandomName()
            };
        }

        /// <summary>
        /// Return a <see cref="Score"/> with complete random data.
        ///
        /// You can put <see cref="Beatmap"/> as parameter if you want to use a specific <see cref="Beatmap"/> as property for this <see cref="Score"/>.
        /// </summary>
        public static Score CreateMockScore(Beatmap beatmap = null)
        {
            if (beatmap == null)
            {
                beatmap = CreateMockBeatmap();
            }

            float accuracy = random.NextFloatInRange(1, 100);

            return new Score()
            {
                Beatmap = beatmap,
                Tap = random.NextInRange(1, 200),
                Hold = random.NextInRange(1, 200),
                Slide = random.NextInRange(1, 200),
                Touch = random.NextInRange(1, 200),
                Accuracy = accuracy,
                Rank = ScoreProcessor.CalculateRank(accuracy),
                Combo = random.NextInRange(1, 500),
            };
        }

        public static string GetBeatmapSetAudioPath(TrackMetadata trackMetadata)
        {
            string title = trackMetadata.Title;

            switch (title)
            {
                case "Diamond City Lights":
                    return "Test/diamond-city-lights.mp3";
                case "only my railgun":
                    return "Test/only-my-railgun.m4a";
                case "RAISE MY SWORD":
                    return "Test/raise-my-sword.mp3";
                case "Sukino Skill":
                    return "Test/sukino-skill.mp3";
                case "tenkai e no kippu":
                    return "Test/tenkai-e-no-kippu.mp3";
                default:
                    throw new NotImplementedException("The audio path for this track metadata is not implemented yet.");
            }
        }

        public static int GetBeatmapSetPreviewTime(TrackMetadata trackMetadata)
        {
            string title = trackMetadata.Title;

            switch (title)
            {
                case "Diamond City Lights":
                    return 5700;
                case "only my railgun":
                    return 6000;
                case "RAISE MY SWORD":
                    return 9600;
                case "Sukino Skill":
                    return 5450;
                case "tenkai e no kippu":
                    return 8800;
                default:
                    throw new NotImplementedException("The preview time for this track metadata is not implemented yet.");
            }
        }
    }

    public class TrackTestFixture
    {
        public TrackMetadata TrackMetadata { get; set; }
        public Beatmap Beatmap { get; set; }
        public Score Score { get; set; }

        /// <summary>
        /// Create a bundle of random <see cref="TrackMetadata"/>, <see cref="Beatmap"/> and <see cref="Score"/> that can be used for testing.
        ///
        /// If you want to use the <see cref="TrackMetadata"/> that is available for test in <see cref="TestUtil.FULL_TRACK_METADATA_LIST"/>, put the track title as a parameter.
        /// </summary>
        public TrackTestFixture(string trackTitle = null)
        {
            if (trackTitle == null)
            {
                TrackMetadata = TestUtil.GetRandomTrackMetadata();
            }
            else
            {
                // Find the trackMetadata with the given title, if cannot find, use a random one.
                TrackMetadata = TestUtil.FULL_TRACK_METADATA_LIST.FirstOrDefault(x => x.Title == trackTitle) ?? TestUtil.GetRandomTrackMetadata();
            }
            Beatmap = TestUtil.CreateMockBeatmap(TrackMetadata);
            Score = TestUtil.CreateMockScore(Beatmap);
        }
    }

    public class BeatmapSetTestFixture
    {
        public BeatmapSet BeatmapSet { get; set; }
        private TrackMetadata trackMetadata { get; set; }
        private List<Beatmap> beatmaps = new List<Beatmap>();

        public BeatmapSetTestFixture(string trackTitle = null)
        {
            if (trackTitle == null)
            {
                trackMetadata = TestUtil.GetRandomTrackMetadata();
            }
            else
            {
                // Find the trackMetadata with the given title, if cannot find, use a random one.
                // The trackMetadata need to have the audio path set.
                // Just check that the switch case in TestUtil.GetBeatmapSetAudioPath() is implemented for the track title.
                trackMetadata = TestUtil.FULL_TRACK_METADATA_LIST.FirstOrDefault(x => x.Title == trackTitle && TestUtil.GetBeatmapSetAudioPath(x) != null) ?? TestUtil.GetRandomTrackMetadata();
            }
            BeatmapSet = new BeatmapSet()
            {
                TrackMetadata = trackMetadata,
                Creator = TestUtil.GetRandomName(),
                BeatmapSetID = 10,
                Beatmaps = beatmaps,
                AudioFileName = TestUtil.GetBeatmapSetAudioPath(trackMetadata),
                PreviewTime = TestUtil.GetBeatmapSetPreviewTime(trackMetadata)
            };
            for (int i = 0; i < 4; i++)
            {
                Beatmap dummyBeatmap = TestUtil.CreateMockBeatmap(trackMetadata);
                dummyBeatmap.DifficultyLevel = (DifficultyLevel)i;
                dummyBeatmap.DifficultyRating = RandomExtensions.NextInRange(new Random(), 3*i+1, 3*i+3);
                dummyBeatmap.NoteDesigner = BeatmapSet.Creator;
                beatmaps.Add(dummyBeatmap);
            }
        }
    }
}

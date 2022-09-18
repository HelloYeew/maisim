using System;
using System.Collections.Generic;
using System.Linq;
using maisim.Game.Beatmaps;
using maisim.Game.Scores;
using osu.Framework.Logging;

namespace maisim.Game.Utils
{
    /// <summary>
    /// Class working as helper for create mock object using in the test.
    /// </summary>
    public class TestUtil
    {
        internal static Random random = new Random();

        /// <summary>
        /// The enum of the song that can be used for full test.
        /// The value of enum is the index of the <see cref="TrackMetadata"/> in <see cref="TestUtil.FULL_TRACK_METADATA_LIST"/>
        /// </summary>
        public enum AvailableTrackMetadata
        {
            None = -1,
            DiamondCityLights = 0,
            RayTuning = 1,
            OnlyMyRailgun = 2,
            RaiseMySword = 3,
            Rough = 4,
            SukinoSkill = 5,
            TenkaiENoKippu = 6,
            ReI = 7
        }

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
            },new TrackMetadata
            {
                Title = "ReI",
                Artist = "THE ORAL CIGARETTES",
                Bpm = 200,
                CoverPath = "Test/rei.jpeg"
            }
        };

        /// <summary>
        /// The list of the <see cref="TrackMetadata"/> that has the track inside game's resources.
        /// </summary>
        public static readonly AvailableTrackMetadata[] AVAILABLE_BEATMAP_SET_TRACK =
        {
            AvailableTrackMetadata.DiamondCityLights,
            AvailableTrackMetadata.OnlyMyRailgun,
            AvailableTrackMetadata.RaiseMySword,
            AvailableTrackMetadata.SukinoSkill,
            AvailableTrackMetadata.TenkaiENoKippu,
            AvailableTrackMetadata.ReI,
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

        /// <summary>
        /// Get the audio file path that's live in game's resources for testing.
        /// When using this please set <see cref="BeatmapSet"/>'s `UseLocalPath` to `true`.
        /// </summary>
        /// <param name="availableTrackMetadata">The target track metadata sample</param>
        /// <returns>Path using in game's resource</returns>
        public static string GetBeatmapSetAudioPath(AvailableTrackMetadata availableTrackMetadata)
        {
            switch (availableTrackMetadata)
            {
                case AvailableTrackMetadata.DiamondCityLights:
                    return "Test/diamond-city-lights.mp3";
                case AvailableTrackMetadata.OnlyMyRailgun:
                    return "Test/only-my-railgun.m4a";
                case AvailableTrackMetadata.RaiseMySword:
                    return "Test/raise-my-sword.mp3";
                case AvailableTrackMetadata.SukinoSkill:
                    return "Test/sukino-skill.mp3";
                case AvailableTrackMetadata.TenkaiENoKippu:
                    return "Test/tenkai-e-no-kippu.mp3";
                case AvailableTrackMetadata.ReI:
                    return "Test/rei.mp3";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Get the preview time of the audio file for target <see cref="TrackMetadata"/>.
        /// </summary>
        /// <param name="availableTrackMetadata">The target track metadata sample</param>
        /// <returns>Preview time</returns>
        public static int GetBeatmapSetPreviewTime(AvailableTrackMetadata availableTrackMetadata)
        {
            switch (availableTrackMetadata)
            {
                case AvailableTrackMetadata.DiamondCityLights:
                    return 57500;
                case AvailableTrackMetadata.OnlyMyRailgun:
                    return 62000;
                case AvailableTrackMetadata.RaiseMySword:
                    return 96500;
                case AvailableTrackMetadata.SukinoSkill:
                    return 55000;
                case AvailableTrackMetadata.TenkaiENoKippu:
                    return 88900;
                case AvailableTrackMetadata.ReI:
                    return 76000;
                default:
                    return 0;
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
        public TrackTestFixture(TestUtil.AvailableTrackMetadata availableTrackMetadata = TestUtil.AvailableTrackMetadata.None)
        {
            if (availableTrackMetadata == TestUtil.AvailableTrackMetadata.None)
            {
                TrackMetadata = TestUtil.GetRandomTrackMetadata();
            }
            else
            {
                // Find the trackMetadata with the given title
                TrackMetadata = TestUtil.FULL_TRACK_METADATA_LIST[(int)availableTrackMetadata];
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

        /// <summary>
        /// Generate a random <see cref="BeatmapSet"/> with complete random data.
        ///
        /// Note that this method will only generate a <see cref="BeatmapSet"/> that contain the track resources.
        /// </summary>
        public BeatmapSetTestFixture(TestUtil.AvailableTrackMetadata availableTrackMetadata = TestUtil.AvailableTrackMetadata.None)
        {
            if (availableTrackMetadata == TestUtil.AvailableTrackMetadata.None)
            {
                // Collect the enum of available track metadata that has track resources
                List<TestUtil.AvailableTrackMetadata> availableTrackMetadataList = Enum.GetValues(typeof(TestUtil.AvailableTrackMetadata)).Cast<TestUtil.AvailableTrackMetadata>().Where(x => TestUtil.GetBeatmapSetAudioPath(x) != "").ToList();
                // Randomly pick one of them
                availableTrackMetadata = availableTrackMetadataList[RandomExtensions.NextInRange(new Random(), 0, availableTrackMetadataList.Count)];
            }
            trackMetadata = TestUtil.FULL_TRACK_METADATA_LIST[(int)availableTrackMetadata];
            BeatmapSet = new BeatmapSet()
            {
                TrackMetadata = trackMetadata,
                Creator = TestUtil.GetRandomName(),
                BeatmapSetID = 10,
                Beatmaps = beatmaps,
                AudioFileName = TestUtil.GetBeatmapSetAudioPath(availableTrackMetadata),
                PreviewTime = TestUtil.GetBeatmapSetPreviewTime(availableTrackMetadata),
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

using System;
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
        public static readonly TrackMetadata[] FullTrackMetadataList = {
            new TrackMetadata
            {
                Title = "Lemon",
                Artist = "Kenshi Yonezu",
                Bpm = 80,
                CoverPath = "Test/lemon.jpg"
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
        public static readonly string[] RandomNameList = {
            "GIGACHAD",
            "Pogpega",
            "EduardoLinguino",
            "Tutel",
            "SUSSY",
            "PogU"
        };

        /// <summary>
        /// Get a random <see cref="TrackMetadata"/> from <see cref="FullTrackMetadataList"/>.
        /// </summary>
        public static TrackMetadata GetRandomTrackMetadata()
        {
            return FullTrackMetadataList[new Random().Next(FullTrackMetadataList.Length)];
        }

        /// <summary>
        /// Get a random <see cref="DifficultyLevel"/>.
        /// </summary>
        public static DifficultyLevel GetRandomDifficultyLevel()
        {
            return (DifficultyLevel)new Random().Next(Enum.GetValues(typeof(DifficultyLevel)).Length);
        }

        /// <summary>
        /// Get a random name from <see cref="RandomNameList"/>.
        /// </summary>
        public static string GetRandomName()
        {
            return RandomNameList[new Random().Next(RandomNameList.Length)];
        }

        /// <summary>
        /// Return a <see cref="Beatmap"/> with complete random data.
        /// You can put <see cref="TrackMetadata"/> as parameter if you want to use a specific <see cref="TrackMetadata"/> as property for this <see cref="Beatmap"/>.
        /// </summary>
        public static Beatmap GetRandomBeatmap(TrackMetadata trackMetadata = null)
        {
            return new Beatmap()
            {
                TrackMetadata = trackMetadata ?? GetRandomTrackMetadata(),
                DifficultyLevel = GetRandomDifficultyLevel(),
                DifficultyRating = random.Next(1, 10),
                IsRemaster = random.Next(2) == 1,
                MaxSeasonalScore = random.NextInRange(100, 10000),
                NoteDesigner = GetRandomName()
            };
        }

        /// <summary>
        /// Return a <see cref="Score"/> with complete random data.
        ///
        /// You can put <see cref="Beatmap"/> as parameter if you want to use a specific <see cref="Beatmap"/> as property for this <see cref="Score"/>.
        /// </summary>
        public static Score GetRandomScore(Beatmap beatmap = null)
        {
            if (beatmap == null)
            {
                beatmap = GetRandomBeatmap();
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
                SeasonalScore = random.NextInRange(1, (int)beatmap.MaxSeasonalScore)
            };
        }
    }

    public class TestFixture
    {
        public TrackMetadata TrackMetadata { get; set; }
        public Beatmap Beatmap { get; set; }
        public Score Score { get; set; }

        /// <summary>
        /// Create a bundle of random <see cref="TrackMetadata"/>, <see cref="Beatmap"/> and <see cref="Score"/> that can be used for testing.
        ///
        /// If you want to use the <see cref="TrackMetadata"/> that is available for test in <see cref="TestUtil.FullTrackMetadataList"/>, put the track title as a parameter.
        /// </summary>
        public TestFixture(string trackTitle = null)
        {
            if (trackTitle == null)
            {
                TrackMetadata = TestUtil.GetRandomTrackMetadata();
            }
            else
            {
                // Find the trackMetadata with the given title, if cannot find, use a random one.
                TrackMetadata = TestUtil.FullTrackMetadataList.FirstOrDefault(x => x.Title == trackTitle) ?? TestUtil.GetRandomTrackMetadata();
            }
            Beatmap = TestUtil.GetRandomBeatmap(TrackMetadata);
            Score = TestUtil.GetRandomScore(Beatmap);
        }
    }
}

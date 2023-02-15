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
        internal static Random random = new Random();

        /// <summary>
        /// The enum of the song that can be used for full test.
        /// The value of enum is the index of the <see cref="TrackMetadata"/> in <see cref="TestUtil.FULL_TRACK_METADATA_LIST"/>
        /// </summary>
        public enum AvailableTrackMetadata
        {
            None = -1,
            Canon = 0,
            RayTuning = 1,
            OnlyMyRailgun = 2,
            Rough = 3,
            SukinoSkill = 4,
            TenkaiENoKippu = 5,
            ReI = 6,
            NewGenesis = 7,
            EndlessTewiMaPark = 8,
            DenebAndSpica = 9
        }

        /// <summary>
        /// The list of the <see cref="TrackMetadata"/> that has the track inside game's resources.
        /// </summary>
        public static readonly AvailableTrackMetadata[] AvailableBeatmapSetTrack =
        {
            AvailableTrackMetadata.Canon,
            AvailableTrackMetadata.OnlyMyRailgun,
            AvailableTrackMetadata.SukinoSkill,
            AvailableTrackMetadata.TenkaiENoKippu,
            AvailableTrackMetadata.ReI,
            AvailableTrackMetadata.NewGenesis,
            AvailableTrackMetadata.EndlessTewiMaPark,
            AvailableTrackMetadata.DenebAndSpica
        };

        /// <summary>
        /// List of full <see cref="TrackMetadata"/> detail that has texture available and can be use for full testing.
        /// </summary>
        public static readonly TrackMetadata[] FULL_TRACK_METADATA_LIST = {
            new TrackMetadata
            {
                Title = "Canon",
                TitleUnicode = "カノン",
                Artist = "DJ Okawari",
                ArtistUnicode = "DJ Okawari",
                Bpm = 98,
                CoverPath = "Test/cohana2nd.jpg",
                Source = "心花 ～cohana 2nd～ Healing Break Beats oriental classics"
            },
            new TrackMetadata
            {
                Title = "Ray Tuning",
                TitleUnicode = "光線チューニング",
                Artist = "Nayutalien feat. 000",
                ArtistUnicode = "ナユタン星人 feat. 000",
                Bpm = 100,
                CoverPath = "Test/nayutalien.jpg",
                Source = "ナユタン星からの物体Z"
            },
            new TrackMetadata
            {
                Title = "only my railgun",
                TitleUnicode = "only my railgun",
                Artist = "fripSide",
                ArtistUnicode = "fripSide",
                Bpm = 143,
                CoverPath = "Test/only-my-railgun.jpg",
                Source = "A Certain Scientific Railgun"
            },new TrackMetadata
            {
                Title = "Rough",
                TitleUnicode = "시간을 달려서 (ROUGH)",
                Artist = "GFRIEND",
                ArtistUnicode = "여자친구",
                Bpm = 112,
                CoverPath = "Test/snowflake.jpg",
                Source = "Snowflake"
            },new TrackMetadata
            {
                Title = "Sukino Skill",
                TitleUnicode = "スキノスキル",
                Artist = "Wake Up, Girls!",
                ArtistUnicode = "Wake Up, Girls!",
                Bpm = 120,
                CoverPath = "Test/sukino-skill.jpg",
                Source = "Death March to the Parallel World Rhapsody"
            },new TrackMetadata
            {
                Title = "Tenkai e no Kippu",
                TitleUnicode = "天界への切符",
                Artist = "Dragon Guardian",
                ArtistUnicode = "Dragon Guardian",
                Bpm = 190,
                CoverPath = "Test/tenkai-e-no-kippu.jpg",
                Source = "Dragon Guardian"
            },new TrackMetadata
            {
                Title = "ReI",
                TitleUnicode = "ReI",
                Artist = "THE ORAL CIGARETTES",
                ArtistUnicode = "THE ORAL CIGARETTES",
                Bpm = 200,
                CoverPath = "Test/rei.jpeg",
                Source = "ReI"
            },new TrackMetadata
            {
                Title = "New Genesis",
                TitleUnicode = "新時代",
                Artist = "Ado",
                ArtistUnicode = "Ado",
                Bpm = 140,
                CoverPath = "Test/ado-one-piece-film-red.jpg",
                Source = "ONE PIECE FILM RED"
            },new TrackMetadata
            {
                Title = "Endless Tewi-me Park",
                TitleUnicode = "エンドレス・てゐマパーク (Endless Tewi-me-park)",
                Artist = "Toromi",
                ArtistUnicode = "とろ美",
                Bpm = 140,
                CoverPath = "Test/touhou-merenge-shoujo-yakou.jpg",
                Source = "東方花映塚　～ Phantasmagoria of Flower View"
            },new TrackMetadata()
            {
                Title = "Deneb and Spica",
                TitleUnicode = "デネブとスピカ (Deneb and Spica)",
                Artist = "DIALOGUE+",
                ArtistUnicode = "DIALOGUE+",
                Bpm = 140,
                CoverPath = "Test/deneb-and-spica.jpg",
                Source = "継母の連れ子が元カノだった"
            }
        };
        /// <summary>
        /// List of random name that can be use for testing.
        /// </summary>
        public static readonly string[] RANDOM_NAME_LIST = {
            "GIGACHAD",
            "Pogpega",
            "Tutel",
            "SUSSY",
            "PogU",
            "Amogus"
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
                case AvailableTrackMetadata.Canon:
                    return "Test/canon.m4a";
                case AvailableTrackMetadata.OnlyMyRailgun:
                    return "Test/only-my-railgun.m4a";
                case AvailableTrackMetadata.SukinoSkill:
                    return "Test/sukino-skill.mp3";
                case AvailableTrackMetadata.TenkaiENoKippu:
                    return "Test/tenkai-e-no-kippu.mp3";
                case AvailableTrackMetadata.ReI:
                    return "Test/rei.mp3";
                case AvailableTrackMetadata.NewGenesis:
                    return "Test/new-genesis.mp3";
                case AvailableTrackMetadata.EndlessTewiMaPark:
                    return "Test/endless-tewi-ma-park.mp3";
                case AvailableTrackMetadata.DenebAndSpica:
                    return "Test/deneb-and-spica.mp3";
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
                case AvailableTrackMetadata.Canon:
                    return 97900;
                case AvailableTrackMetadata.OnlyMyRailgun:
                    return 62000;
                case AvailableTrackMetadata.SukinoSkill:
                    return 55000;
                case AvailableTrackMetadata.TenkaiENoKippu:
                    return 88900;
                case AvailableTrackMetadata.ReI:
                    return 76000;
                case AvailableTrackMetadata.NewGenesis:
                    return 88200;
                case AvailableTrackMetadata.EndlessTewiMaPark:
                    return 38000;
                case AvailableTrackMetadata.DenebAndSpica:
                    return 54000;
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
                UseLocalFile = true
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

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Framework.Platform;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays.Settings.Debugs
{
    public partial class FolderSettings : SettingsSubsection
    {
        protected override LocalisableString Header => "folder";

        [BackgroundDependencyLoader]
        private void load(Storage storage)
        {
            Children = new Drawable[]
            {
                new MaisimButton("open maisim folder", Color4.MediumPurple, Color4.White)
                {
                    Action = () => storage.PresentExternally(),
                    Size = new Vector2(SECTION_WIDTH, 40),
                }
            };
        }
    }
}

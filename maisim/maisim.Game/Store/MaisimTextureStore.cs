using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;

namespace maisim.Game.Store
{
    public class MaisimTextureStore : LargeTextureStore
    {
        public MaisimTextureStore(IRenderer renderer, IResourceStore<TextureUpload> store) : base(renderer, store)
        {

        }
    }
}

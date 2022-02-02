using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;

namespace maisim.Game.Store
{
    public class MaisimTextureStore : LargeTextureStore
    {
        public MaisimTextureStore(IResourceStore<TextureUpload> store) : base(store)
        {

        }
    }
}

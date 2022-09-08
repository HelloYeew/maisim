using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using osu.Framework.Extensions;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;

namespace maisim.Game.Store
{
    public class MaisimStore : IResourceStore<byte[]>
    {
        public readonly Storage storage;

        public MaisimStore(Storage storage)
        {
            this.storage = storage;
        }

        public byte[] Get(string name)
        {
            using (Stream stream = storage.GetStream(name))
                return stream?.ReadAllBytesToArray();
        }

        public virtual Task<byte[]> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            using (Stream stream = storage.GetStream(name))
                return stream?.ReadAllBytesToArrayAsync(cancellationToken);
        }

        public Stream GetStream(string name)
        {
            return storage.GetStream(name);
        }

        public IEnumerable<string> GetAvailableResources() =>
            storage.GetDirectories(string.Empty).SelectMany(d => storage.GetFiles(d)).ExcludeSystemFileNames();

        #region IDisposable Support

        public void Dispose()
        {
        }

        #endregion
    }
}

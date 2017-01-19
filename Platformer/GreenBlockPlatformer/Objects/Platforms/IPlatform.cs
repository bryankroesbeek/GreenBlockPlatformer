using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBlockPlatformer.Objects.Platforms {
    public interface IPlatform : IComponent{
        int Width { get; }
        int Height { get; }
    }
}

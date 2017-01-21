using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GreenBlockPlatformer.Objects.Camera {
    public interface ICamera : IComponent{
        Matrix ViewMatrix { get; }
    }
}

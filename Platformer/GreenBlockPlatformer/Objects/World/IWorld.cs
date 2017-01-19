using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBlockPlatformer.Objects.Character;
using GreenBlockPlatformer.Objects.Platforms;

namespace GreenBlockPlatformer.Objects.World {
    interface IWorld : IDrawableComponent{
        Box Character { get; set; }
        List<Platform> Platforms { get; set; }
    }
}

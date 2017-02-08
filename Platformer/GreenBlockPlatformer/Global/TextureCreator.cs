using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Global {
    public static class TextureCreator {
        public static Texture2D CreateMonoTexture(this GraphicsDevice device, int width, int height, Color color) {
            Texture2D retTexture = new Texture2D(device, width, height);

            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++) {
                colors[i] = color;
            }

            retTexture.SetData(colors);

            return retTexture;
        }

        public static Texture2D CreateTextureFromFile(this ContentManager content,string filename) {
            return content.Load<Texture2D>(filename);
        }
    }
}

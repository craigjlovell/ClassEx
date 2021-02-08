using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_Game_Settings
{
    class GameSetting
    {
        public int windowH;
        public int windowW;
        public string windowT;

        public GameSetting(int width, int height, string title)
        {
            windowH = height;
            windowT = title;
            windowW = width;
        }
    }
}

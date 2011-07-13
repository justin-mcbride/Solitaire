using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solitaire {
    class Utilities {
        public int RandomNumber(int min, int max) {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}

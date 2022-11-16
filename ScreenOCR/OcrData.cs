using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenOCR
{
    public class OcrData
    {
        public bool isError { get; set; }
        public String message { get; set; }

        public Point location { get; set; }
        public Size size { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screeshoter
{
    [Guid("8EAA5857-5369-4F85-B400-96487A1A2BC3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IScreenshoter
    {
        void Save(string filePath);
    }
    
    [Guid("CE266B7E-AF48-48C1-BAC3-70C006612D60")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Screenshot: IScreenshoter
    {        
        public void Save(string filePath)
        {            
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save(filePath, ImageFormat.Jpeg);
            }

        }
        
    }
}

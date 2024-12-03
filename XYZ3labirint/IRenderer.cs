using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTemplate
{
    public interface IRenderer
    {
        public void SetCell(int x, int y, string val);

        public void Render();
    }
}

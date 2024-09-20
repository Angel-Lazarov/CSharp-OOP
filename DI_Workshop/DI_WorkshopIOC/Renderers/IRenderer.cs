using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_WorkshopIOC.Renderers
{
    public interface IRenderer
    {
        public void Write(string text, Position position);
        public void WriteLine(string text, Position position);
    }
}

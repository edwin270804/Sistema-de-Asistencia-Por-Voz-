using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAsistenciaPorVoz.UI.Forms
{
    public class NoFocusIconButton : IconButton
    {
        protected override bool ShowFocusCues => false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils.Animation;
namespace SC.Common.Control
{
    public class CustomNavigationFrame : NavigationFrame
    {
        public TransitionManager TransitionManager {
            get { return base.TransitionManager; }
        }
    }
}

using Android.Graphics.Drawables;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientTabbar;
internal class GradientTabbarShellHandler : ShellRenderer
{
    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        //return base.CreateBottomNavViewAppearanceTracker(shellItem);
        return new GradientBottomNavViewAppearanceTracker(this, shellItem);
    }
}
internal class GradientBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
{
    public GradientBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) 
        : base(shellContext, shellItem)
    {
    }

    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    {
        base.SetAppearance(bottomView, appearance);

        var gradientDrawable = new GradientDrawable(
            GradientDrawable.Orientation.LeftRight,
            [Colors.Orange.ToPlatform(), Colors.Yellow.ToPlatform()]);

        bottomView.SetBackground(gradientDrawable);        
    }
}

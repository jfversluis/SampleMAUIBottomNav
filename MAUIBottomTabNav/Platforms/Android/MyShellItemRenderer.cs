using System;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomSheet;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using LP = Android.Views.ViewGroup.LayoutParams;
using AColor = Android.Graphics.Color;
using Android.Content.Res;
using Android.Graphics.Drawables;

namespace MAUIBottomTabNav;

public class MyShellRenderer : ShellRenderer
{
    protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
    {
        return new MyShellItemRenderer(this);
    }
}

	public class MyShellItemRenderer : ShellItemRenderer
	{
		public MyShellItemRenderer(IShellContext context)
			: base (context)
		{
		}

    List<(string title, ImageSource icon, bool tabEnabled)> CreateTabList(ShellItem shellItem)
    {
        var items = new List<(string title, ImageSource icon, bool tabEnabled)>();
        var shellItems = ((IShellItemController)shellItem).GetItems();

        for (int i = 0; i < shellItems.Count; i++)
        {
            var item = shellItems[i];
            items.Add((item.Title, item.Icon, item.IsEnabled));
        }
        return items;
    }

    void OnMoreItemSelected(int shellSectionIndex, BottomSheetDialog dialog)
    {
        OnMoreItemSelected(ShellItemController.GetItems()[shellSectionIndex], dialog);
    }


    protected override Drawable CreateItemBackgroundDrawable()
    {
        var stateList = ColorStateList.ValueOf(Colors.Black.MultiplyAlpha(0.2f).ToPlatform());
        var colorDrawable = new ColorDrawable(AColor.DarkSlateBlue);
        return new RippleDrawable(stateList, colorDrawable, null);
    }


    protected override bool OnItemSelected(IMenuItem item)
    {
        var id = item.ItemId;
        if (id == MoreTabId)
        {
            var items = CreateTabList(ShellItem);
            var _bottomSheetDialog = CreateMoreBottomSheet((int a, BottomSheetDialog b) => OnMoreItemSelected(a, b));

            _bottomSheetDialog.Show();
            _bottomSheetDialog.DismissEvent += OnMoreSheetDismissed;

            return true;
        }

        return base.OnItemSelected(item);
    }
}

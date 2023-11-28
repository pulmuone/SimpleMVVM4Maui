using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui;
using SimpleMVVM4Maui.Models;
using SimpleMVVM4Maui.ViewModels;

namespace SimpleMVVM4Maui.Views;

public partial class EmpView : ContentPage
{
    private Entry _currentEntry;
	public EmpView()
	{
		InitializeComponent();
	}

    private void AgeEntry_Unfocused(object sender, FocusEventArgs e)
    {
        this.collectionView.SelectedItem = null;
    }

    private void AgeEntry_Focused(object sender, FocusEventArgs e)
    {
        _currentEntry = (sender as Entry);

        Console.WriteLine(e.ToString());

        Console.WriteLine("==> " + ((Entry)sender).ReturnCommandParameter);

        EmpModel selectedItem = (EmpModel)this.vm.EmpList.Where(i => i.EmpId == (int)((Entry)sender).ReturnCommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }


    private void minusButton_Clicked(object sender, EventArgs e)
    {
        _currentEntry?.Unfocus();
        _currentEntry?.HideKeyboardAsync(); //Maui

        EmpModel selectedItem = (EmpModel)vm.EmpList.Where(i => i.EmpId == (int)((Button)sender).CommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }

    private void plusButton_Clicked(object sender, EventArgs e)
    {
        _currentEntry?.Unfocus();
        _currentEntry?.HideKeyboardAsync(); //Maui
        //_currentEntry?.HideSoftInputAsync(CancellationToken.None); //CommunityToolkit.Maui

        EmpModel selectedItem = (EmpModel)this.vm.EmpList.Where(i => i.EmpId == (int)((Button)sender).CommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }
    private void gradePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentEntry?.Unfocus();
        _currentEntry?.HideKeyboardAsync(); //Maui

        EmpModel selectedItem = (EmpModel)this.vm.EmpList.Where(i => i.EmpId == (Convert.ToInt32(((Picker)sender).ClassId))).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }

    private void AgeEntry_Completed(object sender, EventArgs e)
    {
        _currentEntry?.Unfocus();
        _currentEntry?.HideKeyboardAsync(); //Maui

        EmpModel selectedItem = (EmpModel)this.vm.EmpList.Where(i => i.EmpId == (int)((Entry)sender).ReturnCommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }
}
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
        //_currentEntry = (sender as Entry);

        Console.WriteLine(e.ToString());

        Console.WriteLine("==> " + ((Entry)sender).ReturnCommandParameter);

        EmpModel selectedItem = (EmpModel)(BindingContext as EmpViewModel).EmpList.Where(i => i.EmpId == (int)((Entry)sender).ReturnCommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }

    private void plusButton_Clicked(object sender, EventArgs e)
    {
        //_currentEntry.Unfocus();
        EmpModel selectedItem = (EmpModel)(BindingContext as EmpViewModel).EmpList.Where(i => i.EmpId == (int)((Button)sender).CommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }

    private void minusButton_Clicked(object sender, EventArgs e)
    {
        EmpModel selectedItem = (EmpModel)(BindingContext as EmpViewModel).EmpList.Where(i => i.EmpId == (int)((Button)sender).CommandParameter).FirstOrDefault();
        this.collectionView.SelectedItem = selectedItem;
    }
}
namespace AutoresGrupo5.Views;

public partial class PageAutorList : ContentPage
{
	public PageAutorList()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		PageAutor page = new PageAutor();
		Navigation.PushAsync(page);
    }

    private void listAutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        listAutor.ItemsSource = await App.DataBaseAutor.GetListAutor();
    }
}
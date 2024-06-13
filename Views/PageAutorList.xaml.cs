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

    private async void listAutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //var filtro = await App.DataBaseAutor.GetListAutor().Result.Where(async x => x.Nombres.ToLower().Contains(e.PreviousSelection))

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        listAutor.ItemsSource = await App.DataBaseAutor.GetListAutor();
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue.ToLower();

        listAutor.ItemsSource = await App.DataBaseAutor.GetListAutorBuscar(searchText);

    }
}
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
}
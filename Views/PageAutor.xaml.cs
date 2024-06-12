using AutoresGrupo5.Models;

namespace AutoresGrupo5.Views;

public partial class PageAutor : ContentPage
{
    FileResult? photo;
    public PageAutor()
    {
        InitializeComponent();
        ListPaises();

    }

    public String GetImage64()
    {
        String Base64 = String.Empty;

        if (photo != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                byte[] data = ms.ToArray();

                Base64 = Convert.ToBase64String(data);
                return Base64;
            }
        }
        return Base64;
    }

    public byte[] GetImageArray()
    {
        byte[] data = new byte[] { };
        if (photo != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                data = ms.ToArray();

                return data;
            }
        }
        return data;
    }

    public async void ListPaises()
    {
        var listPaises = await App.DataBase.GetListPaises();
        PickerPaises.Items.Clear();

        foreach (var pais in listPaises)
        {
            PickerPaises.Items.Add(pais.Pais);
        }
    }

    private async void BtnAceptar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var pai = PickerPaises.SelectedItem == null ? "" : PickerPaises.SelectedItem.ToString();
            if(String.IsNullOrEmpty(Nombres.Text) || String.IsNullOrEmpty(pai) || String.IsNullOrEmpty(GetImage64()))
            {
                await DisplayAlert("Aviso", "campos Requeridos", "OK");
                return;
            }

            Autor newAutor = new Autor
            {
                Nombres = Nombres.Text,
                Pais = PickerPaises.SelectedItem.ToString(),
                Foto = GetImage64(),
            };

            if(await App.DataBaseAutor.StoreAutor(newAutor) > 0)
            {
                await DisplayAlert("Aviso", "Registron ingresado con éxito !!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Aviso", "Ocurrio un error al validar datos !!", "OK");
            ex.ToString();
        }
    }
    private async void BtnFoto_Clicked(object sender, EventArgs e)
    {
        try
        {
            photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                string Localizacion = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream imagenlocal = File.OpenWrite(Localizacion);

                FotoImage.Source = ImageSource.FromStream(() => photo.OpenReadAsync().Result);

                await sourceStream.CopyToAsync(imagenlocal);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    private async void BtnAgregarPais_Clicked(object sender, EventArgs e)
    {
        string getPais = await DisplayPromptAsync("Pais", "Ingrese Pais");
        if (String.IsNullOrEmpty(getPais))
        {
            await DisplayAlert("Aviso", "Favor digitar el Pais.", "OK");
            return;
        }

        Paises newPais = new Paises();
        newPais.Id = 0;
        newPais.Pais = getPais;
        await App.DataBase.StorePais(newPais);
        ListPaises();
    }
}
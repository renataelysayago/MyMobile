using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMobile.ViewModels
{
    internal class BuscaCepViewModel : ViewModelBase
    {
        private string _CEP;
        public string CEP
        {
            get => _CEP;
            set
            {
                _CEP = value;
                OnPropertyChanged();
                BuscarCommand.ChangeCanExecute();
            }
        }

        private ViaCepDto _ViaCepDto = null;

        public bool HasCep { get => !(_ViaCepDto is null); }

        public string Logradouro { get => _ViaCepDto?.logradouro; }

        public string Complemento { get => _ViaCepDto?.complemento; }

        public string Bairro { get => _ViaCepDto?.bairro; }

        public string Localidade { get => _ViaCepDto?.localidade; }

        public string UF { get => _ViaCepDto?.uf; }

        public string DDD { get => _ViaCepDto?.ddd; }

        private Command _BuscarCommand;
        public Command BuscarCommand
            => _BuscarCommand
            ?? (_BuscarCommand = new Command(
                async () => await BuscarCommandExecute(),
                () => BuscarCommandCanExecute()));

        private bool BuscarCommandCanExecute()
            => !string.IsNullOrWhiteSpace(CEP)
            && CEP.Length == 8;

        private async Task BuscarCommandExecute()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //URL: viacep.com.br/ws/01001000/json/
                    using (var response = await client.GetAsync($"https://viacep.com.br/ws/{CEP}/json/"))
                    {
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrWhiteSpace(content))
                            throw new InvalidOperationException();

                        _ViaCepDto = JsonConvert.DeserializeObject<ViaCepDto>(content);

                        if (_ViaCepDto.erro)
                            throw new InvalidOperationException();
                    }
                }
            }
            catch (Exception ex)
            {
                _ViaCepDto = null;
                await App.Current.MainPage.DisplayAlert("Ooops", "Algo errado...", "Ok");
            }
            finally
            {
                OnPropertyChanged(nameof(HasCep));
                OnPropertyChanged(nameof(Logradouro));
                OnPropertyChanged(nameof(Complemento));
                OnPropertyChanged(nameof(Bairro));
                OnPropertyChanged(nameof(Localidade));
                OnPropertyChanged(nameof(UF));
                OnPropertyChanged(nameof(DDD));
            }
        }
    }
}

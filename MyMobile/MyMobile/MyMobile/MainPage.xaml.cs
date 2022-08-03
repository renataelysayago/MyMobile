using MyMobile.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Boom_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Atenção", "Executando do Android.", "Ok");
        }

        //private async void Busca_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(buscaCepViewModel.CEP))
        //            return;

        //        using (var client = new HttpClient())
        //        {
        //            //URL: viacep.com.br/ws/01001000/json/
        //            using (var response = await client.GetAsync($"https://viacep.com.br/ws/{buscaCepViewModel.CEP}/json/"))
        //            {
        //                response.EnsureSuccessStatusCode();
        //                var content = await response.Content.ReadAsStringAsync();

        //                if (string.IsNullOrWhiteSpace(content))
        //                    throw new InvalidOperationException();

        //                var retorno = JsonConvert.DeserializeObject<ViaCepDto>(content);

        //                if (retorno.erro)
        //                    throw new InvalidOperationException();

        //                txtLogradouro.Text = retorno.logradouro;
        //                txtComplemento.Text = retorno.complemento;
        //                txtBairro.Text = retorno.bairro;
        //                txtLocalidade.Text = retorno.localidade;
        //                txtUF.Text = retorno.uf;
        //                txtDDD.Text = retorno.ddd;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        DisplayAlert("Ooops", "Algo errado...", "Ok");
        //    }
        //}
    }


    public class ViaCepDto
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
        public bool erro { get; set; } = false;
    }

}

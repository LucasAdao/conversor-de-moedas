using conversor_de_moedas.models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace conversor_de_moedas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void botaoCalcular1_Click(object sender, RoutedEventArgs e)
        {
            double dinheiroBox1 = Convert.ToDouble(textBox1.Text); 
            Main();
            async Task Main()
            {
                
    
                string apiUrl = $"https://api.invertexto.com/v1/currency/USD_BRL?token=6163|IFtvPOFE3EeFpXPBEt8quai2giB5mTAD"
    ;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            Money money = JsonConvert.DeserializeObject<Money>(responseBody);
                            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(money.currency.TimeStamp).DateTime;
                            MessageBox.Show($"Neste exato momento:{dateTime} o dolar está valendo {Math.Round(money.currency.CurrencyValue,2)}R$");

                            double valorDoDinheiro = money.currency.CurrencyValue * dinheiroBox1;
                            textBoxResultado1.Text = $"Valor em Reais: {Math.Round(valorDoDinheiro,2)}R$";


                        }
                        else
                        {
                            
                            MessageBox.Show("");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                }
            }
            }

       
        }
    }

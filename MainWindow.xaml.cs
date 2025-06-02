using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prov_wpf_e2_TE23E_William_Lauseger;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickKontrolleraPass(object sender, RoutedEventArgs e)
    {
        // Mata in längd, aktivitet och intensitet
        string aktivitet = txbAktivitet.Text;
        string intensitet = txbIntensitet.Text;
        string langd = txbLangd.Text;
        int.TryParse(langd, out int langdText);

        // skriv sammanfattning
        txbPass.Text = $"{aktivitet} kommer att köras i {langdText} min med intensiteten {intensitet}.";

        // Varna användaren vid fel inmatning
        if (aktivitet == "")
        {
            txbPass.Text = "Fältet aktivitet är tomt. Ange aktivitet!";
        }
        else if (langdText < 5 || langdText > 180)
        {
            txbPass.Text = "ogiltig tid! Ange en tid mellan 5-180 min";
        }
        else if (intensitet != "låg" || intensitet != "medel" || intensitet != "hög" || intensitet != "Låg" || intensitet != "Medel" || intensitet != "Hög")
        {
            txbPass.Text = "Fel intensitet. Ange antingen Låg, Medel, Hög";
        }
        else
        {
            // skriv sammanfattning
            txbPass.Text = $"{aktivitet} kommer att köras i {langdText} min med intensiteten {intensitet}.";
        }

    }

    List<string> listaPass = [];
    private void KlickSpara(object sender, RoutedEventArgs e)
    {
        string pass = txbAktivitet.Text;
        txbPass.Text = $"Passet {pass} är sparat!";

        listaPass.Add(pass);

    }

    private void KlickVisaPass(object sender, RoutedEventArgs e)
    {
        foreach (var pass in listaPass)
        {
            txbLista.Text += $"{pass}\n";
        }
    }
}
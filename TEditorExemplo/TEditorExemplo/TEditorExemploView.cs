using System;
using System.Threading.Tasks;
using TEditor;
using TEditor.Abstractions;
using Xamarin.Forms;

namespace TEditorExemplo
{
    public class TEditorExemploView : StackLayout
    {

        public string Html { get; set; }
        WebView _minhaWebView;
        public TEditorExemploView()
        {
            this.Orientation = StackOrientation.Vertical;
            this.Children.Add(new Button
            {
                Text = "Habilitar Editor Html",
                HeightRequest = 100,
                Command = new Command(async (obj) =>
                {
                    await ExibirTEditor();
                })
            });
            _minhaWebView = new WebView() { HeightRequest = 500 };
            this.Children.Add(_minhaWebView);
        }

        async Task ExibirTEditor()
        {
            TEditorResponse response = await CrossTEditor.Current.ShowTEditor("<p>Editor Html</p>");
            if (response.IsSave)
            {
                if (response.HTML != null)
                {
                    _minhaWebView.Source = new HtmlWebViewSource() { Html = response.HTML };
                }
            }
        }
    }

}

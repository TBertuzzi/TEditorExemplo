using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEditor;
using TEditor.Abstractions;
using Xamarin.Forms;

namespace TEditorExemplo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Task.Run(async () => 
            {
                TEditorResponse response = await CrossTEditor.Current.ShowTEditor("<p>Editor Html</p>");
                if (!string.IsNullOrEmpty(response.HTML))
                    wEditor.Source = new HtmlWebViewSource() { Html = response.HTML };

            }).Wait();

        }

     
	}
}

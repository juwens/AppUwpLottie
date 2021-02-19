using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppUwpLottie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly Dictionary<string, Uri> examples = new Dictionary<string, Uri>()
        {
            ["6596-countdown-2"] = new Uri("https://assets5.lottiefiles.com/packages/lf20_SkQZHu.json"),
            ["6595-countdown-1"] = new Uri("https://assets5.lottiefiles.com/packages/lf20_8YWSr5.json"),
            ["45-countdown"] = new Uri("https://assets5.lottiefiles.com/datafiles/pNpCU01WQ7qDWgK/data.json"),
            ["44014-countdown"] = new Uri("https://assets5.lottiefiles.com/packages/lf20_jzggnssm.json"),
            ["42000-countdown"] = new Uri("https://assets5.lottiefiles.com/packages/lf20_689pdhcy.json"),
            ["41999-countdown"] = new Uri("https://assets5.lottiefiles.com/packages/lf20_j7totias.json"),
            ["35589-countdown"] = new Uri("https://assets5.lottiefiles.com/packages/lf20_ptc6mday.json"),
        };

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size { Width = 800, Height = 400 };

            foreach (var key in examples.Keys) furtherExamples.Items.Add(key);
            furtherExamples.SelectionChanged += (_, a) =>
            {
                string animationId = furtherExamples.SelectedItem as string;
                lottieFurther.UriSource = examples[animationId];
                hlGotoLottieFiles.NavigateUri = new Uri($"https://lottiefiles.com/{animationId}");
            };
        }

        private void tbUri_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                tbError.Text = "";
                try
                {
                    lottieOnline.UriSource = new Uri(tbUri.Text);
                }
                catch (Exception ex)
                {
                    tbError.Text = ex.Message;
                }
            }
        }
    }
}

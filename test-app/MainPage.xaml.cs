using Leak.Client;
using Leak.Client.Swarm;
using Leak.Common;
using System;
using System.Diagnostics;
using System.Threading;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace test_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string[] trackers = {
            "udp://open.demonii.com:1337/announce",
            "udp://tracker.openbittorrent.com:80",
            "udp://tracker.coppersurfer.tk:6969",
            "udp://glotorrents.pw:6969/announce",
            "udp://tracker.opentrackr.org:1337/announce",
            "udp://torrent.gresille.org:80/announce",
            "udp://p4p.arenabg.com:1337",
            "udp://tracker.leechers-paradise.org:6969"
        };
        private FileHash hash = FileHash.Parse("EA17E6BE92962A403AC1C638D2537DCF1E564D26");
        private string destination = ApplicationData.Current.TemporaryFolder.Path;
        CancellationTokenSource cts;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cts = new CancellationTokenSource();
                await SwarmHelper.DownloadAsync(destination, hash, trackers, callback, cts.Token);
            }
            catch (OperationCanceledException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void callback(Notification s)
        {
            Debug.WriteLine(s);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cts.IsCancellationRequested) return;
            cts.Cancel();
            cts.Dispose();
        }
    }
}

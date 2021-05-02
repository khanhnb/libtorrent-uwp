using System.Threading.Tasks;
using Leak.Common;
using System.Diagnostics;
using System.Threading;

namespace Leak.Client.Swarm
{
    public static class SwarmHelper
    {
        public static void Download(string destination, FileHash hash, string[] trackers)
        {
            DownloadAsync(destination, hash, trackers, null, default(CancellationToken)).Wait();
        }

        public static void Download(string destination, FileHash hash, string[] trackers, NotificationCallback callback)
        {
            DownloadAsync(destination, hash, trackers, callback, default(CancellationToken)).Wait();
        }

        public static Task DownloadAsync(string destination, FileHash hash, string[] trackers)
        {
            return DownloadAsync(destination, hash, trackers, null, default(CancellationToken));
        }

        public static async Task DownloadAsync(string destination, FileHash hash, string[] trackers, NotificationCallback callback, CancellationToken token)
        {
            using (SwarmClient client = new SwarmClient())
            {
                Notification notification;
                SwarmSession session = await client.ConnectAsync(hash, trackers);

                session.Download(destination);

                while (true)
                {
                    if (token.CanBeCanceled) token.ThrowIfCancellationRequested();
                    notification = await session.NextAsync();
                    callback?.Invoke(notification);
                    if (notification.Type == NotificationType.DataCompleted)
                        break;
                }
            }
        }

        public static void Seed(string destination, FileHash hash, string tracker)
        {
            SeedAsync(destination, hash, tracker, null).Wait();
        }

        public static void Seed(string destination, FileHash hash, string tracker, NotificationCallback callback)
        {
            SeedAsync(destination, hash, tracker, callback).Wait();
        }

        public static Task SeedAsync(string destination, FileHash hash, string tracker)
        {
            return SeedAsync(destination, hash, tracker, null);
        }

        public static async Task SeedAsync(string destination, FileHash hash, string tracker, NotificationCallback callback)
        {
            using (SwarmClient client = new SwarmClient())
            {
                Notification notification;
                SwarmSession session = await client.ConnectAsync(hash, tracker);

                session.Seed(destination);

                while (true)
                {
                    notification = await session.NextAsync();
                    callback?.Invoke(notification);
                }
            }
        }
    }
}
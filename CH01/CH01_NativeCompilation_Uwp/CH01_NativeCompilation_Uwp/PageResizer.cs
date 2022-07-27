using System;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH01_NativeCompilation
{
    public class PageResizer
    {
        private readonly Page _page;
        private ThreadPoolTimer _threadPooTimer;
        private bool _hasBeenResized = false;

        public PageResizer(Page page)
        {
            _page = page;
            page.SizeChanged += Page_SizeChanged;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_threadPooTimer != null)
            {
                _threadPooTimer.Cancel();
                _threadPooTimer = null;
            }
            TimeSpan period = TimeSpan.FromSeconds(1.0);
            _threadPooTimer = ThreadPoolTimer.CreateTimer(async (source) =>
            {
                if (!_hasBeenResized)
                    await _page.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        if (!_hasBeenResized)
                        {
                            _hasBeenResized = true;
                            ApplicationView.GetForCurrentView().TryResizeView(e.NewSize);
                            _threadPooTimer.Cancel();
                        }
                    });
                else
                    _threadPooTimer.Cancel();
            }, period);
        }
    }
}
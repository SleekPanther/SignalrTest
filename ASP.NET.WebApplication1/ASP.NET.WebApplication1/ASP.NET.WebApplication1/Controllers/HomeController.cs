using Microsoft.AspNet.SignalR;
using SignalrMessenger;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASP.NET.WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalrHub>();
        private static bool syncing = false;
        public bool Syncing
        {
            get => syncing;
            set
            {
                if (syncing != value)
                {
                    syncing = value;
                    ViewBag.syncingStatus = syncing;
                    // Invoke the Send method on all connected clients
                    hubContext.Clients.All.SendMessage("Hello from the backend! " + Syncing);
                }
            }
        }

        public ActionResult Index()
        {
            new Timer(SyncFlightplanTestsTimerCallback, null, 500, 500);
            return View();
        }

        private void SyncFlightplanTestsTimerCallback(object state)
        {
            SyncFlightplanTests();
        }

        public void SyncFlightplanTests()
        {
            if (Syncing)
                return;

            Syncing = true;
            _ = Task.Run(() =>
            {
                Thread.Sleep(100);
            })
            .ContinueWith(delegate {
                Syncing = false;
            }).ConfigureAwait(false);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
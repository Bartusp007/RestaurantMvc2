using System;
using System.Web;
using System.Web.Mvc;
using RestaurantMvc.Model.Models;
using RestaurantMvc.Reservation.Service;
using RestaurantMvc.ViewModel.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RestaurantMvc.Web.Models;


namespace RestaurantMvc.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IServiceReservation _serviceReservation;
        protected IdentityModels.ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<IdentityModels.ApplicationUser> UserManager { get; set; }
        public ReservationController()
        {
            _serviceReservation = new ReservationService();
            this.ApplicationDbContext = new IdentityModels.ApplicationDbContext();
            this.UserManager = new UserManager<IdentityModels.ApplicationUser>(new UserStore<IdentityModels.ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Reservation
        public ActionResult Index()
        {
            ViewBag.Title = "Please make reservation:";

            var isLogged = (System.Web.HttpContext.Current.User != null) &&
                           System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (!isLogged) return View();
            IdentityModels.ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var reservationViewModel= new ReservationViewModel {Name = user.Name, Surname = user.Surname, Email = user.Email, PhoneNumber = user.PhoneNumber, ToWhatTime = new TimeSpan(23,0,0), FromWhatTime =  new TimeSpan(12,0,0),HowManyPeoples = 2};
            return View(reservationViewModel);
        }

        //POST:Reservation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReservationViewModel reservation)
        {
            if (!ModelState.IsValid) return View();

            //if (reservation.ToWhatTime<reservation.FromWhatTime || !ModelState.IsValid)
            //{
            //    ViewBag.TimeStage = ReservationTimeStage.IsNotvalid;
            //    return View();
            //}
            //else
            //{
            //    ViewBag.TimeStage = ReservationTimeStage.IsValid;
            //}


            var preReservation = new PreReservationViewModel
            {
                FromWhatTime = reservation.FromWhatTime,
                ToWhatTime = reservation.ToWhatTime,
                ReservationDate = reservation.ReservationDate,
                HowManyPeoples = reservation.HowManyPeoples
            };
            try
            {
                var checkPrereservation = _serviceReservation.CheckPreReservation(preReservation);
                if (checkPrereservation)
                {
                    reservation.UserId = User.Identity.GetUserId();
                    TempData["Message"]= "ok";
                    _serviceReservation.ReserveTable(reservation);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    reservation.Status = OutputMessage.NoFreeTables;
                    return View(reservation);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }



       


    }
}

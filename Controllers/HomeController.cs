using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Nominatim.API.Geocoders;
using System.Diagnostics;

namespace AiderHub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        private readonly OpenStreetMapService _openStreetMapService;

        public HomeController()
        {
            _openStreetMapService = new OpenStreetMapService();
        }

        public ActionResult Endereco (string address)
        {
            Coordinates coordinates = _openStreetMapService.GetCoordinates(address);

            if (coordinates != null)
            {
                // achou as coordenadas
                ViewBag.Latitude = coordinates.Latitude;
                ViewBag.Longitude = coordinates.Longitude;

                Debug.WriteLine(message: $"Latitude: {coordinates.Latitude}, Longitude: {coordinates.Longitude}");
            }
            else
            {
                // não achou / deu erro
                ViewBag.ErrorMessage = "Address not found.";
            }

            return View();
        }
    }
}
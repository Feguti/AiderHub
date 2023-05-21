using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Nominatim.API.Geocoders;
using System.Diagnostics;

using Microsoft.Office.Interop.Excel;

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

        [HttpPost]
        public ActionResult ExecutaMacro()
        {
            string caminho = Server.MapPath("~/Models/MacroCertificado.xlsm");

            Application xlApp = new Application();

            if (xlApp == null)
            {
                ViewBag.Mensagem = "Erro ao executar a macro: aplicativo Excel não encontrado.";
                return View("Relatorio");
            }

            Workbook xlWorkbook = xlApp.Workbooks.Open(caminho, ReadOnly: false);

            try
            {
                xlApp.Visible = false;
                xlApp.Run("GerarCertificado");
            }
            catch (System.Exception)
            {
                ViewBag.Mensagem = "Erro ao executar a macro.";
                return View("Relatorio");
            }

            xlWorkbook.Close(false);
            xlApp.Application.Quit();
            xlApp.Quit();


            ViewBag.Mensagem = "Arquivo gerado com sucesso!";
            return View("Relatorio");
        }

        public ActionResult Relatorio()
        {
            return View();
        }

    }
}
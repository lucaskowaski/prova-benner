using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microondas.Domain.ViewModels;
using ctrl = Microondas.Domain.Controller;
using Microsoft.AspNet.SignalR;
using Microondas.Hubs;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace Microondas.Controllers
{
    public class MicroondasController : Controller
    {
        JavaScriptSerializer _serialize = new JavaScriptSerializer();
        ctrl.MicoondasControler _microondasCtrl= new ctrl.MicoondasControler();
        ctrl.ProgramaController _programaCtrl = new ctrl.ProgramaController();
        // GET: Microondas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProgramasPadrao()
        {
            ViewBag.padroes = _programaCtrl.ObterProgramasPadrao();
            if (Session["programas"]  != null)
            {
                string teste = (string)Session["programas"];
                ViewBag.customizados = _serialize.Deserialize<List<ProgramaViewModel>>(teste);
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult Ligar(MicroondasViewModel microondas)
        {
            if (ModelState.IsValid)
            {
                microondas.ServerPath = Server.MapPath("~/Alimentos");
                var gotResult = false;
                ActionResult result = null;
                var cancellation = new CancellationTokenSource();
                CancellationToken ct = cancellation.Token;
                Task.Factory.StartNew(() =>
                {
                    result = Json(_microondasCtrl.Ligar(microondas, NotificarUsuario));
                    gotResult = true;
                }, ct);
                while (!gotResult)
                {
                    if (!Response.IsClientConnected)
                    {
                        cancellation.Cancel();
                        _microondasCtrl.Desligar();
                        return result;
                    }
                    Thread.Sleep(100);
                }
                return result;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
        }
        [HttpGet]
        public ActionResult Pesquisar(string term)
        {
            List<ProgramaViewModel> customizados = new List<ProgramaViewModel>();
            List<ProgramaViewModel> padroes = _programaCtrl.ObterProgramasPadrao();
            if (Session["programas"] != null)
            {
                customizados = _serialize.Deserialize<List<ProgramaViewModel>>((String)Session["programas"]);
            }
            if (term != "")
            {
                ViewBag.customizados = customizados.Where(c => c.Nome.Contains(term) || c.TipoAlimento.Contains(term)).ToList();
                ViewBag.padroes = padroes.Where(c => c.Nome.Contains(term) || c.TipoAlimento.Contains(term)).ToList();
            }
            else
            {
                ViewBag.customizados = customizados;
                ViewBag.padroes = padroes;
            }
            return PartialView("ProgramasPadrao");
        }
        private bool NotificarUsuario(int tempoPercorrido, string alimento)
        {
            ProgressHub.SendMessage(tempoPercorrido, alimento);
            return true;
        }
    }
}

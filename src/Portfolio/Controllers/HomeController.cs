using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers {
    public class HomeController : Controller {

        TasksRepository _tasksRepository = null;

        public HomeController() {
            _tasksRepository = new TasksRepository();
        }


        public ActionResult Index() {
            return View();
        }


        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }


        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        public ActionResult Portfolio() {

            ViewBag.Message = "Taski";
            var tasks = _tasksRepository.Tasks;
            return View(tasks);
        }


        public ActionResult Detail(int? id) {
            if (id == null)
                return HttpNotFound();

            ViewBag.Message = "Opis projektu";
            var task = _tasksRepository.GetTask((int)id);
            return View(task);
        }


        public ActionResult Image(int? id, string imageName) {
            if (id == null || imageName == null)
                return HttpNotFound();

            ImgOfProject img = new ImgOfProject();
            img.ImgName = imageName;
            img.ProjectId = (int)id;

            ViewBag.Message = "Zdjęcie";
            return View(img);
        }


        
    }
}

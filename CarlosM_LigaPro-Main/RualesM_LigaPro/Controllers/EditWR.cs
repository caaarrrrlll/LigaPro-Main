using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarlosM_LigaPro.Controllers
{
    public class EditWR : Controller
    {
        // GET: EditWR
        public ActionResult Index()
        {
            return View();
        }

        // GET: EditWR/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditWR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditWR/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EditWR/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EditWR/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EditWR/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditWR/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using Kunskapskontroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kunskapskontroll.Controllers
{
    public class PersonController : Controller
    {
        public static List<PersonViewModel> adressbook = new List<PersonViewModel>() {
             new PersonViewModel() { id = Guid.NewGuid(), Name = "Kalle Seed", Adress = "Seedgatan 1", PhoneNumber = "123456" },
             new PersonViewModel() { id = Guid.NewGuid(), Name = "Alice Seed", Adress = "Seedgatan 1", PhoneNumber = "123456" },
             new PersonViewModel() { id = Guid.NewGuid(), Name = "Lisa Seed", Adress = "Seedgatan 1", PhoneNumber = "123456" },
             new PersonViewModel() { id = Guid.NewGuid(), Name = "Bernt Seed", Adress = "Seedgatan 1", PhoneNumber = "123456" }
        };
        public ActionResult GetAll()
        {
            return PartialView("_DisplayAdressbook", adressbook);
        }

        public ActionResult Create()
        {
            var model = new PersonViewModel();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(PersonViewModel model)
        {
            model.id = Guid.NewGuid();
            model.Updated = DateTime.Now;
            adressbook.Add(model);
            return PartialView("_DisplayAdressbook", adressbook);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var postID = Guid.Parse(id);
            var postToRemove = adressbook.Find(x => x.id == postID);
            adressbook.Remove(postToRemove);
            return PartialView("_DisplayAdressbook", adressbook);
        }


        public ActionResult Edit(string id)
        {
            var userID = Guid.Parse(id);
            var postToEdit = adressbook.Find(x => x.id == userID);

            return PartialView(postToEdit);
        }

        [HttpPost]
        public ActionResult Edit(PersonViewModel model)
        {
            var userID = model.id;
            var personToEdit = adressbook.Find(x => x.id == userID);
            personToEdit.Name = model.Name;
            personToEdit.Adress = model.Name;
            personToEdit.PhoneNumber = model.PhoneNumber;

            return PartialView("_DisplayAdressbook", adressbook);
        }

    }
}
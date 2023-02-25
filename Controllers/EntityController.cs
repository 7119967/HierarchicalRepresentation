using HierarchicalRepresentation.DataAccess;
using HierarchicalRepresentation.Models;
using HierarchicalRepresentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HierarchicalRepresentation.Controllers
{
    public class EntityController : Controller
    {
        private readonly IStorage _storage;
        private readonly ILogger<EntityController> _logger;
        public EntityController(IStorage storage, ILogger<EntityController> logger)
        {
            _logger = logger;
            _storage = storage;
        }

        // GET: EntityController
        public ActionResult Index()
        {
            var model = _storage.EntityRepository.ListAllEntities();
            return View(model);
        }

        // GET: EntityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntityController/Create
        public ActionResult Create(int id)
        {
            CreateEntityViewModel model = new CreateEntityViewModel
            {
                Id = _storage.EntityRepository.GetNewId() + 1,
                ParentId = id
            };

            return Json(model);
        }

        // POST: EntityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEntityViewModel model)
        {
            try
            {
                if (model != null)
                {
                    Entity entity = new Entity()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Icon = model.Icon,
                        ParentId = model.ParentId,
                    };
                    _storage.EntityRepository.CreateNewEntity(entity);
                }
                var data = _storage.EntityRepository.ListAllEntities();
                return View("Index", data);
            }
            catch
            {
                return View();
            }
        }

        // GET: EntityController/Edit/5
        public ActionResult Edit(int id)
        {
            Entity? entity = _storage.EntityRepository.GetEntityById(id);
            return Json(entity);
        }
        
        // GET: EntityController/Preview/5
        public ActionResult Preview(int id)
        {
            Entity? entity = _storage.EntityRepository.GetEntityById(id);
            return Json(entity);
        }

        // POST: EntityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailsEntityViewModel model)
        {
            Entity entity = new Entity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Icon = model.Icon;
            entity.ParentId = model.ParentId;

            try
            {
                var ent = _storage.EntityRepository.GetEntityById(entity.Id);
                _storage.EntityRepository.RemoveEntity(ent);
                _storage.EntityRepository.CreateNewEntity(entity);
                var data = _storage.EntityRepository.ListAllEntities();
                return View("Index", data);
                //return RedirectToAction(nameof(Index));
                //return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EntityController/Delete/5
        public ActionResult Delete(int id)
        {
            _storage.EntityRepository.RemoveEntityById(id);
            var data = _storage.EntityRepository.ListAllEntities();
            return View("Index", data);
        }

        // POST: EntityController/Delete/5
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

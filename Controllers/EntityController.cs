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
        public ActionResult Create(int parentId)
        {
            CreateEntityViewModel model = new CreateEntityViewModel
            {
                Id = _storage.EntityRepository.GetNewId() + 1,
                ParentId = parentId
            };

            return View(model);
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
                        ParentId = model.ParentId,
                    };
                    _storage.EntityRepository.CreateNewEntity(entity);
                }
                return RedirectToAction(nameof(Index));
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
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Entity ent)
        {
            try
            {
                var entity = _storage.EntityRepository.GetEntityById(ent.Id);
                _storage.EntityRepository.RemoveEntity(entity);
                _storage.EntityRepository.CreateNewEntity(ent);
                return RedirectToAction(nameof(Index));
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
            return Ok();
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

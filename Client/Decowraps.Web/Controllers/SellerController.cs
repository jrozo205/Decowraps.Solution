using Decowraps.Web.Models;
using Decowraps.Web.Services.DTOs;
using Decowraps.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Decowraps.Web.Controllers
{
    public class SellerController : Controller
    {
        private ISellerService _sellerService;

        public SellerController(ISellerService sellerService) 
        {
            _sellerService = sellerService;
        }

        // GET: SellerController
        public async Task<ActionResult> Index()
        {
            var sellers =  await _sellerService.GetAllSellers();
            if(!sellers.Any()) return View();

            var list = sellers.Select(x=> new SellerViewModel(x)).ToList();
            return View(list);
        }

        // GET: SellerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var seller = await _sellerService.GetSellerById(id);
            return View(new SellerViewModel(seller));
        }

        // GET: SellerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellerController/Create
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SellerViewModel sellerViwModel)
        {
            try
            {
                var seller = await _sellerService.CreateSeller(sellerViwModel.ConvertToSellerDTO());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var seller = await _sellerService.GetSellerById(id);
            return View(new SellerViewModel(seller));
        }

        // POST: SellerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SellerViewModel sellerViwModel)
        {
            try
            {
                sellerViwModel.SellerId = id;
                var seller = await _sellerService.UpdateSeller(sellerViwModel.ConvertToSellerDTO());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var seller = await _sellerService.GetSellerById(id);
            return View(new SellerViewModel(seller));
        }

        // POST: SellerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var seller = await _sellerService.DeleteSeller(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

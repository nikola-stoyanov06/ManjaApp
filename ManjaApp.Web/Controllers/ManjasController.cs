using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManjaApp.Data.Data;
using ManjaApp.Data.Entities;
using Services.Abstractions;
using Services.DTOs;
using ManjaApp.Web.Models;
using ManjaApp.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ManjaApp.Web.Controllers
{
    
    public class ManjasController : Controller
    {
        private readonly IManjaService _manjaService;
        private readonly IWebHostEnvironment _environment;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public ManjasController(IManjaService manjaService, 
            IWebHostEnvironment environment, 
            ICategoryService categoryService,
            UserManager<AppUser> userManager)
        {
            _manjaService = manjaService;
            _environment = environment;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        // GET: Manjas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _manjaService.GetManjasAsync());
        }

        // GET: Manjas/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manja = await _manjaService.GetManjaByIdAsync(id.Value);
            if (manja == null)
            {
                return NotFound();
            }
            var model = new ManjaAddCommentDTO()
            {
                Id = manja.Id,
                Title = manja.Title,
				Duration = manja.Duration,
				Instructions = manja.Instructions,
				Picture = manja.Picture,
				Category = manja.Category,
                UserId = manja.UserId,
                Comments = manja.Comments,
                Comment = new CommentCreateEditDTO()
                {
                    UserId = (await _userManager.GetUserAsync(User)).Id
                }
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            ViewBag.Categories = categories;
            var user = await _userManager.GetUserAsync(User);
            var model = new ManjaCreateEditViewModel();
            model.UserId = user.Id;
            return View(model);
        }
        

        // POST: Manjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ManjaCreateEditViewModel manja)
        {
            if (ModelState.IsValid)
            { 
                manja.UserId = _userManager.GetUserId(User);
                if (manja.PictureUpload != null && manja.PictureUpload.Length > 0)
                {
                    var newName = await FileUpload.UploadAsync(manja.PictureUpload, _environment.WebRootPath);
                    manja.Picture = newName;
                }
                await _manjaService.AddManjaAsync(manja);
                return RedirectToAction("Details", "Categories", new { id = manja.CategoryId });
            }
            var categories = await _categoryService.GetCategoriesAsync();
            ViewBag.Categories = categories;
            return View(manja);
        }
        [Authorize]
        public async Task<IActionResult> AddComment()
        {
            return View();
        }

        // GET: Manjas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manja = await _manjaService.GetManjaByIdEditAsync(id.Value);
            if (manja == null)
            {
                return NotFound();
            }
            var categories = await _categoryService.GetCategoriesAsync(); 
            ViewBag.Categories = categories;
            var user = await _userManager.GetUserAsync(User);
            return View(new ManjaCreateEditViewModel()
            {
                Id = manja.Id,
                Title = manja.Title,
                Duration = manja.Duration,
                Instructions = manja.Instructions,
                Picture = manja.Picture,
                UserId = user.Id,
                CategoryId = manja.CategoryId
            });
        }

        // POST: Manjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, ManjaCreateEditViewModel manja)
        {
            if (id != manja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                manja.UserId = _userManager.GetUserId(User);
                if (manja.PictureUpload != null && manja.PictureUpload.Length > 0)
                {
                    var newName = await FileUpload.UploadAsync(manja.PictureUpload, _environment.WebRootPath);
                    manja.Picture = newName;
                }
                
                
                try
                {
                    await _manjaService.UpdateManjaAsync(manja);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ManjaExists(manja.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Manjas", new { id = manja.Id });
            }
            var categories = await _categoryService.GetCategoriesAsync();
            ViewBag.Categories = categories;
            return View(manja);
        }

        // GET: Manjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manja = await _manjaService.GetManjaByIdAsync(id.Value);
            if (manja == null)
            {
                return NotFound();
            }

            return View(manja);
        }

        // POST: Manjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var manja = await _manjaService.GetManjaByIdAsync(id);
            if (manja != null)
            {
                await _manjaService.DeleteManjaByIdAsync(id);
            }
            
            return RedirectToAction("Details", "Categories", new { id = manja.Category.Id });
        }

        private async Task<bool> ManjaExists(int id)
        {
            var manja = await _manjaService.GetManjaByIdAsync(id);
            return manja != null;
        }
    }
}

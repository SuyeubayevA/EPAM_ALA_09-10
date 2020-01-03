using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ALA_07_MVC_try3.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ALA_07_MVC_try3.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: Users
        //[Route("~/")]
        [Route("users")]
        [Route("users/index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        [Route("users/{id?}/{UserName?}")]
        public async Task<IActionResult> Details(string Name, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            UserDetailsViewModel viewModel = await GetUserDetailsViewModelFromUser(user);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("Details")]
        public async Task<IActionResult> Details([Bind("UserID,UserName,Title,Description")] UserDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Award award = new Award();

                award.Title = viewModel.Title;
                award.Description = viewModel.Description;

                User user = await _context.User
                    .FirstOrDefaultAsync(m => m.Id == viewModel.UserID);

                if (user == null)
                {
                    return NotFound();
                }

                award.MyUser = user;
                _context.Award.Add(award);
                await _context.SaveChangesAsync();

                viewModel = await GetUserDetailsViewModelFromUser(user);
            }

            return View(viewModel);
        }


        private async Task<UserDetailsViewModel> GetUserDetailsViewModelFromUser(User user)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel();

            viewModel.User = user;

            List<Award> awards = await _context.Award
                .Where(m => m.MyUser == user).ToListAsync();

            viewModel.Awards = awards;
            return viewModel;
        }

        // GET: Users/Create
        [Route("create-user")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Birthday,Age")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        [Route("user/{id?}/edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birthday,Age")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [Route("user/{id?}/delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}

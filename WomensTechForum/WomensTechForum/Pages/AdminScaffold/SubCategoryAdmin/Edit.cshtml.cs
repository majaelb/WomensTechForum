﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Data;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin.SubCategoryAdmin
{
    public class EditModel : PageModel
    {
        private readonly WomensTechForum.Data.ApplicationDbContext _context;

        public EditModel(WomensTechForum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubCategory SubCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubCategory == null)
            {
                return NotFound();
            }

            var subcategory =  await _context.SubCategory.FirstOrDefaultAsync(m => m.Id == id);
            if (subcategory == null)
            {
                return NotFound();
            }
            SubCategory = subcategory;
           ViewData["MainCategoryId"] = new SelectList(_context.MainCategory, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(SubCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubCategoryExists(int id)
        {
          return (_context.SubCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

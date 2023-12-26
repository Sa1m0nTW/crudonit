using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crudonit.Data;
using crudonit.Model;

namespace crudonit.Pages
{
    public class IndexModel : PageModel
    {
        private readonly crudonit.Data.crudonitContext _context;

        public IndexModel(crudonit.Data.crudonitContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Food != null)
            {
                Food = await _context.Food.ToListAsync();
            }
        }
    }
}

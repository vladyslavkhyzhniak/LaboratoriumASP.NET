using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Movies;

namespace WebApp.Controllers
{
    public class MovieCompanyController : Controller
    {
        private readonly MoviesContext _context;

        public MovieCompanyController(MoviesContext context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;  

            
            var totalCompanies = await _context.ProductionCompanies.CountAsync();

            
            int totalPages = (int)Math.Ceiling(totalCompanies / (double)pageSize);

           
            var companies = await _context.ProductionCompanies
                .OrderBy(company => company.CompanyId)  
                .Skip((page - 1) * pageSize)  
                .Take(pageSize)  
                .Select(company => new
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    MovieCount = _context.MovieCompanies.Count(mc => mc.CompanyId == company.CompanyId),
                    TotalBudget = _context.MovieCompanies
                        .Where(mc => mc.CompanyId == company.CompanyId)
                        .Join(_context.Movies, mc => mc.MovieId, m => m.MovieId, (mc, m) => m.Budget ?? 0)
                        .Sum(b => (long)b)
                })
                .ToListAsync();

            var viewModel = new
            {
                Companies = companies,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }
        
        public async Task<IActionResult> Movies(int companyId, int page = 1)
        {
            var company = await _context.ProductionCompanies.FindAsync(companyId);

            if (company == null)
            {
                return NotFound();
            }

            int pageSize = 10; 
            var totalMovies = await _context.MovieCompanies
                .Where(mc => mc.CompanyId == companyId)
                .CountAsync();

            int totalPages = (int)Math.Ceiling(totalMovies / (double)pageSize);

            var movies = await _context.MovieCompanies
                .Where(mc => mc.CompanyId == companyId)
                .Select(mc => new
                {
                    mc.Movie.MovieId,
                    mc.Movie.Title,
                    mc.Movie.Popularity,
                    mc.Movie.Revenue,
                    mc.Movie.Runtime,
                    mc.Movie.VoteAverage,
                    mc.Movie.VoteCount
                })
                .Skip((page - 1) * pageSize)  
                .Take(pageSize)  
                .ToListAsync();

            var viewModel = new
            {
                CompanyName = company.CompanyName,
                Movies = movies.Select(m => new
                {
                    m.MovieId,
                    m.Title,
                    m.Popularity,
                    m.Revenue,
                    m.Runtime,
                    m.VoteAverage,
                    m.VoteCount
                }).ToList(),
                CurrentPage = page,
                TotalPages = totalPages,
                CompanyId = companyId
            };

            return View(viewModel);
        }


  
    [HttpGet]
    public async Task<IActionResult> AddKeyword(int movieId)
    {

        var movie = await _context.Movies.FindAsync(movieId);
        if (movie == null)
        {
            return NotFound();
        }


        var keywords = await _context.MovieKeywords
            .Where(mk => mk.MovieId == movieId)
            .Select(mk => mk.Keyword.KeywordName)
            .ToListAsync();

 
        var viewModel = new 
        {
            MovieId = movieId,
            MovieTitle = movie.Title,
            CurrentKeywords = keywords
        };

        return View(viewModel);
    }


    [HttpPost]
    public async Task<IActionResult> AddKeyword(int movieId, string keyword)
    {
        var movie = await _context.Movies.FindAsync(movieId);
        if (movie == null)
        {
            return NotFound();
        }


        var existingKeyword = await _context.Keywords
            .FirstOrDefaultAsync(k => k.KeywordName == keyword);
    
        if (existingKeyword == null)
        {

            existingKeyword = new Keyword { KeywordName = keyword };
            _context.Keywords.Add(existingKeyword);
            await _context.SaveChangesAsync();
        }


        await _context.Database.ExecuteSqlRawAsync(
            "INSERT INTO movie_keywords (movie_id, keyword_id) VALUES ({0}, {1})", 
            movieId, 
            existingKeyword.KeywordId
        );

  
        return RedirectToAction("AddKeyword", new { movieId = movieId});
    }
        
    }
}
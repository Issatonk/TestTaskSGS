using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskSGS.Core;
using TestTaskSGS.Models;

namespace TestTaskSGS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;
        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [Route("currencies/{page}")]
        public async Task<IActionResult> Сurrencies(int page = 1, int pagesize = 10)
        {
            
            var result = await _repository.Get();
            
            if (result == null || result.Valute == null)
            {
                return RedirectToAction(nameof(Error));
            }

            var totalPages = Pager.GetTotalPages(result.Valute.Count, pagesize);

            if (page <= 0 || page > totalPages)
            {
                return RedirectToAction(nameof(Сurrencies), new {page = 1, pagesize});
            }

            result = result.PaginationMethod(page, pagesize);
            var currencies = new CurrenciesViewModel(result.Date, result.Timestamp, result.Valute, totalPages, page, pagesize);
            
            return View(currencies);
        }

        [Route("currency/")]
        public async Task<IActionResult> CurrencyAsync(string search, SearchParameter searchParameter = SearchParameter.SearchById)
        {
            var result = await _repository.Get();

            if (result == null || result.Valute == null)
            {
                return RedirectToAction(nameof(Error));
            }

            var valute = result.Valute.Search(search, searchParameter);

            if(valute == null)
            {
                return RedirectToAction(nameof(Error));
            }

            var viewModel = new CurrencyViewModel(result.Date, result.Timestamp, valute);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
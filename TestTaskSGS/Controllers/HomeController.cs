using Microsoft.AspNetCore.Mvc;
using Sentry;
using System.Diagnostics;
using TestTaskSGS.Core;
using TestTaskSGS.Models;

namespace TestTaskSGS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private readonly IHub _sentryHub;
        public HomeController(IRepository repository, IHub sentryHub)
        {
            _repository = repository;
            _sentryHub = sentryHub;
        }

        [Route("currencies/{page}")]
        public async Task<IActionResult> Сurrencies(CancellationToken token, int page = 1, int pagesize = 10)
        {
            var childSpan = _sentryHub.GetSpan()?.StartChild("GetCurrenciesPage");
            try
            {
                var result = await _repository.Get(token);
                if (result == null || result.Valute == null)
                {
                    throw new BadHttpRequestException("currency rates not found");
                }

                var totalPages = Pager.GetTotalPages(result.Valute.Count, pagesize);

                if (page <= 0 || page > totalPages)
                {
                    return RedirectToAction(nameof(Сurrencies), new { page = 1, pagesize });
                }

                result = result.PaginationMethod(page, pagesize);
                var currencies = new CurrenciesViewModel(result.Date, result.Timestamp, result.Valute, totalPages, page, pagesize);

                childSpan?.Finish(SpanStatus.Ok);
                return View(currencies);
            }
            catch(Exception ex)
            {
                childSpan?.Finish(ex);
                throw;
            }
        }

        [Route("currency/")]
        public async Task<IActionResult> CurrencyAsync(string search, CancellationToken token, SearchParameter searchParameter = SearchParameter.SearchById)
        {
            var childSpan = _sentryHub.GetSpan()?.StartChild("GetCurrency");
            try
            {
                var result = await _repository.Get(token);

                if (result == null || result.Valute == null)
                {
                    throw new BadHttpRequestException("currency rates not found");
                }

                var valute = result.Valute.Search(search, searchParameter);

                var viewModel = new CurrencyViewModel(result.Date, result.Timestamp, valute);
                childSpan?.Finish(SpanStatus.Ok);
                return View(viewModel);
            }
            catch(Exception ex)
            {
                childSpan.Finish(ex);
                throw;
            }
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
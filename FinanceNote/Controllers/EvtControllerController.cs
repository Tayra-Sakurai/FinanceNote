using FinanceNote.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FinanceNote.Controllers
{
    public class EvtControllerController : Controller
    {
        private readonly FinanceNoteContext _context;

        public EvtControllerController(FinanceNoteContext context)
        {
            _context = context;
        }

        public async Task Index()
        {
            Response.ContentType = "text/event-stream";
            Response.Headers.TryAdd("Cache-Control", "no-cache");
            Response.Headers.TryAdd("X-Accel-Buffering", "no");

            Response.StatusCode = 200;

            DbSet<FinanceNote.Models.Requests> requests = _context.Requests;

            try
            {
                while (requests != null)
                {
                    if (_context.Requests != requests)
                    {
                        requests = _context.Requests;
                        string message = "data: リクエストがあります．\n\n";
                        await Response.WriteAsync(message);

                        await Task.Delay(1000, HttpContext.RequestAborted);
                    }
                }
                Response.StatusCode = 418;
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
            }
        }
    }
}

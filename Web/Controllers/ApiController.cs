using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IPostServices _post;
        private readonly IProductServices _product;
        private readonly ICommonServices _common;
        public ApiController(IPostServices post, IProductServices product, ICommonServices common)
        {
            this._common = common;
            this._product = product;
            this._post = post;
        }
        [HttpGet]
        [Route("/api/searchpost")]
        public async Task<ActionResult<List<string>>> SearchPost(string term)
        {
            try
            {
                return await _post.GetSearchTitle(term);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
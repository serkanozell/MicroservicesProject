using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {

        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance(response: Response<NoContent>.Success(200));
        }
    }
}

using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuberDinner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    [ApiController]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        public MenusController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(
            [FromBody] CreateMenuRequest request,
            [FromRoute] string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var createdMenuResult = await _mediator.Send(command);

            return createdMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemAcademy.Business.Operations.Setting;

namespace RemAcademy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToogleMaintenence()
        {
            await _settingService.ToogleMaintenence();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Sras.PublicCoreflow.ConferenceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp;
using Sras.PublicCoreflow.Dto;

namespace Sras.PublicCoreflow.Controllers.ConferenceManagement
{
    [RemoteService(Name = "Sras")]
    [Area("sras")]
    [ControllerName("Outsider")]
    [Route("api/sras/outsider")]
    public class OutsiderController : AbpController
    {
        private readonly IOutsiderAppService _outsiderService;

        public OutsiderController(IOutsiderAppService outsiderService)
        {
            _outsiderService = outsiderService;
        }

        [HttpPost]
        public async Task<ActionResult<OutsiderCreateResponse>> CreateAsync(OutsiderCreateRequest request)
        {
            try
            {
                var result = await _outsiderService.CreateOutsider(request);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

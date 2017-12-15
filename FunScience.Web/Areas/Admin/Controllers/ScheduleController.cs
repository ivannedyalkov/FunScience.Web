namespace FunScience.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using FunScience.Service;
    using FunScience.Service.Admin;
    using FunScience.Web.Areas.Admin.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ScheduleController : AdminBaseController
    {
        private readonly IScheduleService scheduleService;
        private readonly IMapper mapper;

        public ScheduleController(
            IScheduleService scheduleService,
             IMapper mapper)
        {
            this.scheduleService = scheduleService;
            this.mapper = mapper;
        }

        public IActionResult CreateSchedule()
        {
            var result = this.scheduleService.GetSchedule();

            var performanceView = mapper.Map<PerformanceViewModel>(result);

            return View(performanceView);
        }
    }
}

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

        [HttpPost]
        public IActionResult CreateSchedule(PerformanceViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var result = this.scheduleService.GetSchedule();

                var performanceView = mapper.Map<PerformanceViewModel>(result);

                return View(nameof(CreateSchedule), performanceView);
            }

            var create = this.scheduleService.CreateSchedule(model.Time, model.Play, model.School, model.SelectedUsers);

            if (!create)
            {
                var result = this.scheduleService.GetSchedule();

                var performanceView = mapper.Map<PerformanceViewModel>(result);

                performanceView.StatusMessage = $"ErrorГрешка. Моля преверете дали служителят не записан в друго предтавление по това време.";

                return View(nameof(CreateSchedule), performanceView);
            }

            return Redirect(nameof(CreateSchedule));
        }

        public IActionResult Schedule()
        {
            var schedule = this.scheduleService.Schedule();

            return View(schedule);
        }
    }
}

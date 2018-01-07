namespace FunScience.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using FunScience.Service;
    using FunScience.Service.Admin.Models.Schedule;
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

                performanceView.StatusMessage = $"ErrorГрешка. Моля преверете датата.";

                return View(nameof(CreateSchedule), performanceView);
            }

            return Redirect(nameof(CreateSchedule));
        }

        public IActionResult Schedule()
        {
            var schedule = this.scheduleService.Schedule();

            return View(schedule);
        }

        public IActionResult Edit(int id)
        {
            var performance = this.scheduleService.PerformanceInfo(id);

            if (performance == null)
            {
                return BadRequest();
            }

            var performanceView = mapper.Map<PerformanceEditViewModel>(performance);

            performanceView.StatusMessage = StatusMessage;

            return View(performanceView);
        }

        [HttpPost]
        public IActionResult Edit(PerformanceEditViewModel model)
        {
            var performance = this.scheduleService.PerformanceInfo(model.Id);

            if (!ModelState.IsValid)
            {

                return View(nameof(Edit), performance.Id);
            }


            var result = this.scheduleService.Edit(
                                    model.Id,
                                    model.Time,
                                    model.Play,
                                    model.School,
                                    model.SelectedUsers);
            
            if (result)
            {

                return RedirectToAction(nameof(Schedule));
            }
            
            StatusMessage = $"ErrorГрешка. Моля преверете датата.";

            return RedirectToAction(nameof(Edit), performance.Id);
        }

        public IActionResult Delete(int id)
        {
            var model = this.scheduleService.DeleteInfo(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Destroy(ScheduleListingModel model)
        {
            this.scheduleService.Delete(model.Id);

            return RedirectToAction(nameof(Schedule));
        }
    }
}

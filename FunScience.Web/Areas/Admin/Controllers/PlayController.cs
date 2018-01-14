namespace FunScience.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using FunScience.Service.Admin;
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Web.Areas.Admin.Models;
    using FunScience.Web.Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    public class PlayController : AdminBaseController
    {
        private readonly IPlayService playService;
        private readonly IMapper mapper;

        public PlayController(
            IPlayService playService,
             IMapper mapper)
        {
            this.playService = playService;
            this.mapper = mapper;
        }

        public IActionResult CreatePlay()
        {
            return View(new PlayViewModel { });
        }

        [HttpPost]
        public IActionResult CreatePlay(PlayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CreatePlay), model);
            }

            var result = this.playService.AddPlay(model.Name);

            if (result)
            {
                return Redirect(nameof(Plays));
            }

            model.StatusMessage = MessageConstants.PlayWithSameNameExist;

            return View(nameof(CreatePlay), model);
        }

        public IActionResult Plays()
        {
            var plays = this.playService.ListOfPlays();

            return View(plays);
        }

        public IActionResult Edit(int id)
        {
            var play = this.playService.PlayInfo(id);

            if (play == null)
            {
                return BadRequest();
            }

            var playView = mapper.Map<PlayViewModel>(play);

            playView.StatusMessage = StatusMessage;

            return View(playView);
        }

        [HttpPost]
        public IActionResult Edit(PlayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model.Id);
            }

            var result = this.playService.Edit(
                                    model.Id,
                                    model.Name);
            if (result)
            {
                StatusMessage = MessageConstants.PlayWasChanged;

                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = this.playService.PlayInfo(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Destroy(PlayListingModel model)
        {
            this.playService.Delete(model.Id);

            return RedirectToAction(nameof(Plays));
        }
    }
}

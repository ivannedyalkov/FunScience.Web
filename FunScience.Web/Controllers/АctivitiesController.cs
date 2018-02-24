namespace FunScience.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    public class АctivitiesController : Controller
    {
        [Route("/activities/festiveperformances")]
        public IActionResult FestivePerformances()
        {
            return View();
        }

        [Route("/activities/testshow")]
        public IActionResult TestShow()
        {
            return View();
        }

        [Route("/activities/dramalessons")]
        public IActionResult DramaLessons()
        {
            return View();
        }

        [Route("/activities/theaterschool")]
        public IActionResult TheaterSchool()
        {
            return View();
        }

        [Route("/activities/foreignlanguagedramatraining")]
        public IActionResult ForeignLanguageDramaTraining()
        {
            return View();
        }

        [Route("/activities/trainingforstudents")]
        public IActionResult TrainingForStudents()
        {
            return View();
        }

        [Route("/activities/teachertraining")]
        public IActionResult TeacherTraining()
        {
            return View();
        }

        [Route("/activities/privateparty")]
        public IActionResult PrivateParty()
        {
            return View();
        }
    }
}

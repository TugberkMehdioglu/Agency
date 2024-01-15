using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Creater.CreatorViewModel;

namespace Project.MVCUI.Areas.Analyzer.Controllers
{
    [Area("Analyzer")]
    [Route("[Area]/[Controller]/[Action]")]
    [Authorize(Roles = "Analyzer")]
    public class AnalyzeController : Controller
    {
        private readonly IQuestionManager _questionManager;
        private readonly IMapper _mapper;
        private readonly IGroupManager _groupManager;

        public AnalyzeController(IQuestionManager questionManager, IMapper mapper, IGroupManager groupManager)
        {
            _questionManager = questionManager;
            _mapper = mapper;
            _groupManager = groupManager;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Group> groups = await _groupManager.GetGroupsWithQuestions();
            List<Group> result = await groups.ToListAsync();

            List<GroupViewModel> groupViewModels = _mapper.Map<List<GroupViewModel>>(result);
            ViewBag.GroupCodes = result.Select(x => x.Code).ToArray();
            ViewBag.GroupCodeCount = result.Select(x => x.Questions.Count).ToArray();

            return View(groupViewModels);
        }
    }
}

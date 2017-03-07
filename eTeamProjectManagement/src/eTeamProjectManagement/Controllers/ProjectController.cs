using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using eTeamProjectManagement.Models;
using eTeamProjectManagement.Services;
using Microsoft.AspNetCore.Authorization;
using eTeamProjectManagement.Models.ProjectViewModels;
using eTeamProjectManagement.Entities;

namespace eTeamProjectManagement.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IProjectServ _project;

        public ProjectController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager, 
                                IProjectServ projectData)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _project = projectData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YourProjects()
        {          
            var model_projects = _project.GetUserProjects(_userManager.GetUserName(User));
            var model_projecttypes = _project.GetAllProjectTypes();
            var model_teams = _project.GetAllUserTeams();

            var model = new GroupProjectViewModel { Projects = model_projects, ProjectTypes = model_projecttypes, AllTeams = model_teams  };
            return View(model);
        }

        public async Task<IActionResult> TeamProjects()
        {
            var user = await _userManager.GetUserAsync(User);
            int team = user.TeamID;

            var model_projects = _project.GetTeamProjects(team);
            var model_projecttypes = _project.GetAllProjectTypes();
            var model_teams = _project.GetAllUserTeams();

            var model = new GroupProjectViewModel { Projects = model_projects, ProjectTypes = model_projecttypes, AllTeams = model_teams };
            return View(model);
        }

        public IActionResult ViewProject(int Id)
        {
            var model_project = _project.GetProjectData(Id);
            if (model_project == null)
            {
                //need to add logic to return to the previous view here or a page that indicates this was not accessible
                return RedirectToAction(nameof(Index));
            }
            var model_teamprojectupdates = _project.GetTeamProjectUpdates(Id);
            var model_itprojectupdates = _project.GetITProjectUpdates(Id);

            var model_projectcontacts = _project.GetProjectContacts(Id);
            var model_selectliststatus = _project.GetAllStatus();
            var model_allpriorities = _project.GetAllPriorities();
            var model_allprojecttypes = _project.GetAllProjectTypes();
            var model_allprojectupdatepartys = _project.GetAllProjectUpdateParties();
            var model_allprojectupdatetypes = _project.GetAllProjectUpdateTypes();
            var model_teams = _project.GetAllUserTeams();


            var model = new SingleProjectViewModel { ProjectData = model_project,
                                                    ProjectContacts = model_projectcontacts,
                                                    ProjectITUpdates = model_itprojectupdates,
                                                    ProjectTeamUpdates = model_teamprojectupdates,
                                                    AllStatus = model_selectliststatus,
                                                    AllPriorities = model_allpriorities,
                                                    AllProjectTypes = model_allprojecttypes,
                                                    AllUpdateParties = model_allprojectupdatepartys,
                                                    AllUpdateTypes = model_allprojectupdatetypes,
                                                    AllTeams = model_teams};
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            var model_selectliststatus = _project.GetAllStatus();
            var model_allpriorities = _project.GetAllPriorities();
            var model_allprojecttypes = _project.GetAllProjectTypes();
            var model_teams = _project.GetAllUserTeams();

            var user = await _userManager.GetUserAsync(User);
            int team = user.TeamID;

            var model = new BaseProjectEditCreateViewModel { AllStatus = model_selectliststatus,
                                                            AllProjectTypes = model_allprojecttypes,
                                                            AllPriorities = model_allpriorities,
                                                            AllTeams = model_teams,
                                                            BeginDate = DateTime.Now,
                                                            AssignedTeam = team,
                                                            ProjectOwner = _userManager.GetUserName(User)};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProject(BaseProjectEditCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newProject = new ProjectData();
                newProject.AssignedTeam = model.AssignedTeam;
                newProject.BeginDate = model.BeginDate;
                newProject.BillToClientNumber = model.BillToClientNumber;
                newProject.ClientName = model.ClientName;
                newProject.ClientNumber = model.ClientNumber;
                newProject.Cst = model.Cst;
                newProject.Description = model.Description;
                newProject.PriorityId = model.Priority;
                newProject.ProjectOwner = model.ProjectOwner;
                newProject.ProjectTypeId = model.ProjectType;
                newProject.StatusId = model.Status;
                newProject.isActive = true;

                newProject = _project.AddProjectData(newProject);
                _project.commit();

                var newTeamNote = new ProjectTeamUpdate();
                newTeamNote.InitialUpdate = newProject.BeginDate;
                newTeamNote.LastModified = newProject.BeginDate;
                newTeamNote.ProjectId = newProject.Id;
                newTeamNote.UpdateTypeId = 1;
                newTeamNote.UpdateFromId = 1;
                newTeamNote.ProjectUpdateId = 1;
                newTeamNote.Description = "Project Start";
                newTeamNote.UpdatedBy = _userManager.GetUserName(User);

                newTeamNote = _project.AddTeamProjectUpdate(newTeamNote);
                _project.commit();

                var newITNote = new ProjectITUpdate();
                newITNote.InitialUpdate = newProject.BeginDate;
                newITNote.LastModified = newProject.BeginDate;
                newITNote.ProjectId = newProject.Id;
                newITNote.ProjectITUpdateId = 1;
                newITNote.UpdateFromId = 1;
                newITNote.UpdateTypeId = 1;
                newITNote.Description = "Project Start";
                newITNote.UpdatedBy = _userManager.GetUserName(User);

                newITNote = _project.AddITProjectUpdate(newITNote);
                _project.commit();

                return RedirectToAction("ViewProject", new { Id = newProject.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditProject(int id)
        {
            var viewModel = new EditProjectViewModel();
            var getProject = _project.GetProjectData(id);
            viewModel.Id = getProject.Id;
            viewModel.AssignedTeam = getProject.AssignedTeam;
            viewModel.BeginDate = getProject.BeginDate;
            viewModel.BillToClientNumber = getProject.BillToClientNumber;
            viewModel.ClientName = getProject.ClientName;
            viewModel.ClientNumber = getProject.ClientNumber;
            viewModel.Cst = getProject.Cst;
            viewModel.Description = getProject.Description;
            viewModel.Priority = getProject.PriorityId;
            viewModel.ProjectOwner = getProject.ProjectOwner;
            viewModel.ProjectType = getProject.ProjectTypeId;
            viewModel.Status = getProject.StatusId;
            viewModel.AllTeams = _project.GetAllUserTeams();
            viewModel.AllPriorities = _project.GetAllPriorities();
            viewModel.AllProjectTypes = _project.GetAllProjectTypes();
            viewModel.AllStatus = _project.GetAllStatus();          

            return PartialView("_EditProjectPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProject(EditProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var toUpdate = _project.GetProjectData(viewModel.Id);
                toUpdate.AssignedTeam = viewModel.AssignedTeam;
                toUpdate.BeginDate = viewModel.BeginDate;
                toUpdate.BillToClientNumber = viewModel.BillToClientNumber;
                toUpdate.ClientName = viewModel.ClientName;
                toUpdate.ClientNumber = viewModel.ClientNumber;
                toUpdate.Cst = viewModel.Cst;
                toUpdate.Description = viewModel.Description;
                toUpdate.PriorityId = viewModel.Priority;
                toUpdate.ProjectOwner = viewModel.ProjectOwner;
                toUpdate.ProjectTypeId = viewModel.ProjectType;
                toUpdate.StatusId = viewModel.Status;
                _project.commit();

                return RedirectToAction("ViewProject", new { Id = toUpdate.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewUpdatesOverview(int id)
        {
            var model_mostRecentTeamUpdate = _project.GetTeamProjectUpdates(id);
            var mostrecentTeam = model_mostRecentTeamUpdate.OrderByDescending(r => r.InitialUpdate).FirstOrDefault();
            var model_mostRecentITUpdate = _project.GetITProjectUpdates(id);
            var mostrecentIT = model_mostRecentITUpdate.OrderByDescending(r => r.InitialUpdate).FirstOrDefault();

            var viewModel = new OverviewUpdateViewModel { teamUpdate = mostrecentTeam, ITUpdate = mostrecentIT };
            return PartialView("_UpdateOverview", viewModel);
        }

        public IActionResult FindProject()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditContact(int projectId, int contactId)
        {
            var viewModel = new ProjectContactViewModel();
            var getContact = _project.GetProjectContact(contactId, projectId);
            viewModel.Contact = getContact;
            viewModel.CurrentRun = 0;
         
            return PartialView("_EditContactPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditContact(ProjectContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var toUpdate = _project.GetProjectContact(viewModel.Contact.ProjectContactId, viewModel.Contact.ProjectId);
                toUpdate.ContactEmail = viewModel.Contact.ContactEmail;
                toUpdate.ContactName = viewModel.Contact.ContactName;
                toUpdate.ContactNote = viewModel.Contact.ContactNote;
                toUpdate.ContactPhone = viewModel.Contact.ContactPhone;
                toUpdate.ContactRole = viewModel.Contact.ContactRole;
                toUpdate.ContactTimeZone = viewModel.Contact.ContactTimeZone;
                _project.commit();

                return RedirectToAction("ViewProject", new { Id = toUpdate.ProjectId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateContact(int ProjectId)
        {
            var model_projectcontact = new ProjectContactData();
            model_projectcontact.ProjectId = ProjectId;
            model_projectcontact.ProjectContactId = 0;
            ;

            return PartialView("_CreateContactPartial", model_projectcontact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(ProjectContactData contact)
        {
            if (ModelState.IsValid)
            {
                var highestContactID = 0;

                var model_hascontacts = _project.GetProjectContacts(contact.ProjectId);
                if(model_hascontacts.Any())
                {
                    var model_projectcontacts = _project.GetProjectContacts(contact.ProjectId).OrderByDescending(a => a.ProjectContactId).First();
                    highestContactID = model_projectcontacts.ProjectContactId;
                }                

                var newContact = new ProjectContactData();
                newContact.ContactEmail = contact.ContactEmail;
                newContact.ContactName = contact.ContactName;
                newContact.ContactNote = contact.ContactNote;
                newContact.ContactPhone = contact.ContactPhone;
                newContact.ContactRole = contact.ContactRole;
                newContact.ContactTimeZone = contact.ContactTimeZone;                
                newContact.ProjectId = contact.ProjectId;
                newContact.ProjectContactId = highestContactID + 1;

                _project.AddProjectContact(newContact);
                _project.commit();

                return RedirectToAction("ViewProject", new { Id = contact.ProjectId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteContact(int projectId, int contactId)
        {
            var getContact = _project.GetProjectContact(contactId, projectId);

            return PartialView("_DeleteContactPartial", getContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(ProjectContactData contact)
        {
            var projectId = contact.ProjectId;
            _project.DeleteProjectContact(contact);
            //_project.commit();

            return RedirectToAction("ViewProject", new { Id = projectId });
        }
    }
}
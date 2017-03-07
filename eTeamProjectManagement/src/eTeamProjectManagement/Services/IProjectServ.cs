 using eTeamProjectManagement.Data;
using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Services
{
    public interface IProjectServ
    {
        ProjectData AddProjectData(ProjectData newProject);
        ProjectData GetProjectData(int id);

        IEnumerable<ProjectStatuses> GetAllStatus();
        IEnumerable<ProjectPriorities> GetAllPriorities();
        IEnumerable<ProjectTypes> GetAllProjectTypes();
        IEnumerable<ProjectUpdatePartys> GetAllProjectUpdateParties();
        IEnumerable<ProjectUpdateTypes> GetAllProjectUpdateTypes();
        IEnumerable<UserTeams> GetAllUserTeams();

        IEnumerable<ProjectData> GetAll();
        IEnumerable<ProjectData> GetUserProjects(string username);
        IEnumerable<ProjectData> GetTeamProjects(int assignedTeam);

        ProjectTeamUpdate AddTeamProjectUpdate(ProjectTeamUpdate newTeamUpdate);
        IEnumerable<ProjectTeamUpdate> GetTeamProjectUpdates(int projectId);

        ProjectITUpdate AddITProjectUpdate(ProjectITUpdate newITUpdate);
        IEnumerable<ProjectITUpdate> GetITProjectUpdates(int projectId);

        ProjectContactData AddProjectContact(ProjectContactData newContact);
        ProjectContactData GetProjectContact(int contactId, int projectId);
        IEnumerable<ProjectContactData> GetProjectContacts(int projectId);
        ProjectContactData DeleteProjectContact(ProjectContactData contact);

        void commit();
    }
    public class SqlProject : IProjectServ
    {
        private ApplicationDbContext _context;

        public SqlProject(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectStatuses> GetAllStatus()
        {
            return _context.ProjectStatuses;
        }

        public IEnumerable<ProjectPriorities> GetAllPriorities()
        {
            return _context.ProjectPriorities;
        }

        public IEnumerable<ProjectTypes> GetAllProjectTypes()
        {
            return _context.ProjectTypes;
        }

        public IEnumerable<ProjectUpdatePartys> GetAllProjectUpdateParties()
        {
            return _context.ProjectUpdatePartys;
        }

        public IEnumerable<ProjectUpdateTypes> GetAllProjectUpdateTypes()
        {
            return _context.ProjectUpdateTypes;
        }

        public IEnumerable<UserTeams> GetAllUserTeams()
        {
            return _context.UserTeams;
        }

        public ProjectData AddProjectData(ProjectData newProject)
        {
            _context.Add(newProject);
            return newProject;
        }

        public ProjectData GetProjectData(int id)
        {
            return _context.ProjectData.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<ProjectData> GetAll()
        {
            return _context.ProjectData;
        }
            
        public IEnumerable<ProjectData> GetTeamProjects(int assignedTeam)
        {
            return _context.ProjectData.Where(r => r.AssignedTeam == assignedTeam);
        }

        public IEnumerable<ProjectData> GetUserProjects(string username)
        {
            return _context.ProjectData.Where(r => r.ProjectOwner == username);
        }

        public ProjectTeamUpdate AddTeamProjectUpdate(ProjectTeamUpdate newTeamUpdate)
        {
            _context.Add(newTeamUpdate);
            return newTeamUpdate;
        }

        public IEnumerable<ProjectTeamUpdate> GetTeamProjectUpdates(int projectId)
        {
            return _context.ProjectTeamUpdates.Where(r => r.ProjectId == projectId);
        }

        public ProjectITUpdate AddITProjectUpdate(ProjectITUpdate newITUpdate)
        {
            _context.Add(newITUpdate);
            return newITUpdate;
        }

        public IEnumerable<ProjectITUpdate> GetITProjectUpdates(int projectId)
        {
            return _context.ProjectITUpdates.Where(r => r.ProjectId == projectId);
        }

        public ProjectContactData AddProjectContact(ProjectContactData newContact)
        {
            _context.Add(newContact);
            return newContact;
        }

        public ProjectContactData GetProjectContact(int contactId, int projectId)
        {
            return _context.ProjectContactData.Where(r => r.ProjectId == projectId && r.ProjectContactId == contactId).FirstOrDefault();
        }

        public IEnumerable<ProjectContactData> GetProjectContacts(int projectId)
        {
            return _context.ProjectContactData.Where(r => r.ProjectId == projectId);
        }

        public void commit()
        {
            _context.SaveChanges();
        }

        public ProjectContactData DeleteProjectContact(ProjectContactData contact)
        {
            var getContact = _context.ProjectContactData.Where(r => r.ProjectId == contact.ProjectId && r.ProjectContactId == contact.ProjectContactId).FirstOrDefault();
            _context.Remove(getContact);
            _context.SaveChanges();
            return contact;
        }
    }
}

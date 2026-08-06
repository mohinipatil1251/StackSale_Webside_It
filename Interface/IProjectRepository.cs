using IT_Company_web.Models;

namespace IT_Company_web.Interface
{
    
    
        public interface IProjectRepository
        {
            List<Project> GetAll();

            Project? GetById(int id);

            void Add(Project project);

            void Update(Project project);

            void Delete(int id);

            void Save();
        }
    }



using IT_Company_web.Models;

namespace IT_Company_web.Interface
{
    public interface IServiceRepository
    {
        
        
            List<Service> GetAll();

            Service? GetById(int id);

            void Add(Service service);

            void Update(Service service);

            void Delete(int id);

            void Save();
        }
    }



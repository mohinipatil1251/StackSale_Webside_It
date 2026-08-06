using IT_Company_web.Data;
using IT_Company_web.Interface;
using IT_Company_web.Models;

namespace IT_Company_web.Repository
{
  
    
  

    
        public class ServiceRepository : IServiceRepository
        {
            private readonly ApplicationDbContext _context;

            public ServiceRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public List<Service> GetAll()
            {
                return _context.Services.ToList();
            }

            public Service? GetById(int id)
            {
                return _context.Services.Find(id);
            }

            public void Add(Service service)
            {
                _context.Services.Add(service);
            }

            public void Update(Service service)
            {
                _context.Services.Update(service);
            }

            public void Delete(int id)
            {
                var service = _context.Services.Find(id);

                if (service != null)
                {
                    _context.Services.Remove(service);
                }
            }

            public void Save()
            {
                _context.SaveChanges();
            }
        }
    }



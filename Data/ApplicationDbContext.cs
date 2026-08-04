

using IT_Company_web.Models;
using Microsoft.EntityFrameworkCore;


namespace IT_Company_web.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}

    


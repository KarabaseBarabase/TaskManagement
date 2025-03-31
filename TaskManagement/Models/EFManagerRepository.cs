namespace TaskManagement.Models
{
    public class EFManagerRepository : IManagerRepository
    {
        private ManagerDbContext _context;
        public EFManagerRepository(ManagerDbContext context)
        {
            _context = context;
        }
        public IQueryable<Mission> Missions => _context.Missions;
    }
}

namespace TaskManagement.Models
{

    public interface IManagerRepository
    {
        IQueryable<Mission> Missions { get; }
    }

}

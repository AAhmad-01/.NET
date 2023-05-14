namespace ZavaJApplicationApi.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        void saveChanges();
        
    }
}

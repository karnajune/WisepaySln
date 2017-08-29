namespace UnitOfWork
{
  using RepositoryInterfaces;

  public interface IUnitOfWork
    {
    IAdminUserRepostitory AdminUserRepostitory { get; }
    IInstituteRepostitory InstituteRepostitory { get; }
    IMemberRepository MemberRepository{ get; }
    ITransactionRepository TransactionRepository{ get; }


    void SaveChanges();

    }
}

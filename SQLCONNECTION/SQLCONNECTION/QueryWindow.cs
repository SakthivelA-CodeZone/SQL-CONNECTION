
namespace SQLCONNECTION
{
    internal class QueryWindow
    {
        QueryWindow Query= new QueryWindow();
        private string connectionString;

        public QueryWindow(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void show()
        {
            throw new NotImplementedException();
        }
    }
}
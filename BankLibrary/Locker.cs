namespace BankLibrary
{
    public class Locker
    {
        private object _data;
        private string _keyword;
        private int _id;

        public Locker(int id, string keyword, object data)
        {
            _id = id;
            _keyword = keyword;
            _data = data;
        }

        public int Id => _id;
        public object Data => _data;

        public bool Matches(int id, string keyword)
        {
            return (_id == id) && (_keyword.Equals(keyword));
        }

        public void RemoveData()
        {
            _data = null;
        }
    }
}

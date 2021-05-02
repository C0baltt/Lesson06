namespace BankLibrary
{
    public class Locker
    {
        private string _keyword;
        private int _id;

        public Locker(int id, string keyword)
        {
            _id = id;
            _keyword = keyword;
        }

        public int Id => _id;

        public bool Matches(int id, string keyword)
        {
            return (_id == id) && (_keyword.Equals(keyword));
        }

        public override bool Equals(object obj)
        {
            if (obj is not Locker locker)
            {
                return false;
            }

            return Id == locker.Id && _keyword.Equals(locker._keyword);
        }

        public override int GetHashCode()
        {
            return Id ^ _keyword.GetHashCode();
        }
    }
}

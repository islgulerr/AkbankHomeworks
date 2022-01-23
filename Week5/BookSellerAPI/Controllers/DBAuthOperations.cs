using DAL.Model;
using EFLibCore;

namespace BookSellerAPI.Controllers
{
    public class DBAuthOperations
    {
        private BookContext _context = new BookContext();

        public void CreateLogin(APIAuthority loginUser)
        {
            _context.APIAuthority.Add(loginUser);
            _context.SaveChanges();
        }

        public APIAuthority GetLogin(APIAuthority loginUser)
        {
            APIAuthority? user = new APIAuthority();
            if (!string.IsNullOrEmpty(loginUser.UserName) && !string.IsNullOrEmpty(loginUser.Password))
            {
                user = _context.APIAuthority.FirstOrDefault(m => m.UserName == loginUser.UserName && m.Password == loginUser.Password);
            }
            return user;

        }
    }
}
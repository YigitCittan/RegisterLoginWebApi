
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Update.Internal;

public class DbHelper {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context) 
        {
            _context = context;
        }
        public List <AccountModel> GetAccounts() 
        {
            List <AccountModel> response = new List<AccountModel> ();
            var dataList = _context.Accounts.ToList();
            dataList.ForEach(row => response.Add(new AccountModel() 
            {
                
                    id=row.Id,
                    name = row.Name,
                    surname = row.Surname,
                    email = row.Email,
                    password = row.Password
                    
                    
            }));
            return response;
            
        }
        

        public void SaveAccount(AccountModel accountModel) 
        {
            
            Account dbTable = new Account();
            
                    dbTable.Name = accountModel.name;
                    dbTable.Email = accountModel.email;
                    dbTable.Surname = accountModel.surname;
                    dbTable.Password = accountModel.password;
                    _context.Accounts.Add(dbTable);
                    
            _context.SaveChanges();
        }
        public AccountModel GetAccountByEmail(string email,string password) 
        {
        AccountModel response = new AccountModel();
        var row =( _context.Accounts.Where(d => d.Email.Equals(email)).FirstOrDefault());
        var pass= _context.Accounts.Where(f => f.Password.Equals(password)).FirstOrDefault();
            
                return new AccountModel()   
                {
                id = row.Id,
                name = row.Name,
                surname = row.Surname,
                email = row.Email,
                password = pass.Password
                };
            
        }
        public void DeleteAccount(string email,string password) 
        {
        var user = _context.Accounts.Where(d => d.Email.Equals(email)).FirstOrDefault();
            
            if (user != null && (user.Password).Equals(password)) 
            {
                _context.Accounts.Remove(user);
                _context.SaveChanges();
            }
        }
    }

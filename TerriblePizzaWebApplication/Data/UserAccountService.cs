using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerriblePizzaWebApplication.Data {
    public class UserAccountService {
        private UserAccountDbContext dbContext;
        public UserAccountService(UserAccountDbContext dbContext) {
            this.dbContext = dbContext;
        }
        
        public async Task<List<UserAccount>> GetAllAccountsAsync() {
            
            return await dbContext.Account.FromSqlRaw("Select * FROM Account").ToListAsync();
        }

        public async Task<UserAccount> GetAccountAsync(string username, string password) {

            return await dbContext.Account.FromSqlRaw($"Select * FROM Account Where username='{username}' AND password='{password}'").FirstOrDefaultAsync();
        }

        public async Task<UserAccount> AddAccountAsync(UserAccount person) {
            try {
                dbContext.Account.Add(person);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception) {
                throw;
            }
            return person;
        }
        public async Task<UserAccount> UpdateAccountAsync(UserAccount account) {
            try {
                var productExist = dbContext.Account.FirstOrDefault(p => p.Id == account.Id);
                if (productExist != null) {
                    dbContext.Update(account);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception) {
                throw;
            }
            return account;
        }
        public async Task DeleteAccountAsync(UserAccount account) {
            try {
                dbContext.Account.Remove(account);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception) {
                throw;
            }
        }
    }
}

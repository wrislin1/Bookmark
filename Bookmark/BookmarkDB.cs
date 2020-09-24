using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Linq;

namespace Bookmark
{
   public class BookmarkDB
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public BookmarkDB()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Story).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Story)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<Story>> GetItemsAsync()
        {
            return Database.Table<Story>().ToListAsync();
        }

        public Task<List<Story>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Story>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Story> GetItemAsync(int id)
        {
            return Database.Table<Story>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Story item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Story item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

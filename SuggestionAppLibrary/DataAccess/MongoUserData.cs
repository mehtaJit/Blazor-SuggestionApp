namespace SuggestionAppLibrary.DataAccess;

public class MongoUserData : IUserData
{
    private readonly IMongoCollection<UserModel> _users;

    public MongoUserData(IDbConnection db)
    {
        _users = db.UserCollection;
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        var output = await _users.FindAsync(_ => true);
        return output.ToList();
    }

    public async Task<UserModel> GetUser(string id)
    {
        var output = await _users.FindAsync(x => x.Id == id);
        return output.FirstOrDefault();
    }

    public async Task<UserModel> GetUserFromAuthentication(string objectId)
    {
        var output = await _users.FindAsync(x => x.ObjectIdentifier == objectId);
        return output.FirstOrDefault();
    }

    public Task CreateUser(UserModel user)
    {
        return _users.InsertOneAsync(user);
    }

    public Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
    }
}

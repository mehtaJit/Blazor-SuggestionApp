namespace SuggestionAppLibrary.Models;

public class BasicUserModel
{
    public BasicUserModel()
    {

    }

    public BasicUserModel(UserModel userModel)
    {
        Id = userModel.Id;
        DisplayName = userModel.DisplayName;
    }

    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string DisplayName { get; set; }
}

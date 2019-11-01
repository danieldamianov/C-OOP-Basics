public class Robot : IIdentifiable , INamable
{
    public string Name { get; }

    public string Id { get; protected set; }

    public Robot(string name , string id)
    {
        this.Name = name;
        this.Id = id;
    }
}


public struct RandomUserApiResponse
{

    public RandomUser[] results;

}

public struct RandomUser
{

    public RandomUserName name;

    public string email;

    public string phone;

    public RandomUserPicture picture;

}

public struct RandomUserName
{

    public string first;

    public string last;

}

public struct RandomUserPicture
{

    public string large;

    public string medium;

}

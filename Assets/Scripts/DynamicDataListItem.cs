using UnityEngine.UIElements;

public class DynamicDataListItem
{

    private Label _name;

    private Label _title;

    private Label _email;

    private Label _phone;

    public DynamicDataListItem(VisualElement visualElement)
    {

        _name = visualElement.Q("Name") as Label;
        _title = visualElement.Q("Title") as Label;
        _email = visualElement.Q("Email") as Label;
        _phone = visualElement.Q("Phone") as Label;
    }

    public void SetData(RandomUser data)
    {

        _name.text = $"{data.name.first} {data.name.last}";
        _title.text = "Randomly generated from randomuser.me";
        _email.text = data.email;
        _phone.text = data.phone;

    }

}

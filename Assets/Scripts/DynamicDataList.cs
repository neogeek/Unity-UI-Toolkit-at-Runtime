using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;

public class DynamicDataList : MonoBehaviour
{

    [SerializeField]
    private UIDocument _uiDocument;

    [SerializeField]
    private VisualTreeAsset _uiDocumentItem;

    private async void Start()
    {
        var items = new List<RandomUser>();

        var data = await FetchDataFromRemoteSource<RandomUserApiResponse>("https://randomuser.me/api/?results=100");

        foreach (var user in data.results)
        {
            items.Add(user);
        }

        var listView = _uiDocument.rootVisualElement.Q("List") as ListView;

        listView.makeItem = () =>
        {
            var listItem = _uiDocumentItem.Instantiate();

            var data = new DynamicDataListItem(listItem);

            listItem.userData = data;

            return listItem;
        };

        listView.fixedItemHeight = 200;

        listView.bindItem = (item, index) =>
        {
            (item.userData as DynamicDataListItem)?.SetData(items[index]);
        };

        listView.itemsSource = items;

    }

    private async Task<T> FetchDataFromRemoteSource<T>(string url)
    {
        using var client = new HttpClient();

        var response = await client.GetStringAsync(url);

        var data = JsonConvert.DeserializeObject<T>(response);

        return data;
    }

}

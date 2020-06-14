using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System;

public class HttpRequest
{

    static string baseUrl = "http://localhost:3000/";

    public static void Get<T>(string route, Action<T> callBack, Action<string> onError = null)
    {
        HttpClient client = new HttpClient();
        client.GetAsync(UrlUtilites.CombineUrlSegments(baseUrl, route)).ContinueWith(response => {
            response.Result.Content.ReadAsStringAsync().ContinueWith(responseBody => {
                if (!response.Result.IsSuccessStatusCode) {
                    Debug.LogError(responseBody.Result);
                    if (onError != null) onError(responseBody.Result);
                }
                else {
                    callBack(PrimitiveHandler.ReturningValue<T>(responseBody.Result));
                }
                client.Dispose();
            });
        });
    }

    public async static Task<T> Get<T>(string route)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(UrlUtilites.CombineUrlSegments(baseUrl, route));
        string responseBody = await response.Content.ReadAsStringAsync();
        client.Dispose();
        if (!response.IsSuccessStatusCode) {
            throw new Exception(responseBody);
        }
        return PrimitiveHandler.ReturningValue<T>(responseBody);
    }

    public static void Post<T, U>(string route, T body, Action<U> callBack, Action<string> onError = null)
    {
        HttpClient client = new HttpClient();
        HttpContent content = PrimitiveHandler.Parameter(body);

        client.PostAsync(UrlUtilites.CombineUrlSegments(baseUrl, route), content).ContinueWith(response => {
            response.Result.Content.ReadAsStringAsync().ContinueWith(responseBody => {
                if (!response.Result.IsSuccessStatusCode) {
                    Debug.LogError(responseBody.Result);
                    if (onError != null) onError(responseBody.Result);
                }
                else {
                    callBack(PrimitiveHandler.ReturningValue<U>(responseBody.Result));
                }
                client.Dispose();
            });
        });
    }

    public async static Task<U> Post<T, U>(string route, T body)
    {
        HttpClient client = new HttpClient();
        HttpContent content = PrimitiveHandler.Parameter(body);
        HttpResponseMessage response = await client.PostAsync(UrlUtilites.CombineUrlSegments(baseUrl, route), content);
        string responseBody = await response.Content.ReadAsStringAsync();
        client.Dispose();
        if (!response.IsSuccessStatusCode) {
            throw new Exception(responseBody);
        }
        return PrimitiveHandler.ReturningValue<U>(responseBody);
    }

}

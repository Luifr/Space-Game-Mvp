using UnityEngine;
using System.Net.Http;
using System.Text;
using System;

public class PrimitiveHandler {

    public static bool IsPrimitive(Type t) {
        return t.IsPrimitive || t.IsValueType || (t == typeof(string));
    }

    public static bool IsPrimitive<T>() {
        Type t = typeof(T);
        return t.IsPrimitive || t.IsValueType || (t == typeof(string));
    }

    // If generic type is not primitive the value should be converted from string to json
    // Otherwise, just returns is
    public static T ReturningValue<T> (string data) {
        if (IsPrimitive(typeof(T))) return data as dynamic;
        else return JsonUtility.FromJson<T>(data);
    }

    // If generic type is not primitive the value should be converted from json to string
    // and be returned as StringContent, with the Http Header as json or plaint text (the default one)
    public static StringContent Parameter<T> (T data) {
        if (IsPrimitive(typeof(T))) return new StringContent(data as string);
        else return new StringContent(JsonUtility.ToJson(data), Encoding.UTF8, "application/json");
    }
}
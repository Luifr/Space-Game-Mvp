public static class UrlUtilites {

    // Concatenates two Url parts checking the slash between them
    public static string CombineUrlSegments(string urlA, string urlB) {
        string slash = "/";
        if (urlA.EndsWith(slash) && urlB.StartsWith(slash)) {
            return urlA + urlB.Substring(1);
        }
        else if (urlA.EndsWith(slash) || urlB.StartsWith(slash)) {
            return urlA + urlB;
        }
        else {
            return urlA + slash + urlB;
        }
    }
}

public static class String {

    // Add this method to the class Strin, use it to add a query parameter to a URL
    // ex:
    // string url = "http://google.com";
    // url.AddQueryParam("id", "3");
    // result: "http://google.com?id=3"
    public static string AddQueryParam(this string source, string key, string value)
    {
        string delim;
        if ((source == null) || !source.Contains("?"))
        {
            delim = "?";
        }
        else if (source.EndsWith("?") || source.EndsWith("&"))
        {
            delim = string.Empty;
        }
        else
        {
            delim = "&";
        }

        return source + delim + System.Uri.EscapeUriString(key)
            + "=" + System.Uri.EscapeUriString(value);
    }
}

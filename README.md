Hacker News Now
=============

**Hacker News Now** is a cross-platform application that runs lets you read the latest and greatest of HackerNews. It supports Android, iOS, Windows Phone and Window.

**Why?** Because I want to learn.

What API does this  use?
--------------

Currently the application makes use of [iHackerNews](api.ihackernews.com)'s API which returns an entry with the following information:

```
public class Entry
{
    public int Id { get; set; }
    public int Points { get; set; }
    public string PostedAgo { get; set; }
    public string PostedBy { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}
```

Fetching all entries via the repository is easy, it will do an API call each time, there is no caching built in. You easilly fetch all the entries like this:

```
public async Task<IEnumerable<Entry>> TopEntriesAsync()
```

Requirements
--------------

To build and run **Hacker News Now** you need access to a Mac with Xamarin installed. As of now you cannot do Nuget Package Restores because the Add-In for Xamarin studio does not support the latest version of Xamarin.

**You need to build on Windows connected to a Mac Xamarin Build Host!**

Screenshots
--------------

![](https://github.com/fekberg/HackerNewsNow/blob/master/Resources/1.png?raw=true)

![](https://github.com/fekberg/HackerNewsNow/blob/master/Resources/2.png?raw=true)

License
----

MIT


    

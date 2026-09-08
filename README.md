# WebCrawler
A Windows Forms app in C# with .Net 10

A super-simple app for people wanting to get their feet wet with web crawlers.

<img width="962" height="482" alt="image" src="https://github.com/user-attachments/assets/a453596e-7aba-4947-96c7-12c3a8148d1f" />

*Figure 1 - WebCrawler in action.*

The app just has two classes:

* A Form that handles the UI.
* A Crawler that handles the actual crawling.

The Form just contains a bunch of panels and controls. The only code is to kick off the Crawler when the Crawl button is clicked, and then display the discovered links. The most interesting code is in the Crawler.

The following figure shows the sequence diagram.

<img width="604" height="470" alt="image" src="https://github.com/user-attachments/assets/1fd3e54a-8d26-40c3-9c21-2bfd8831cb64" />

*Figure 2 - The WebCrawler sequence diagram.*

## The Crawler Code

The two methods shown in the sequence diagram as shown in the following listings.

```csharp
public async Task CrawlAsync(Uri startUri, int theMaxPages, int theMaxDepth, bool useSameDomainOnly)
{
  maxPages = theMaxPages;
  maxDepth = theMaxDepth;
  sameDomainOnly = useSameDomainOnly;

  pagesVisited = 0;
  _visitedSites.Clear();

  var queue = new Queue<(Uri Url, int Depth)>();
  queue.Enqueue((startUri, 0));

  _visitedSites.Add(Normalize(startUri));

  while (queue.Count > 0 && pagesVisited < maxPages)
  {
    var (currentUrl, depth) = queue.Dequeue();
    pagesVisited++;

    DateTime start = DateTime.Now;
    var (statusCode, links) = await FetchAndExtractAsync(currentUrl);
    TimeSpan responseTime = DateTime.Now - start;

    _results.Add((currentUrl, statusCode, depth, links.Count));
    FirePageCrawled(pagesVisited, depth, statusCode, responseTime, links.Count, currentUrl);

    if (depth >= maxDepth) continue;

    foreach (var link in links)
    {
      if (!IsValidDomain(link, startUri)) continue;

      var key = Normalize(link);

      if (_visitedSites.Contains(key)) continue;

      _visitedSites.Add(key);
      queue.Enqueue((link, depth + 1));
    }
  }
}
```
*Listing 1 - Method CrawlAsync.*
<br/>
<br/>

```csharp
  async Task<(int StatusCode, List<Uri> Links)> FetchAndExtractAsync(Uri url)
  {
    try
    {
      using var response = await httpClient.GetAsync(url);
      var statusCode = (int)response.StatusCode;

      var contentType = response.Content.Headers.ContentType?.MediaType ?? string.Empty;
      if (!response.IsSuccessStatusCode || !contentType.Contains("html", StringComparison.OrdinalIgnoreCase))
        return (statusCode, new List<Uri>());

      var html = await response.Content.ReadAsStringAsync();
      var links = ExtractLinks(html, url).ToList();
      return (statusCode, links);
    }
    catch (TaskCanceledException)
    {
      System.Diagnostics.Debug.WriteLine($"Error fetching {url}: Request timed out");
      return (-1, new List<Uri>());
    }
    catch (Exception ex)
    {
      System.Diagnostics.Debug.WriteLine($"Error fetching {url}: {ex.Message}");
      return (-1, new List<Uri>());
    }
  }
```
*Listing 2 - Method FetchAndExtractAsync.*



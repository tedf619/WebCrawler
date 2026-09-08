using System.Text.RegularExpressions;

namespace WebCrawler;

/// <summary>
/// Performs a breadth-first crawl starting from a designated URL
/// </summary>
public class Crawler
{
  readonly HttpClient httpClient;
  int maxPages, maxDepth, pagesVisited;
  bool sameDomainOnly;

  readonly HashSet<string> _visitedSites = new(StringComparer.OrdinalIgnoreCase);
  readonly List<(Uri Url, int StatusCode, int Depth, int LinksFound)> _results = new();

  // Matches href="..." and href='...' in anchor tags
  Regex HrefRegex = new(@"href\s*=\s*[""']([^""'#>]+)[""']", RegexOptions.IgnoreCase | RegexOptions.Compiled);

  public Crawler()
  {
    httpClient = new HttpClient(new HttpClientHandler{AllowAutoRedirect = true});
    httpClient.Timeout = TimeSpan.FromSeconds(2);
    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("WebCrawler/1.0");
  }

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

  bool IsValidDomain(Uri baseUri, Uri otherUri)
  {
    if (!sameDomainOnly) return true;
    return string.Equals(baseUri.Host, otherUri.Host, StringComparison.OrdinalIgnoreCase);
  }

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

  string Normalize(Uri uri)
  {
    // create an absolute URI, stripping the fragment and trailing slashes, and converting to lowercase
    var builder = new UriBuilder(uri) { Fragment = string.Empty };
    var path = builder.Uri.AbsolutePath.TrimEnd('/');
    return $"{builder.Uri.Scheme}://{builder.Uri.Host}{path}{builder.Uri.Query}".ToLowerInvariant();
  }

  /// <summary>Extracts absolute link URIs found in an HTML document.</summary>
  IEnumerable<Uri> ExtractLinks(string html, Uri baseUri)
  {
    foreach (Match match in HrefRegex.Matches(html))
    {
      var uri = match.Groups[1].Value.Trim();

      if (IsntCrawlableUri(uri)) continue;

      if (Uri.TryCreate(baseUri, uri, out var resolved) &&
          (resolved.Scheme == Uri.UriSchemeHttp || resolved.Scheme == Uri.UriSchemeHttps))
      {
        yield return resolved;
      }
    }
  }

  bool IsntCrawlableUri(string schema)
  {
    return schema.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase) ||
           schema.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase) ||
           schema.StartsWith("tel:", StringComparison.OrdinalIgnoreCase);
  }

  #region Events
  public delegate void PageHandler(int pageNumber, int depth, int statusCode, TimeSpan responseTime, int linksFound, Uri url);
  public event PageHandler? PageCrawled;
  void FirePageCrawled(int pageNumber, int depth, int statusCode, TimeSpan responseTime, int linksFound, Uri url)
  {
    PageCrawled?.Invoke(pageNumber, depth, statusCode, responseTime, linksFound, url);
  }
  #endregion
}

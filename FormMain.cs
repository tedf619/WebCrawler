namespace WebCrawler
{
  public partial class FormMain : Form
  {
    Crawler crawler;

    string StatusMessage { set { labelStatusMessage.Text = value; } }

    public FormMain()
    {
      InitializeComponent();

      crawler = new Crawler();
      crawler.PageCrawled += Crawler_PageCrawled;
      textBoxWebPage.Text = Properties.Settings.Default.WebSite;
    }

    async void buttonCrawl_Click(object sender, EventArgs e)
    {
      if (!Uri.TryCreate(textBoxWebPage.Text, UriKind.Absolute, out var startUri))
      {
        MessageBox.Show("Invalid starting URL.", "Error");
        return;
      }

      Properties.Settings.Default.WebSite = textBoxWebPage.Text;
      Properties.Settings.Default.Save();

      StatusMessage = "Crawling...";
      Cursor = Cursors.WaitCursor;
      listViewLinksFound.Items.Clear();

      await crawler.CrawlAsync(startUri, (int)numericUpDownMaxLinks.Value, (int)numericUpDownMaxDepth.Value, checkBoxSameDomainOnly.Checked);

      StatusMessage = $"Links found: {listViewLinksFound.Items.Count}";
      Cursor = Cursors.Default;
    }

    void Crawler_PageCrawled(int pageNumber, int depth, int statusCode, TimeSpan responseTime, int linksFound, Uri url)
    {
      ListViewItem lvi = new ListViewItem(pageNumber.ToString());
      lvi.SubItems.Add(depth.ToString());
      lvi.SubItems.Add(statusCode.ToString());
      lvi.SubItems.Add(responseTime.TotalMilliseconds.ToString("n0"));
      lvi.SubItems.Add(linksFound.ToString());
      lvi.SubItems.Add(url.ToString());

      listViewLinksFound.Items.Add(lvi);
      columnHeaderUrl.Width = -2; // Auto-size the URL column
    }
  }
}

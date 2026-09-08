namespace WebCrawler
{
  partial class FormMain
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      panelTop = new Panel();
      label4 = new Label();
      checkBoxSameDomainOnly = new CheckBox();
      numericUpDownMaxLinks = new NumericUpDown();
      label3 = new Label();
      numericUpDownMaxDepth = new NumericUpDown();
      label2 = new Label();
      buttonCrawl = new Button();
      textBoxWebPage = new TextBox();
      label1 = new Label();
      panelBottom = new Panel();
      labelStatusMessage = new Label();
      panelMiddle = new Panel();
      listViewLinksFound = new ListView();
      columnHeaderLink = new ColumnHeader();
      columnHeaderDepth = new ColumnHeader();
      columnHeaderStatus = new ColumnHeader();
      columnHeaderTime = new ColumnHeader();
      columnHeaderLinks = new ColumnHeader();
      columnHeaderUrl = new ColumnHeader();
      label5 = new Label();
      toolTip1 = new ToolTip(components);
      panelTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)numericUpDownMaxLinks).BeginInit();
      ((System.ComponentModel.ISupportInitialize)numericUpDownMaxDepth).BeginInit();
      panelBottom.SuspendLayout();
      panelMiddle.SuspendLayout();
      SuspendLayout();
      // 
      // panelTop
      // 
      panelTop.Controls.Add(label4);
      panelTop.Controls.Add(checkBoxSameDomainOnly);
      panelTop.Controls.Add(numericUpDownMaxLinks);
      panelTop.Controls.Add(label3);
      panelTop.Controls.Add(numericUpDownMaxDepth);
      panelTop.Controls.Add(label2);
      panelTop.Controls.Add(buttonCrawl);
      panelTop.Controls.Add(textBoxWebPage);
      panelTop.Controls.Add(label1);
      panelTop.Dock = DockStyle.Top;
      panelTop.Location = new Point(0, 0);
      panelTop.Name = "panelTop";
      panelTop.Size = new Size(960, 117);
      panelTop.TabIndex = 0;
      // 
      // label4
      // 
      label4.Dock = DockStyle.Top;
      label4.ForeColor = Color.Teal;
      label4.Location = new Point(0, 0);
      label4.Name = "label4";
      label4.Size = new Size(960, 23);
      label4.TabIndex = 8;
      label4.Text = "This app performs a breadth-first search of the crawl tree, starting at the given web page.";
      label4.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // checkBoxSameDomainOnly
      // 
      checkBoxSameDomainOnly.AutoSize = true;
      checkBoxSameDomainOnly.CheckAlign = ContentAlignment.MiddleRight;
      checkBoxSameDomainOnly.Checked = true;
      checkBoxSameDomainOnly.CheckState = CheckState.Checked;
      checkBoxSameDomainOnly.Location = new Point(522, 79);
      checkBoxSameDomainOnly.Name = "checkBoxSameDomainOnly";
      checkBoxSameDomainOnly.Size = new Size(128, 19);
      checkBoxSameDomainOnly.TabIndex = 7;
      checkBoxSameDomainOnly.Text = "Same Domain Only";
      toolTip1.SetToolTip(checkBoxSameDomainOnly, "Restrict crawling to the starting web site");
      checkBoxSameDomainOnly.UseVisualStyleBackColor = true;
      // 
      // numericUpDownMaxLinks
      // 
      numericUpDownMaxLinks.Location = new Point(403, 78);
      numericUpDownMaxLinks.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      numericUpDownMaxLinks.Name = "numericUpDownMaxLinks";
      numericUpDownMaxLinks.Size = new Size(51, 23);
      numericUpDownMaxLinks.TabIndex = 6;
      toolTip1.SetToolTip(numericUpDownMaxLinks, "The max number of links to record at each level of the crawl tree");
      numericUpDownMaxLinks.Value = new decimal(new int[] { 50, 0, 0, 0 });
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(337, 81);
      label3.Name = "label3";
      label3.Size = new Size(60, 15);
      label3.TabIndex = 5;
      label3.Text = "Max Links";
      // 
      // numericUpDownMaxDepth
      // 
      numericUpDownMaxDepth.Location = new Point(197, 78);
      numericUpDownMaxDepth.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
      numericUpDownMaxDepth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      numericUpDownMaxDepth.Name = "numericUpDownMaxDepth";
      numericUpDownMaxDepth.Size = new Size(51, 23);
      numericUpDownMaxDepth.TabIndex = 4;
      toolTip1.SetToolTip(numericUpDownMaxDepth, "The depth of the tree to traverse in the crawl tree");
      numericUpDownMaxDepth.Value = new decimal(new int[] { 3, 0, 0, 0 });
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(129, 81);
      label2.Name = "label2";
      label2.Size = new Size(65, 15);
      label2.TabIndex = 3;
      label2.Text = "Max Depth";
      // 
      // buttonCrawl
      // 
      buttonCrawl.Location = new Point(697, 40);
      buttonCrawl.Name = "buttonCrawl";
      buttonCrawl.Size = new Size(75, 23);
      buttonCrawl.TabIndex = 2;
      buttonCrawl.Text = "Crawl";
      toolTip1.SetToolTip(buttonCrawl, "Launches the crawling process");
      buttonCrawl.UseVisualStyleBackColor = true;
      buttonCrawl.Click += buttonCrawl_Click;
      // 
      // textBoxWebPage
      // 
      textBoxWebPage.Location = new Point(126, 37);
      textBoxWebPage.Name = "textBoxWebPage";
      textBoxWebPage.Size = new Size(548, 23);
      textBoxWebPage.TabIndex = 1;
      toolTip1.SetToolTip(textBoxWebPage, "URL of site, e.g. \"https://www.mysite.com\"");
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(22, 40);
      label1.Name = "label1";
      label1.Size = new Size(105, 15);
      label1.TabIndex = 0;
      label1.Text = "Web page to crawl";
      // 
      // panelBottom
      // 
      panelBottom.BorderStyle = BorderStyle.Fixed3D;
      panelBottom.Controls.Add(labelStatusMessage);
      panelBottom.Dock = DockStyle.Bottom;
      panelBottom.Location = new Point(0, 423);
      panelBottom.Name = "panelBottom";
      panelBottom.Size = new Size(960, 27);
      panelBottom.TabIndex = 1;
      // 
      // labelStatusMessage
      // 
      labelStatusMessage.Dock = DockStyle.Fill;
      labelStatusMessage.Location = new Point(0, 0);
      labelStatusMessage.Name = "labelStatusMessage";
      labelStatusMessage.Size = new Size(956, 23);
      labelStatusMessage.TabIndex = 4;
      labelStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // panelMiddle
      // 
      panelMiddle.Controls.Add(listViewLinksFound);
      panelMiddle.Controls.Add(label5);
      panelMiddle.Dock = DockStyle.Fill;
      panelMiddle.Location = new Point(0, 117);
      panelMiddle.Name = "panelMiddle";
      panelMiddle.Size = new Size(960, 306);
      panelMiddle.TabIndex = 2;
      // 
      // listViewLinksFound
      // 
      listViewLinksFound.Columns.AddRange(new ColumnHeader[] { columnHeaderLink, columnHeaderDepth, columnHeaderStatus, columnHeaderTime, columnHeaderLinks, columnHeaderUrl });
      listViewLinksFound.Dock = DockStyle.Fill;
      listViewLinksFound.FullRowSelect = true;
      listViewLinksFound.Location = new Point(0, 23);
      listViewLinksFound.Name = "listViewLinksFound";
      listViewLinksFound.Size = new Size(960, 283);
      listViewLinksFound.TabIndex = 1;
      listViewLinksFound.UseCompatibleStateImageBehavior = false;
      listViewLinksFound.View = View.Details;
      // 
      // columnHeaderLink
      // 
      columnHeaderLink.Text = "Link";
      // 
      // columnHeaderDepth
      // 
      columnHeaderDepth.Text = "Depth";
      // 
      // columnHeaderStatus
      // 
      columnHeaderStatus.Text = "Status";
      // 
      // columnHeaderTime
      // 
      columnHeaderTime.Text = "Time (ms)";
      columnHeaderTime.Width = 80;
      // 
      // columnHeaderLinks
      // 
      columnHeaderLinks.Text = "Links";
      // 
      // columnHeaderUrl
      // 
      columnHeaderUrl.Text = "URL";
      columnHeaderUrl.Width = 635;
      // 
      // label5
      // 
      label5.BackColor = Color.Blue;
      label5.Dock = DockStyle.Top;
      label5.ForeColor = Color.White;
      label5.Location = new Point(0, 0);
      label5.Name = "label5";
      label5.Size = new Size(960, 23);
      label5.TabIndex = 0;
      label5.Text = "Links Found";
      label5.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // FormMain
      // 
      AcceptButton = buttonCrawl;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(960, 450);
      Controls.Add(panelMiddle);
      Controls.Add(panelBottom);
      Controls.Add(panelTop);
      Name = "FormMain";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "WebCrawler";
      panelTop.ResumeLayout(false);
      panelTop.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)numericUpDownMaxLinks).EndInit();
      ((System.ComponentModel.ISupportInitialize)numericUpDownMaxDepth).EndInit();
      panelBottom.ResumeLayout(false);
      panelMiddle.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel panelTop;
    private Button buttonCrawl;
    private TextBox textBoxWebPage;
    private Label label1;
    private Panel panelBottom;
    private Panel panelMiddle;
    private CheckBox checkBoxSameDomainOnly;
    private NumericUpDown numericUpDownMaxLinks;
    private Label label3;
    private NumericUpDown numericUpDownMaxDepth;
    private Label label2;
    private ToolTip toolTip1;
    private Label label4;
    private Label label5;
    private Label labelStatusMessage;
    private ListView listViewLinksFound;
    private ColumnHeader columnHeaderLink;
    private ColumnHeader columnHeaderDepth;
    private ColumnHeader columnHeaderStatus;
    private ColumnHeader columnHeaderLinks;
    private ColumnHeader columnHeaderUrl;
    private ColumnHeader columnHeaderTime;
  }
}

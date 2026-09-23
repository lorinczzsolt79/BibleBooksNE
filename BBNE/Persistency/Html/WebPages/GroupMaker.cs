using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;

namespace BibleBooksNE.Persistency.Html.WebPages
{
    internal class GroupMaker
    {
        private static readonly FullIdentifier DefaultFullIdentifier =
            new ( new(-2), new(-2), new(-2), new(-2), new(-2), PageOrder.unknown);

        public FullIdentifierWithText FullIdentifier_WithText { get; set; } =
            new FullIdentifierWithText(DefaultFullIdentifier, string.Empty);

        public FullIdentifier FullId => FullIdentifier_WithText.Ids;
        public string HeaderText { get; } = string.Empty;
        public int Type { get; } = 0;

        private readonly List<string> items = [];

        public GroupMaker() { }

        public GroupMaker(FullIdentifierWithText fullIdentifierWithText, int type, string headerText)
        {
            FullIdentifier_WithText = fullIdentifierWithText;
            if (string.IsNullOrEmpty(fullIdentifierWithText.Text))
            {
                HeaderText = headerText;
            }
            Type = type;
        }

        public void Add(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        private string Items => string.Join(Environment.NewLine, items);

        private int GetHLevel() => GetHLevel((PageOrder)Type);

        public static int GetHLevel(PageOrder N) => N switch
        {
            PageOrder.document => 1,
            PageOrder.page => 2,
            PageOrder.bible => 3,
            PageOrder.book => 4,
            PageOrder.chapter => 5,
            PageOrder.headline_title => 6,
            _ => 0
        };

        public bool Empty => FullId.Type.N switch
        {
            (int)PageOrder.unknown => true,
            (int)PageOrder.none => true,
            _ => false
        };

        public string GetGroup()
        {
            return Empty ? Items :
                FullId.Type.N == (int)PageOrder.item_group
                    ? VersesWebPageTemplates.VerseGroupTemplate(HeaderText, FullId.ToString(), Items)
                    : FullId.Type.N == (int)PageOrder.footnote_group
                    ? VersesWebPageTemplates.FootnoteListTemplate(Items)
                    : VersesWebPageTemplates.DetailsGroupTemplate(GetHLevel().ToString(), FullId.ToString(), HeaderText, Items);
        }
   }
}

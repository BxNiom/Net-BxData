namespace Bx.Data.Query.Elements;

public class LikeElement : AbstractConditionElement
{
    public LikeElement(string column, string term) : base(ElementType.Like, column)
    {
        Term = term;
    }

    public string Term { get; set; }
}
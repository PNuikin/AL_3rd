namespace Lab07_Library;

public class MyComment : Attribute
{
    public string Comment { get; }
    public MyComment() { }
    public MyComment(string comment) => Comment = comment;
}
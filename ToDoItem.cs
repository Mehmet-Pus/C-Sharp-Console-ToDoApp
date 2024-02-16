namespace ToDo;

public class ToDoItem
{
    public ToDoItem(string name, bool marked)
    {
        this.Name = name;
        this.Marked = marked;
    }
    
    public ToDoItem(string name)
        : this(name,false)
    {
    }
    
    public string Name { get; set; } = default!;
    public bool Marked { get; set; }

    public override string ToString()
    {
        string marked = Marked ? "[x]" : "[ ]";
        return $"{marked} {Name}";
    }

    
}

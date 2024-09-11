

namespace LänkadListaLab
{
    //en generisk lista som kan innehålla värden av olika typer (dock samma slags värden i en lista)
    //Den är enkellänkadlänkad och har ett värde (Value) och en pekare (next).
    public class Node<T>
    {
            public T Value { get; set; }
            public Node<T>? Next { get; set; }

            public Node<T>? Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
    }
}

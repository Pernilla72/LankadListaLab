using System; 
using System.Collections;
using System.Collections.Generic;

//Vet att man ska undvika å, ä och ö i namespace, men nu råkade det bli så....

namespace LänkadListaLab
{   
    public class MyList<T> : IEnumerable<T>
    {
        //head och tail håller reda på starten resp. slutet på listan.
        private Node<T>? head;
        private Node<T>? tail;
        public int Count { get; private set; }

        public MyList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        // Lägg till ett värde i slutet av listan
        public void AddElement(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        // Indexer: få eller sätt ett värde via index
        //Identifierar index i klassen, "int index" talar om att indexet är ett heltal, inte värdet.
        public T this[int index]
        {
            get  //Hämta värdet på en viss position
            {
                //Den här kontrollen ser till att det efterfrågade indexet är giltigt. Detta förhindrar att du försöker komma åt en plats
                //som inte existerar i listan. 

                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                    //En referens till den första noden i den länkade listan (head) skapas.Detta gör att vi börjar vid första elementet
                    //när vi söker efter rätt index. Variablen "current" håller reda på vilken nod i listan vi kollar på.

                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
            set  //Ändra värdet på en viss position
            {
                        //Den här kontrollen ser till att det efterfrågade indexet är giltigt.
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                        //När rätt nod har hittats så tilldelas det nya värdet till "value"
                current.Value = value;
            }
        }

        // Ta bort det sista värdet i listan
        public void RemoveLastElement()
        {
            if (head == null) return;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }
            Count--;
        }

        // Lägg till ett värde före ett specifikt index, tar ett värde och ett index som parameter

        public void AddBeforeElement(T value, int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            //Skapar en ny nod med det värde (value) man vill lägga till, om index valt är 0, alltså första index, körs if, annars else.
            Node<T> newNode = new Node<T>(value);
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            // Till sist ökar vi antalet element i listan
            Count++;
        }

        

        // Ta bort ett värde utifrån ett specifikt index
        public void RemoveAfterElement(int index)
        {
            if (index < 0 || index >= Count - 1)
                throw new IndexOutOfRangeException();

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            if (current.Next == tail)
            {
                tail = current;
            }
            current.Next = current.Next.Next;
            Count--;
        }

        // Ta bort alla värden efter ett specifikt index
        public void RemoveAllAfterIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
            Count = index + 1;
        }

       

        // Returnerar en array av värdena i listan
        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }

        // Returnerar en klonad array av värdena i listan
        public T[] ToClonedArray()
        {
            return (T[])ToArray().Clone();
        }

        // Sorterar listan i stigande ordning
        public void SortMyList(bool ascending = true)
        {
            if (Count <= 1) return;

            var array = ToArray();
            Array.Sort(array);
            if (!ascending) Array.Reverse(array);

            Node<T> current = head;
            foreach (var value in array)
            {
                current.Value = value;
                current = current.Next;
            }
        }

        // Implementation av IEnumerable så att listan kan loopas med foreach
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SignlyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head;
        private SinglyLinkedListNode<T> _current;

        public SignlyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (_current is null)
            {
                _current = Head;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current is not null;
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}
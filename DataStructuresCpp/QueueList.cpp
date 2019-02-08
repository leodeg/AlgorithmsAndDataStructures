#include "QueueList.h"

QueueList::QueueList ()
{
    length = -1;
    first = nullptr;
    last = nullptr;
}

QueueList::~QueueList ()
{
    delete first;
    delete last;
}

void QueueList::Enqueue (int data)
{
    Node* current = new Node ();
    current->data = data;
    current->next = nullptr;

    if (first == nullptr && last == nullptr)
    {
        first = last = current;
        length++;
        return;
    }

    last->next = current;
    last = current;
    length++;
}

void QueueList::Dequeue ()
{
    Node* current = first;

    if (first == nullptr) return;
    if (first == last)
    {
        first = last = nullptr;
    }
    else
    {
        first = first->next;
    }

    delete current;
}

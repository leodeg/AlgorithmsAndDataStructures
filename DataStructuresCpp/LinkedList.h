#ifndef LINKED_LIST_H
#define LINKED_LIST_H

class LinkedList
{
private:

    struct Node { int data; Node* next; };
    int length;
    Node* head;

    void StartRecursionPrint (Node* head);

public:

    LinkedList ();
    ~LinkedList ();

    void InsertFront (int data);
    void InsertBack (int data);
    void InsertAt (int data, int index);
    void Delete (int index);
    void Reverse ();

    void PrintRecursion ();
    void Print ();
    int GetLength ();
};

#endif // LINKED_LIST_H

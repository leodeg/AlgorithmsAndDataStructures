#ifndef LINKED_LIST_H
#define LINKED_LIST_H

struct Node { int data; Node* next; };

class LinkedList
{
private:

    int length;
    Node* head;

    void StartPrintRecursion (Node* head);
    void StartReverseRecursion (Node* head);

public:

    LinkedList ();
    ~LinkedList ();

    void InsertFront (int data);
    void InsertBack (int data);
    void InsertAt (int data, int index);
    void Delete (int index);
    void Reverse ();
    void ReverseRecursion ();
    void PrintRecursion ();
    void Print ();
    int GetLength ();
    bool IsEmpty ();
};

#endif // LINKED_LIST_H

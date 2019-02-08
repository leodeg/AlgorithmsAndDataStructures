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
    int StartSearchRecursion (Node* node, int value);

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
    int SearchRecursion (int value);
    int GetLength ();
    bool IsEmpty ();
};

#endif // LINKED_LIST_H

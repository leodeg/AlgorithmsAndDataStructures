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

    void Print ();
    bool IsEmpty ();
    void Reverse ();
    int GetLength ();
    void PrintRecursion ();
    void Delete (int index);
    void ReverseRecursion ();
    void InsertBack (int data);
    void InsertFront (int data);
    int SearchRecursion (int value);
    void InsertAt (int data, int index);
};

#endif // LINKED_LIST_H

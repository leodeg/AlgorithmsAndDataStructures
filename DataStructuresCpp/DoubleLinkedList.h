#ifndef DOUBLE_LINKED_LIST_H
#define DOUBLE_LINKED_LIST_H

struct Node { int data; Node* next; Node* prev; };

class DoubleLinkedList
{
private:
    int length;
    Node* head;

    Node* CreateNewNode (int data);

public:

    DoubleLinkedList ();
    ~DoubleLinkedList ();

    void Print ();
    void PrintReverse ();
    void InsertFront (int data);
    void InsertBack (int data);
};

#endif //DOUBLE_LINKED_LIST_H
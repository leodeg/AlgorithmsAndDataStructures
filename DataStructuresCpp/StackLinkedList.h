#ifndef STACK_LINKED_LIST_H
#define STACK_LINKED_LIST_H

struct Node { int data; Node* link; };

struct StackLinkedList
{
private:
    Node* top = nullptr;
    int length;

public:

    void Push (int data);
    void Pop ();
    int Peek ();
    void Print ();
    bool IsEmpty ();
    int GetLength ();
};

#endif // STACK_LINKED_LIST_H

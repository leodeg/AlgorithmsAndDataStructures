#ifndef LINKED_LIST_H
#define LINKED_LIST_H

#include "Node.h"

class LinkedList
{
private:
    int length;
    Node* head;

public:
    LinkedList ();
    ~LinkedList ();

    void add (int data);
    void print ();
    int getLength ();
};

#endif // LINKED_LIST_H

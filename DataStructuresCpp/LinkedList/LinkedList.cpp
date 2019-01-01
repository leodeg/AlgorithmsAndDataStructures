#include "LinkedList.h"
#include <iostream>

LinkedList::LinkedList ()
{
    this->length = 0;
    this->head = nullptr;
}

LinkedList::~LinkedList ()
{
    delete head;
}

void LinkedList::add (int data)
{
    Node* node = new Node ();
    node->data = data;
    node->next = this->head;
    this->head = node;
    this->length++;
}

void LinkedList::print ()
{
    Node* current = this->head;
    int i = 1;
    while (current)
    {
        std::cout << i << current->data << std::endl;
        current = current->next;
        ++i;
    }
}

int LinkedList::getLength ()
{
    return this->length;
}

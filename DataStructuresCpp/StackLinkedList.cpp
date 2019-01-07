#include "StackLinkedList.h"
#include <iostream>

void StackLinkedList::Push (int data)
{
    Node* node = new Node ();
    node->data = data;
    node->link = top;
    top = node;
    this->length++;
}

void StackLinkedList::Pop ()
{
    Node* current;
    if (top == nullptr)
    {
        std::cout << "StackLinkedList::Error::Stack is empty" << std::endl;
        return;
    }

    current = top;
    top = top->link;
    delete current;
    this->length--;
}

int StackLinkedList::Peek ()
{
    if (top == nullptr)
    {
        std::cout << "StackLinkedList::Error::Stack is empty" << std::endl;
        return;
    }

    return top->data;
}

void StackLinkedList::Print ()
{
    if (top == nullptr)
    {
        std::cout << "StackLinkedList::Error::Stack is empty" << std::endl;
        return;
    }

    Node* current = top;
    std::cout << "Stack: ";
    while (top != nullptr)
    {
        std::cout << current->data << ' ';
        current = current->link;
    }
    std::cout << std::endl;
}

bool StackLinkedList::IsEmpty ()
{
    return top == nullptr;
}

int StackLinkedList::GetLength ()
{
    return this->length;
}

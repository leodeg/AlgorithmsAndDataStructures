#include "StackLinkedList.h"
#include <iostream>

void StackLinkedList::Push (int data)
{
    Node* node = new Node ();
    node->data = data;
    node->link = this->top;
    this->top = node;
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

    current = this->top;
    this->top = this->top->link;
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

    return this->top->data;
}

void StackLinkedList::Print ()
{
    if (top == nullptr)
    {
        std::cout << "StackLinkedList::Error::Stack is empty" << std::endl;
        return;
    }

    Node* current = this->top;
    std::cout << "Stack: ";
    while (this->top != nullptr)
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

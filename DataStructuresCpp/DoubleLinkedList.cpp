#include "DoubleLinkedList.h"
#include <iostream>

Node* DoubleLinkedList::CreateNewNode (int data)
{
    Node* node = new Node ();
    node->data = data;
    node->prev = nullptr;
    node->next = nullptr;
    return node;
}

DoubleLinkedList::DoubleLinkedList ()
{
    this->length = 0;
    this->head = nullptr;
}

DoubleLinkedList::~DoubleLinkedList ()
{
    delete head;
}

void DoubleLinkedList::Print ()
{
    Node* current = this->head;

    std::cout << "Forward: ";
    while (current != nullptr)
    {
        std::cout << current->data << " ";
        current = current->next;
    }
    std::cout << std::endl;
}

void DoubleLinkedList::PrintReverse ()
{
    Node* current = this->head;
    while (current != nullptr) current->next;

    std::cout << "Reverse: ";
    while (current != nullptr)
    {
        std::cout << current->data << " ";
        current = current->prev;
    }
    std::cout << std::endl;
}

void DoubleLinkedList::InsertFront (int data)
{
    Node* node = CreateNewNode (data);
    if (head == nullptr)
    {
        head = node;
        return;
    }

    head->prev = node;
    node->next = head;
    head = node;
}

void DoubleLinkedList::InsertBack (int data)
{
    Node* current = head;
    Node* node = CreateNewNode (data);
    if (head == nullptr)
    {
        head = node;
        return;
    }

    while (current != nullptr) current->next;
    current->next = node;
    node->prev = current;
}


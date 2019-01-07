#include "LinkedList.h"

#include <iostream>
#include <string>

LinkedList::LinkedList ()
{
    this->length = 0;
    this->head = nullptr;
}

LinkedList::~LinkedList ()
{
    delete head;
}

void LinkedList::InsertFront (int data)
{
    Node* node = new Node ();
    node->data = data;
    node->next = head;
    head = node;
    this->length++;
}

void LinkedList::InsertBack (int data)
{
    Node* node = new Node ();
    node->data = data;
    node->next = nullptr;

    if (head == nullptr)
    {
        head = node;
    }
    else
    {
        Node* current = head;
        while (current->next != nullptr) current = current->next;
        current->next = node;
    }

    this->length++;
}

void LinkedList::InsertAt (int data, int index)
{
    Node* node = new Node ();
    node->data = data;
    node->next = nullptr;

    if (index == 1)
    {
        node->next = head;
        head = node;
        return;
    }

    Node* current = head;
    for (int i = 0; i < index - 2; i++)
    {
        current = current->next;
    }

    node->next = current->next;
    current->next = node;

    this->length++;
}

void LinkedList::Delete (int index)
{
    Node* current = head;

    if (index == 1)
    {
        head = current->next;
        delete current;
        return;
    }

    // 1. Find node at the position
    for (int i = 0; i < index - 2; i++)
    {
        current = current->next;
    }

    // 2. Fix links
    Node* next = current->next;
    current->next = next->next;

    // 3. Clear memory
    delete next;

    this->length--;
}

void LinkedList::Reverse ()
{
    Node *previous, *current, *next;
    current = this->head;
    previous = nullptr;

    while (current != nullptr)
    {
        next = current->next;
        current->next = previous;

        previous = current;
        current = next;
    }

    this->head = previous;
}

void LinkedList::ReverseRecursion ()
{
    if (head == nullptr)
    {
        return;
    }

    Node* current = this->head;
    StartReverseRecursion (current);
}

void LinkedList::StartReverseRecursion (Node* head)
{
    // Mark last node as head
    if (head->next == nullptr)
    {
        this->head = head;
        //std::cout << head->data << std::endl;
        return;
    }
    StartReverseRecursion (head->next);

    Node* current = head->next;
    //std::cout << current->data << std::endl;

    current->next = head;
    //std::cout << current->data << std::endl;

    head->next = nullptr;
    //std::cout << head->data << std::endl;
}

void LinkedList::PrintRecursion ()
{
    Node* current = this->head;
    StartPrintRecursion (current);
}

void LinkedList::StartPrintRecursion (Node* head)
{
    if (head == nullptr) return;
    std::cout << head->data << " ";
    StartPrintRecursion (head->next);
}

void LinkedList::Print ()
{
    Node* current = this->head;
    while (current)
    {
        std::cout << current->data << ' ';
        current = current->next;
    }
}

int LinkedList::GetLength ()
{
    return this->length;
}

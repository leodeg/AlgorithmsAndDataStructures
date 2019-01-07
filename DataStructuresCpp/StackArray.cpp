#include "StackArray.h"
#include <iostream>

void StackArray::Push (int data)
{
    if (top == ( MAX_SIZE - 1 ))
    {
        std::cout << "StackArray::Error::Stack Overflow" << std::endl;
        return;
    }

    STACK[++top] = data;
}

int StackArray::Pop ()
{
    if (top == -1)
    {
        std::cout << "StackArray::Error::Stack is empty" << std::endl;
        return;
    }

    return STACK[top];
    top--;
}

int StackArray::Peek ()
{
    return STACK[top];
}

void StackArray::Print ()
{
    if (top == -1)
    {
        std::cout << "StackArray::Error::Stack is empty" << std::endl;
        return;
    }

    int count;
    
    std::cout << "Stack: ";
    for (count = 0; count <= top; count++)
    {
        std::cout << STACK[count] << " ";
    }
    std::cout << std::endl;
}

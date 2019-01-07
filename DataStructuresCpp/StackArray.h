#ifndef STACK_ARRAY_H
#define STACK_ARRAY_H
#define MAX_SIZE 101

struct StackArray
{
private:
    int STACK[MAX_SIZE];
    int top = -1;

public:
    void Push (int data);
    int Pop ();
    int Peek ();
    void Print ();
};

#endif // STACK_ARRAY_H

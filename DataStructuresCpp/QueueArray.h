#ifndef QUEUE_ARRAY_H
#define QUEUE_ARRAY_H

class QueueArray
{
private:
    int length = -1;

public:
    void Enqueue (int data);
    void Dequeue ();
    int Peek ();

    void IsEmpty ();
    int GetLength ();
};

#endif

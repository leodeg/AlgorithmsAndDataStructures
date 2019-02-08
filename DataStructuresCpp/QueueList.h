#ifndef QUEUE_LIST_H
#define QUEUE_LIST_H

class QueueList
{
private:
    struct Node
    {
        int data;
        struct Node* next;
    };

    int length;
    Node* first;
    Node* last;

public:
    QueueList ();
    ~QueueList ();

    void Enqueue (int data);
    void Dequeue ();

};

#endif // QUEUE_LIST_H

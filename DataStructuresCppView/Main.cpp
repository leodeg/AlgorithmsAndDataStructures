#include "Libs.h"
#include "LinkedList.h"

void LinkedList_InsertFrontTest ();
void LinkedList_InsertAtPositionTest ();
void LinkedList_DeleteTest ();
void LinkedList_ReverseTest ();
void LinkedList_PrintRecursionTest ();

int main ()
{
    //LinkedList_InsertFrontTest ();
    //LinkedList_InsertAtPositionTest ();
    //LinkedList_DeleteTest ();
    //LinkedList_ReverseTest ();
    //LinkedList_PrintRecursionTest ();

    system ("pause");
    return 0;
}

void LinkedList_InsertFrontTest ()
{
    LinkedList list;
    list.InsertFront (10);
    list.InsertFront (20);
    list.InsertFront (30);
    list.InsertFront (40);

    list.Print ();
}

void LinkedList_InsertAtPositionTest ()
{
    LinkedList list;
    list.InsertBack (1);
    list.InsertBack (2);
    list.InsertBack (3);
    list.InsertBack (4);
    list.InsertAt (101, 3);

    list.Print ();
}

void LinkedList_DeleteTest ()
{
    LinkedList list;
    list.InsertBack (1);
    list.InsertBack (2);
    list.InsertBack (3);
    list.InsertBack (4);

    list.Print ();
    std::cout << "\n";

    list.Delete (2);
    list.Print ();
}

void LinkedList_ReverseTest ()
{
    LinkedList list;
    list.InsertBack (1);
    list.InsertBack (2);
    list.InsertBack (3);
    list.InsertBack (4);

    list.Print ();
    std::cout << "\n";

    list.Reverse ();
    list.Print ();
}

void LinkedList_PrintRecursionTest ()
{
    LinkedList list;
    list.InsertBack (1);
    list.InsertBack (2);
    list.InsertBack (3);
    list.InsertBack (4);

    list.Print ();
    std::cout << "\n";

    list.PrintRecursion ();
    std::cout << "\n";
}

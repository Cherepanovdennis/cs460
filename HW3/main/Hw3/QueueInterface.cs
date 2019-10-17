using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw3
{
    public interface QueueInterface<T>
    {
        T push(T element);
        T pop(); // there are no throw exceptions in C#
        T peek(); // there are not throw exceptions in C#
        bool isEmpty();


    }
}

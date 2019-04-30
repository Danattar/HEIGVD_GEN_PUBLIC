using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServiceContract.Room
{
    public interface IRoomMessage
    {
        string Author { get; }
        string Message { get; }

    }
}

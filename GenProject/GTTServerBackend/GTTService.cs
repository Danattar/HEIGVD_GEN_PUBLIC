using GTTServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServerBackend
{
    class GTTService : IGTTService
    {
        public string TestConnection(int v)
        {
            return "Numéro saisi : " + v.ToString();
        }
    }
}

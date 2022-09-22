using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IMove
    {
        void MoveToNewPosition();
        void MoveToNewPosition(bool input); 
    }    
}

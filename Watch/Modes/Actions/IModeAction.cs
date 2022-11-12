using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.Modes.Actions
{
    public interface IModeAction<TDataType>
    {
        public string Name { get; }
        void Execute(TDataType data);
    }
}

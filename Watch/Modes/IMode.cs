using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.Modes
{
    /// <summary>
    /// Represents the interface for any mode that the Watch holds.
    /// </summary>
    public interface IMode
    {
        public string Name { get; set; }
        public event Action dataChanged;
        public List<string> GetActions();
        public void ActivateAction(string actionName);
        public void ActivateAction(int action);

        public string ToString();
    }
}

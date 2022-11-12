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
        /// <summary>
        /// Invoked when the data is changed.
        /// </summary>
        public event Action dataChanged;
        /// <summary>
        /// Gets a list of actions by order of their indices.
        /// </summary>
        /// <returns>List of ordered strings symbolizing the actions.</returns>
        public List<string> GetActions();
        /// <summary>
        /// Activates an action by name.
        /// </summary>
        /// <param name="actionName"></param>
        public void ActivateAction(string actionName);
        /// <summary>
        /// Activates an action by index.
        /// </summary>
        /// <param name="action"></param>
        public void ActivateAction(int action);

        public string ToString();
    }
}

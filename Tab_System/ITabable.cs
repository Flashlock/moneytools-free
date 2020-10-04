namespace Tab_System
{
    /// <summary>
    /// Any object that can be selected through the tab system
    /// needs to implement this interface.
    /// </summary>
    public interface ITabable
    {
        /// <summary>
        /// The command for this object to perform.
        /// </summary>
        /// <param name="command">
        /// In case of multiple possible commands an integer must be passed.
        /// </param>
        void ReceiveCommand(int command);
    }
}

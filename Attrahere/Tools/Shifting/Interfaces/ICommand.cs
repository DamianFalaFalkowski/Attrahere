namespace Attrahere.Tools
{
    abstract partial class Shifting
    {
        public interface ICommand
        {
            void Execute(RelayParams parameters);
        }
    }  
}

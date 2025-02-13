
namespace FD
{
  
    internal class ListItem
    {
        public required string DisplayText { get; set; } 
        public required object ItemData { get; set; }  

        public override string ToString()
        {
            return DisplayText; 
        }
    }
}

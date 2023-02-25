using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm
{
    public Utm()
    {
        
    }
    
    public Url Url { get; set; }
    public Campaign Campaign { get; set; }
}
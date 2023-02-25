using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core;

public class Utm
{
    public Utm(Url url, Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }
    
    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; }
    
    /// <summary>
    /// Campaing Details
    /// </summary>
    public Campaign Campaign { get; }
    
    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull();
        
        return $"{Url.Address}?{string.Join("&", segments)}";
    } 
}
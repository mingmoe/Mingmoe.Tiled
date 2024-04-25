using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mingmoe.Tiled;

public class Property
{
    [XmlElement("name")]
    public string Name { get; set; } = string.Empty;

    [XmlElement("type")]
    public string Type { get; set; } = string.Empty;

    [XmlElement("propertytype")]
    public string? PropertType { get; set; } = null;

    [XmlElement("value")]
    public string Value { get; set; } = string.Empty;
}

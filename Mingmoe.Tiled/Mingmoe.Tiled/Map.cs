using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Mingmoe.Tiled;

/// <summary>
/// A .tmx file
/// </summary>
[XmlRoot("map")]
public class Map
{
    // base information
    [XmlAttribute("version")]
    public string Version { get; set; } = "1.0";

    [XmlAttribute("tiledversion")]
    public string? TiledVersion { get; set; } = null;

    [XmlAttribute("class")]
    public string? Class { get; set; } = null;

    [XmlAttribute("orientation")]
    public string? Orientation { get; set; } = null;

    [XmlAttribute("renderorder")]
    public string? Renderorder = null;

    [XmlAttribute("compressionlevel")]
    public int CompressionLevel = -1;

    [XmlAttribute("width")]
    public int Width = -1;

    [XmlAttribute("height")]
    public int Height = -1;

    [XmlAttribute("tilewidth")]
    public int TileWidth = -1;

    [XmlAttribute("tileheight")]
    public int TileHeight = -1;

    [XmlAttribute("hexsidelength")]
    public int HexsideLength = -1;

    [XmlAttribute("staggeraxis")]
    public string? StaggerAxis = null;

    [XmlAttribute("staggerindex")]
    public string? StaggerIndex = null;

    [XmlAttribute("parallaxoriginx")]
    public int ParallaxOriginX = -1;

    [XmlAttribute("parallaxoriginy")]
    public int ParallaxOriginY = -1;

    [XmlAttribute("backgroundcolor")]
    public string? BackgroundColor = null;

    [XmlAttribute("nextlayerid")]
    public int NextLayerId = -1;

    [XmlAttribute("nextobjectid")]
    public int NextObjectId = -1;

    /// <summary>
    /// 0 for false and 1 for true.
    /// </summary>
    [XmlAttribute("infinite")]
    public int Infinite = 0;

    // Optional

    [XmlElement("editorsettings")]
    public XmlNode? EditorSettings = null;

    [XmlArray("properties")]
    [XmlArrayItem("property")]
    public Property[] Properties { get; set; } = [];

    [XmlElement("tileset")]
    public TileSet[] Tilesets { get; set; } = [];
}

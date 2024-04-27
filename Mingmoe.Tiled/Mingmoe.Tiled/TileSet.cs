using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Mingmoe.Tiled;

[XmlType("image")]
public class Image
{
    [XmlAttribute("format")]
    public string? Format { get; set; } = null;
    [XmlAttribute("source")]
    public string? Source { get; set; } = null;
    [XmlAttribute("trans")]
    public string? Trans { get; set; } = null;
    [XmlAttribute("width")]
    public string? Width { get; set; } = null;
    [XmlAttribute("height")]
    public string? Height { get; set; } = null;
}

[XmlType("tileoffset")]
public class TileOffset
{
    [XmlAttribute("x")]
    public int X { get; set; } = 0;
    [XmlAttribute("y")]
    public int Y { get; set; } = 0;
}

[XmlType("grid")]
public class Grid
{
    [XmlAttribute("orientation")]
    public string? Orientation { get; set; } = null;
    [XmlAttribute("width")]
    public int Widht { get; set; } = 0;
    [XmlAttribute("height")]
    public int Hidht { get; set; } = 0;
}

[XmlType("tile")]
public class Tile
{
    [XmlAttribute("id")]
    public int Id { get; set; } = 0;
    [XmlAttribute("type")]
    public string? Type { get; set; } = null;
    [XmlAttribute("probability")]
    public int Probability { get; set; } = 0;
    [XmlAttribute("x")]
    public int X { get; set; } = 0;
    [XmlAttribute("y")]
    public int Y { get; set; } = 0;
    [XmlAttribute("width")]
    public int Width { get; set; } = 0;
    [XmlAttribute("height")]
    public int Height { get; set; } = 0;

    [XmlArray("properties")]
    [XmlArrayItem("property")]
    public Property[] Properties { get; set; } = [];

    [XmlElement("image")]
    public Image? Image = null;
}

/// <summary>
/// 图块集
/// </summary>
[XmlType("tileset")]
public class TileSet
{
    [XmlAttribute("firstgid")]
    public string? Firstgid { get; set; } = null;
    [XmlAttribute("source")]
    public string? Source { get; set; } = null;
    [XmlAttribute("name")]
    public string? Name { get; set; } = null;
    [XmlAttribute("class")]
    public string? Class { get; set; } = null;
    [XmlAttribute("tilewidth")]
    public int Tilewidth { get; set; } = 0;
    [XmlAttribute("tileheight")]
    public int Tileheight { get; set; } = 0;
    [XmlAttribute("spacing")]
    public int Spacing { get; set; } = 0;
    [XmlAttribute("margin")]
    public int Margin { get; set; } = 0;
    [XmlAttribute("tilecount")]
    public int Tilecount { get; set; } = 0;
    [XmlAttribute("columns")]
    public int Columns { get; set; } = 0;
    [XmlAttribute("objectalignment")]
    public string? Objectalignment { get; set; } = null;
    [XmlAttribute("tilerendersize")]
    public string? Tilerendersize { get; set; } = null;
    [XmlAttribute("fillmode")]
    public string? Fillmode { get; set; } = null;

    [XmlElement("image")]
    public Image? Image { get; set; } = null;

    [XmlElement("tileoffset")]
    public TileOffset? TileOffset { get; set; }

    [XmlElement("grid")]
    public Grid? Grid { get; set; } = null;

    [XmlElement("transformations")]
    public XmlNode? Transformations { get; set; } = null;

    [XmlElement("wangsets")]
    public XmlNode? Wangsets { get; set; } = null;

    [XmlArray("tile")]
    public Tile[] Tiles { get; set; } = [];

    public (int x, int y) GetPositionOfTile(int id)
    {
        var row = (int)Math.Floor((double)id / Columns);
        var line = id % Columns;

        return (line * Tilewidth, row * Tileheight);
    }

    public static TileSet FromFile(string path)
    {
        XmlSerializer serializer = new(typeof(TileSet));

        using var fs = File.OpenText(path);
        return (TileSet)serializer.Deserialize(fs)!;
    }
}

using System.Xml.Serialization;

namespace Mingmoe.Tiled.Sample;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: [map|tileset] <filename>");
            return;
        }

        Type t;

        if (args[0] == "map")
        {
            t = typeof(Map);
        }
        else if (args[0] == "tileset")
        {
            t = typeof(TileSet);
        }
        else
        {
            Console.WriteLine("Usage: [map|tileset] <filename>");
            return;
        }

        XmlSerializer serializer = new XmlSerializer(t);

        var text = File.ReadAllText(args[1]);

        var obj = serializer.Deserialize(new StringReader(text));

        if (obj is null)
        {
            Console.WriteLine("Failed to deserialize;returns null");
            return;
        }

        Console.WriteLine("parse success");

        {
            using var writer = new StringWriter();
            serializer.Serialize(writer, obj);

            Console.WriteLine("deserialized then serialized:");
            Console.WriteLine(writer.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Utils
{
    public static class XML
    {
        /// <summary>
        /// Create XML file using List<string>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        public static void CretaeXMLDoc(this List<Part> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Part>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using WindowsForms.Shapes;

namespace WindowsForms.TriangleBL
{
    class TriangleBL
    {
        public static void SerializedList(List<Triangle> triangle, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Triangle>));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, triangle);
            }
        }
        public static List<Triangle> DeserializeList()
        {
            XmlSerializer serielizer = new XmlSerializer(typeof(List<Triangle>));
            List<Triangle> list = null;
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                list = (List<Triangle>)serielizer.Deserialize(fileStream);
            }

            if (list == null)
            {
                throw new ApplicationException(string.Format(" ERROR ", path));
            }

            return list;
        }
    }
}

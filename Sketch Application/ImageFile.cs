using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Sketch_Application
{
    class ImageFile
    {
        public string FilePath = "";
        public string FileName = "untitled";
        public bool IsSaved = false;

        public ImageFile() { }

        public bool Save(List<Shape> shapes)
        {
            XmlSerializer serializer = this.GetSerializer(shapes, this.FilePath);

            using (StreamWriter writer = new StreamWriter(this.FilePath))
            {
                serializer.Serialize(writer, shapes);
            }

            return true;
        }

        public void SaveAs(List<Shape> shapes, string path)
        {
            XmlSerializer serializer = this.GetSerializer(shapes, path);

            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, shapes);
            }
        }

        public List<Shape> Open(List<Shape> shapes, string path)
        {
            XmlSerializer serializer = this.GetSerializer(shapes, path);

            using (StreamReader reader = new StreamReader(path))
            {
                return (List<Shape>)serializer.Deserialize(reader);
            }
        }

        private XmlSerializer GetSerializer(List<Shape> shapes, string path)
        {
            this.IsSaved = true;
            this.FileName = Path.GetFileNameWithoutExtension(path);
            this.FilePath = path;

            return new XmlSerializer(shapes.GetType(), new Type[] {
                typeof(FreeLine),
                typeof(Line),
                typeof(Rectangle),
                typeof(Square),
                typeof(Ellipse),
                typeof(Circle),
                typeof(Polygon),
                typeof(GroupedShape)
            });
        }
    }
}

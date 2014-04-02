using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AngielskiNauka
{
    public class Slowko
    {
        public String kategoria;
        public String pl;
        public String ang;

        public Slowko(XElement x)
        {
            //this.kategoria = x.Attribute("kategoria").Value;
            this.kategoria = x.Element("kategoria").Value;
            this.pl = x.Element("polski").Value;
            this.ang = x.Element("angielski").Value;
        }
    }
}

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
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AngielskiNauka
{
    public class SlowkaClass
    {
        public List<Slowko> slowka;

        public SlowkaClass()
        {
            slowka = new List<Slowko>();
            XDocument doc = null;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream storageStream = null;

            if(storage.FileExists("slowka.xml"))
            {
                storageStream = new IsolatedStorageFileStream("slowka.xml", System.IO.FileMode.Open, FileAccess.Read, storage);
                doc = XDocument.Load(storageStream);
                storageStream.Close();
            }
            else
            {
                doc = XDocument.Load("slowka.xml");
                storageStream = new IsolatedStorageFileStream("slowka.xml", System.IO.FileMode.CreateNew, FileAccess.Write, storage);
                doc.Save(storageStream);
                storageStream.Close();

            }

            //var vSlowka = from s in XElement.Load("slowka.xml").Element("slowko").Elements() select s;
            var v = from s in doc.Descendants("slowko") select new Slowko(s);

            slowka.AddRange(v);
        }

    }
}

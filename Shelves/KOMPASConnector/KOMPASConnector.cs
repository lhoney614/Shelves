using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasAPI7;
using Kompas6API5;
using System.Runtime.InteropServices;

namespace APIConnector
{
    public class KOMPASConnector
    {
        private ksDocument3D _doc3D;

        private KompasObject _kompas;

        private ksPart _ksPart;

        public ksDocument3D Doc3D
        {
            get;
            set;
        }

        public KompasObject Kompas
        {
            get;
            set;
        }

        public ksPart KsPart
        {
            get;
            set;
        }

        public KOMPASConnector()
        {
            OpenKompas();
        }

        public void OpenKompas()
        {
            _kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            _kompas.ksMessage("Привет из Компаса!");
        }
    }
}

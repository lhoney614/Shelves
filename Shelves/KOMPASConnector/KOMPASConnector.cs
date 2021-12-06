using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;

namespace APIConnector
{
    public class KompasConnector
    {
        /// <summary>
        /// Переменная, хранящая название программы
        /// </summary>
        private const string ProgId = "KOMPAS.Application.5";

        public KompasObject Kompas { get; set; }

        public ksPart KsPart { get; set; }

        /// <summary>
        /// Конструктор класса KompasConnector
        /// </summary>
        public void OpenKompas()
        {
            try
            {
                //если программа открыта
                Kompas = (KompasObject) Marshal.GetActiveObject(ProgId);
            }
            catch (COMException)
            {
                var t = Type.GetTypeFromProgID(ProgId);
                //если программа еще не открыта
                Kompas = (KompasObject) Activator.CreateInstance(t);
                
            }

            if (Kompas == null) return;

            Kompas.Visible = true;
            Kompas.ActivateControllerAPI();

            var doc3D = (ksDocument3D) Kompas.Document3D();
            doc3D.Create();
            KsPart = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);
        }
    }
}

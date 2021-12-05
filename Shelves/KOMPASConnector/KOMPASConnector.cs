using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;
using System.Threading;

namespace APIConnector
{
    public class KompasConnector
    {
        /// <summary>
        /// Интерфейс создания 3D-документа
        /// </summary>
        private ksDocument3D _doc3D;

        /// <summary>
        /// Интерфейс API Компас-3D
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Интерфейс компонента Компас-3D
        /// </summary>
        private ksPart _ksPart;

        /// <summary>
        /// Переменная, хранящая название программы
        /// </summary>
        private string _progId = "KOMPAS.Application.5";

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

        /// <summary>
        /// Конструктор класса KompasConnector
        /// </summary>
        public KompasConnector()
        {
            try
            {
                //если программа открыта
                _kompas = (KompasObject) Marshal.GetActiveObject(_progId);
            }
            catch (COMException)
            {
                //если программа еще не открыта
                _kompas = (KompasObject) Activator.CreateInstance(Type.GetTypeFromProgID(_progId));

                //Придумать решение, не требующее задержки
                //Костыль, который решает проблему, где апи
                //не успевает полностью подключить,
                //тем самым выбивая NullReferenceException при
                //попытке его использовать
                Thread.Sleep(500);
            }

            _kompas.Visible = true;
            _kompas.ActivateControllerAPI();
        }

        /// <summary>
        /// Метод для создания нового компонента в Компас-3D
        /// </summary>
        public void GetNewPart()
        {
            //получаем указатель на интерфейс документа трехмерной модели
            _doc3D = (ksDocument3D) _kompas.Document3D();
            //создаем документ-модель
            _doc3D.Create();
            //получаем интерфейс модели
            _doc3D = (ksDocument3D) _kompas.ActiveDocument3D();
            //получаем интерфейс компонента в соответствии с заданным типом
            //pTop_Part - это главный компонент, в составе которого
            //находится новый или редактируемый, или указанный компонент
            _ksPart = (ksPart) _doc3D.GetPart((short) Part_Type.pTop_Part);
        }
    }
}

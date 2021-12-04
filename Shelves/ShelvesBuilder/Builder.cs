using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConnector;
using ShelvesParameters;

namespace ShelvesBuilder
{
    public class Builder
    {
        /// <summary>
        /// Коннектор для работы с Компас-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Параметры полок
        /// </summary>
        private Parameters _parameters;

        public void BuildShelves(Parameters param)
        {
            _parameters = param;
            _connector = new KompasConnector();
            _connector.GetNewPart();

            //Левая крайняя дощечка
            CreateVerticalShelf();

            //Задняя дощечка верхней полки
            CreateBackShelf();

            //Нижняя дощечка верхней полки
            CreateDownShelf();

            //Общая дощечка
            CreateVerticalShelf();

            //Задняя дощечка нижней полки
            CreateBackShelf();

            //Нижняя дощечка нижней полки
            CreateDownShelf();

            //Правая крайняя дощечка
            CreateVerticalShelf();
        }

        /// <summary>
        /// Создает заднюю дощечку обеих полок
        /// </summary>
        public void CreateBackShelf()
        {

        }

        /// <summary>
        /// Создает нижнюю дощечку обеих полок
        /// </summary>
        public void CreateDownShelf()
        {

        }

        /// <summary>
        /// Создает вертикальные дощечки:
        /// левую крайнюю, правую крайнюю и общую
        /// </summary>
        public void CreateVerticalShelf()
        {
            //принимает какую-то переменную, 
            //которая варьирует высоту
        }
    }
}

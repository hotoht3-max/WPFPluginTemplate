using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class TeklaComponentService
    {
        /// <summary>
        /// Универсальный метод для вставки соединений (Connection / Seam / Plugin). 
        /// Подходит для стыков (напр. 77, 14), узлов примыкания балок и т.д.
        /// </summary>
        public static bool InsertConnection(string nameOrNumber, string preset, ModelObject primary, List<ModelObject> secondaries, Vector upVector, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(nameOrNumber) || primary == null || secondaries == null || secondaries.Count == 0)
            {
                errorMessage = "Некорректные вводные данные: отсутствует имя компонента или детали.";
                return false;
            }

            try
            {
                Connection conn = new Connection();

                // Магия Tekla API: У компонента всегда должно быть заполнено Name (даже если мы используем Number)
                conn.Name = nameOrNumber;

                if (int.TryParse(nameOrNumber, out int compNum))
                {
                    conn.Number = compNum; // Системный компонент (например, 77)
                }
                else
                {
                    conn.Number = BaseComponent.CUSTOM_OBJECT_NUMBER; // Кастомный компонент или плагин (-100000)
                }

                // Пресет загружается строго после присвоения имени и номера!
                if (!string.IsNullOrWhiteSpace(preset))
                {
                    conn.LoadAttributesFromFile(preset);
                }

                if (upVector != null)
                {
                    conn.UpVector = upVector;
                }

                conn.SetPrimaryObject(primary);
                foreach (var sec in secondaries)
                {
                    conn.SetSecondaryObject(sec);
                }

                if (!conn.Insert())
                {
                    errorMessage = "Tekla API вернул false. Возможные причины: несовместимые профили, неверный пресет, или компонент не является Connection.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Задел на будущее: Универсальный метод для вставки Деталей (Detail).
        /// Подходит для опорных плит (напр. 1042), ребер жесткости и т.д.
        /// </summary>
        public static bool InsertDetail(string nameOrNumber, string preset, ModelObject primary, Point position, Vector upVector, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                Detail detail = new Detail();
                detail.Name = nameOrNumber;

                if (int.TryParse(nameOrNumber, out int num)) detail.Number = num;
                else detail.Number = BaseComponent.CUSTOM_OBJECT_NUMBER;

                if (!string.IsNullOrWhiteSpace(preset)) detail.LoadAttributesFromFile(preset);
                if (upVector != null) detail.UpVector = upVector;

                detail.SetPrimaryObject(primary);
                detail.SetReferencePoint(position);

                if (!detail.Insert())
                {
                    errorMessage = "Tekla API вернул false при вставке Detail.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
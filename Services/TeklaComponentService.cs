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
                conn.Name = nameOrNumber;

                if (int.TryParse(nameOrNumber, out int compNum)) conn.Number = compNum;
                else conn.Number = BaseComponent.CUSTOM_OBJECT_NUMBER;

                if (upVector != null) conn.UpVector = upVector;

                conn.SetPrimaryObject(primary);
                foreach (var sec in secondaries)
                {
                    conn.SetSecondaryObject(sec);
                }

                // 1. ВСТАВЛЯЕМ УЗЕЛ В МОДЕЛЬ
                // В этот момент Текла агрессивно применяет Автостандарты (класс 0, пустой код)
                if (!conn.Insert())
                {
                    errorMessage = "Tekla API вернул false при вставке компонента.";
                    return false;
                }

                // 2. POST-MODIFY: ПЕРЕБИВАЕМ АВТОСТАНДАРТЫ
                if (!string.IsNullOrWhiteSpace(preset))
                {
                    // Накатываем пресет поверх уже созданного узла
                    conn.LoadAttributesFromFile(preset);

                    // Имплементируем твою идею: Жестко глушим Автостандарты
                    conn.SetAttribute("ac_root", "albl_no_root");
                    conn.SetAttribute("ad_root", "albl_no_root");

                    // Достаем спрятанный класс (group_no) и инъектируем его
                    int classValue = 0;
                    if (conn.GetAttribute("group_no", ref classValue))
                    {
                        conn.SetAttribute("class", classValue);
                        conn.SetAttribute("group_no", classValue);
                    }

                    // Принудительно применяем изменения к узлу в модели
                    conn.Modify();
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
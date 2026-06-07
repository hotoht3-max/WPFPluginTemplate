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
                    conn.SetAttribute("ac_root", 0);
                    conn.SetAttribute("ad_root", 0);

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
        public static bool InsertDetail(string componentName, string attributeFile, ModelObject primaryObject, Point referencePoint, Vector upVector, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                Detail detail = new Detail();

                // Распознавание системного номера макроса или его имени
                if (int.TryParse(componentName, out int compNumber))
                {
                    detail.Number = compNumber;
                }
                else
                {
                    detail.Name = componentName;
                }

                detail.SetPrimaryObject(primaryObject);
                detail.SetReferencePoint(referencePoint);

                if (upVector != null)
                {
                    detail.UpVector = upVector;
                }

                // 1. Загружаем пресет до вставки
                if (!string.IsNullOrWhiteSpace(attributeFile))
                {
                    detail.LoadAttributesFromFile(attributeFile);
                }

                if (!detail.Insert())
                {
                    errorMessage = "Не удалось вставить торцевой компонент (Insert вернул false).";
                    return false;
                }

                // 2. ГАРАНТИРОВАННАЯ ЗАПИСЬ ПРЕСЕТА (Обход Автостандартов)
                // Выполняем повторную подгрузку и Modify() после создания объекта в БД
                if (!string.IsNullOrWhiteSpace(attributeFile))
                {
                    detail.LoadAttributesFromFile(attributeFile);
                    detail.Modify();
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
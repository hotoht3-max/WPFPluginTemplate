using System;
using System.Collections.Generic;
using System.Linq;
using Tekla.Extension; // <--- ОБЯЗАТЕЛЬНО ДОБАВЛЯЕМ

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class StringParserService
    {
        // 1. ПАРСЕР ШАГОВ (Заменен на мощь Tekla.Extension)
        public static List<double> ParseManualStep(string input)
        {
            var steps = new List<double>();
            if (string.IsNullOrWhiteSpace(input)) return steps;

            try
            {
                // Метод GetDistances сам распарсит "3*200 150" и переведет в [200, 200, 200, 150]
                steps = input.GetDistances().ToList();
            }
            catch
            {
                // Защита: если ввели абракадабру, вернем пустой список, чтобы колонна не упала
            }

            return steps;
        }

        // Теперь принимает абсолютные отметки начала и конца зоны решетки
        public static List<double> ParseCountAndElevation(string input, double startElev, double endElev)
        {
            var steps = new List<double>();
            if (string.IsNullOrWhiteSpace(input)) return steps;

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double currentElev = startElev;
            int i = 0;

            while (i < tokens.Length)
            {
                if (int.TryParse(tokens[i], out int count))
                {
                    i++;
                    double targetElev = endElev;

                    if (i < tokens.Length && double.TryParse(tokens[i], out double parsedElev))
                    {
                        targetElev = Math.Min(parsedElev, endElev);
                        i++;
                    }

                    double zoneLen = targetElev - currentElev;
                    if (zoneLen > 0 && count > 0)
                    {
                        if (count == 1) steps.Add(zoneLen);
                        else
                        {
                            double roundedStep = Math.Round((zoneLen / count) / 10.0) * 10.0;
                            if (roundedStep <= 0) roundedStep = 10.0;

                            for (int j = 0; j < count - 1; j++) steps.Add(roundedStep);
                            steps.Add(zoneLen - (roundedStep * (count - 1)));
                        }
                    }
                    currentElev = targetElev;
                }
                else i++;
            }
            return steps;
        }

        public static HashSet<int> ParseNodes(string input, int maxNodes)
        {
            var nodes = new HashSet<int>();
            if (string.IsNullOrWhiteSpace(input)) return nodes;

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int nodeIndex) && nodeIndex >= 1 && nodeIndex <= maxNodes)
                {
                    nodes.Add(nodeIndex - 1);
                }
            }
            return nodes;
        }

        // Парсер отметок стыков ветвей
        public static List<double> ParseSplices(string input)
        {
            var splices = new List<double>();
            if (string.IsNullOrWhiteSpace(input)) return splices;

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double val)) splices.Add(val);
            }
            return splices;
        }

        // Парсер исключений расцентровок (Узел:Вверх/Вниз)
        public static Dictionary<int, (double Up, double Down)> ParseRascOverrides(string input, int maxNodes)
        {
            var dict = new Dictionary<int, (double Up, double Down)>();
            if (string.IsNullOrWhiteSpace(input)) return dict;

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (token.Contains(":"))
                {
                    var parts = token.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int nodeIndex))
                    {
                        int idx = nodeIndex - 1;
                        if (idx >= 0 && idx < maxNodes)
                        {
                            var vals = parts[1].Split('/');
                            if (vals.Length == 2 && double.TryParse(vals[0], out double up) && double.TryParse(vals[1], out double down))
                            {
                                dict[idx] = (up, down);
                            }
                            else if (vals.Length == 1 && double.TryParse(vals[0], out double val))
                            {
                                dict[idx] = (val, val); // Если указано одно число (например для базы)
                            }
                        }
                    }
                }
            }
            return dict;
        }
    }
}
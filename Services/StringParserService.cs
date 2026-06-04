using System;
using System.Collections.Generic;
using System.Linq;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class StringParserService
    {
        // 1. ПАРСЕР МАССИВОВ (Альфа 1.1) - Строгий и рабочий
        public static List<double> ParseManualStep(string input)
        {
            var steps = new List<double>();
            if (string.IsNullOrWhiteSpace(input)) return steps;

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (token.Contains("*"))
                {
                    var parts = token.Split('*');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int count) && double.TryParse(parts[1], out double val))
                    {
                        for (int i = 0; i < count; i++) steps.Add(val);
                    }
                }
                else if (double.TryParse(token, out double val)) steps.Add(val);
            }
            return steps;
        }

        // 2. УНИВЕРСАЛЬНЫЙ ПАРСЕР УЗЛОВ (Поддерживает N-N)
        public static HashSet<int> ParseNodes(string input, int maxNodes)
        {
            var nodes = new HashSet<int>();
            if (string.IsNullOrWhiteSpace(input)) return nodes;

            var tokens = input.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (token.Contains("-"))
                {
                    var parts = token.Split('-');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int start) && int.TryParse(parts[1], out int end))
                    {
                        int min = Math.Min(start, end);
                        int max = Math.Max(start, end);
                        for (int i = min; i <= max; i++)
                        {
                            if (i >= 1 && i <= maxNodes) nodes.Add(i - 1);
                        }
                    }
                }
                else if (int.TryParse(token, out int nodeIndex) && nodeIndex >= 1 && nodeIndex <= maxNodes)
                {
                    nodes.Add(nodeIndex - 1);
                }
            }
            return nodes;
        }

        // 3. ПАРСЕР СТЫКОВ ВЕТВЕЙ
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

        // 4. ПАРСЕР РАСЦЕНТРОВОК (Поддерживает диапазоны N-N:50/100)
        public static Dictionary<int, (double Up, double Down)> ParseRascOverrides(string input, int maxNodes)
        {
            var dict = new Dictionary<int, (double Up, double Down)>();
            if (string.IsNullOrWhiteSpace(input)) return dict;

            var tokens = input.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (token.Contains(":"))
                {
                    var parts = token.Split(':');
                    if (parts.Length == 2)
                    {
                        var nodesDef = parts[0];
                        var vals = parts[1].Split('/');
                        double up = 0, down = 0;
                        bool validVals = false;

                        if (vals.Length == 2 && double.TryParse(vals[0], out up) && double.TryParse(vals[1], out down))
                            validVals = true;
                        else if (vals.Length == 1 && double.TryParse(vals[0], out double val))
                        {
                            up = down = val;
                            validVals = true;
                        }

                        if (validVals)
                        {
                            if (nodesDef.Contains("-"))
                            {
                                var rangeParts = nodesDef.Split('-');
                                if (rangeParts.Length == 2 && int.TryParse(rangeParts[0], out int start) && int.TryParse(rangeParts[1], out int end))
                                {
                                    int min = Math.Min(start, end);
                                    int max = Math.Max(start, end);
                                    for (int i = min; i <= max; i++)
                                    {
                                        int idx = i - 1;
                                        if (idx >= 0 && idx < maxNodes) dict[idx] = (up, down);
                                    }
                                }
                            }
                            else if (int.TryParse(nodesDef, out int nodeIndex))
                            {
                                int idx = nodeIndex - 1;
                                if (idx >= 0 && idx < maxNodes) dict[idx] = (up, down);
                            }
                        }
                    }
                }
            }
            return dict;
        }
    }
}
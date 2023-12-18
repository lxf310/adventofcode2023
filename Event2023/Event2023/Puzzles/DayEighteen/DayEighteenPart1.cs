namespace Event2023.Puzzles.DayEighteen
{
    public class DayEighteenPart1
    {
        private Tuple<int, int> dToI(string direction)
        {
            return direction switch
            {
                "U" => new Tuple<int, int>(-1, 0),
                "R" => new Tuple<int, int>(0, 1),
                "D" => new Tuple<int, int>(1, 0),
                "L" => new Tuple<int, int>(0, -1),
            };
        }

        public int Total(List<string> inputs)
        {
            var mp = 0;
            var np = 0;

            var mn = 0;
            var nn = 0;

            var r = 0;
            var c = 0;

            var steps = new List<Step>();

            var firstStep = new Step
            {
                Row = 0,
                Col = 0,
            };

            var meetFirst = false;
            foreach (var line in inputs)
            {
                var l = line.Split(' ');

                var walk = dToI(l[0]);
                if (string.IsNullOrEmpty(firstStep.Direction))
                {
                    firstStep.Direction = l[0];
                }

                for (int k = 1; k <= int.Parse(l[1]); k++)
                {
                    r += walk.Item1;
                    c += walk.Item2;

                    //Console.WriteLine($"({r}, {c})");

                    if (l[0] == "U" || l[0] == "D")
                    {
                        if (steps.Any())
                        {
                            if (steps.Last().Direction == "R" || steps.Last().Direction == "L")
                            {
                                steps.Last().Direction = l[0];
                            }
                        }
                    }


                    steps.Add(new Step
                    {
                        Row = r,
                        Col = c,
                        Direction = l[0]
                    });

                    if (r == 0 && c == 0)
                    {
                        meetFirst = true;
                    }
                }
                mp = Math.Max(r, mp);
                np = Math.Max(c, np);

                mn = Math.Min(r, mn);
                nn = Math.Min(c, nn);
            }

            if (!meetFirst)
            {
                if (steps.Last().Row != firstStep.Row)
                {
                    firstStep.Direction = steps.Last().Direction;
                }
                steps.Add(firstStep);
            }

            var maps = new List<List<Point>>();
            var m = mp - mn;
            var n = np - nn;
            for (int i = 0; i <= m; i++)
            {
                maps.Add(new List<Point>());
                for (int j = 0; j <= n; j++)
                {
                    maps.Last().Add(new Point());
                }
            }

            var rmid = -mn;
            var cmid = -nn;
            var boundary = new HashSet<string>();
            foreach (var step in steps)
            {
                var rr = rmid + step.Row;
                var cc = cmid + step.Col;
                maps[rmid + step.Row][cmid + step.Col].Type = '#';
                maps[rmid + step.Row][cmid + step.Col].Direction = step.Direction;
                boundary.Add($"{rr}_{cc}");
            }

            //for (int i = 0; i <= m; i++)
            //{
            //    for (int j = 0; j <= n; j++)
            //    {
            //        Console.Write($"{maps[i][j].Type}({maps[i][j].Direction})");
            //    }
            //    Console.WriteLine();
            //}

            var outside = new HashSet<string>();
            for (int i = 0; i <= m; i++)
            {
                var isIn = false;
                string pre = null;
                for (int j = 0; j <= n; j++)
                {
                    var step = maps[i][j];
                    if (step.Type == '#')
                    {
                        if (step.Direction == "U")
                        {
                            if (pre == null)
                            {
                                isIn = true;
                            }
                            else if (pre == "D")
                            {
                                isIn = !isIn;
                            }
                            pre = "U";
                        }
                        else if (step.Direction == "D")
                        {
                            if (pre == null)
                            {
                                isIn = true;
                            }
                            else if (pre == "U")
                            {
                                isIn = !isIn;
                            }
                            pre = "D";
                        }
                    }
                    else
                    {
                        if (!isIn)
                        {
                            if (!boundary.Contains($"{i}_{j}"))
                            {
                                maps[i][j].Type = '*';
                            }
                            outside.Add($"{i}_{j}");
                        }
                    }
                }
            }

            //Console.WriteLine();

            //for (int i = 0; i <= m; i++)
            //{
            //    for (int j = 0; j <= n; j++)
            //    {
            //        Console.Write($"{maps[i][j].Type}({maps[i][j].Direction})");
            //    }
            //    Console.WriteLine();
            //}

            return (m + 1) * (n + 1) - outside.Select(x => !boundary.Contains(x)).Count();
        }
    }
}

namespace Event2023.Puzzles.DaySixteen
{
    public class DaySixteenPart1
    {
        private int dr(char d)
        {
            return d switch
            {
                'R' => 0,
                'L' => 0,
                'U' => -1,
                'D' => 1,
            };
        }

        private int dc(char d)
        {
            return d switch
            {
                'R' => 1,
                'L' => -1,
                'U' => 0,
                'D' => 0,
            };
        }

        public int score(List<string> inputs, Light start, int m, int n)
        {
            var lights = new List<Light>
            {
                start
            };

            var seen1 = new HashSet<string>();
            var seen2 = new HashSet<string>();

            while (lights.Any())
            {
                var newLights = new List<Light>();
                foreach (var light in lights)
                {
                    if (light.Row >= 0 && light.Row < m && light.Col >= 0 && light.Col < n)
                    {
                        seen1.Add(light.Key1);
                        if (seen2.Contains(light.Key2))
                        {
                            continue;
                        }
                        seen2.Add(light.Key2);
                        var ch = inputs[light.Row][light.Col];
                        if (ch == '.')
                        {
                            newLights.Add(new Light
                            {
                                Direction = light.Direction,
                                Row = light.Row + dr(light.Direction),
                                Col = light.Col + dc(light.Direction)
                            });
                        }
                        else if (ch == '-')
                        {
                            if (light.Direction == 'R' || light.Direction == 'L')
                            {
                                newLights.Add(new Light
                                {
                                    Direction = light.Direction,
                                    Row = light.Row + dr(light.Direction),
                                    Col = light.Col + dc(light.Direction)
                                });
                            }
                            else
                            {
                                newLights.Add(new Light
                                {
                                    Direction = 'R',
                                    Row = light.Row + dr('R'),
                                    Col = light.Col + dc('R')
                                });

                                newLights.Add(new Light
                                {
                                    Direction = 'L',
                                    Row = light.Row + dr('L'),
                                    Col = light.Col + dc('L')
                                });
                            }
                        }
                        else if (ch == '|')
                        {
                            if (light.Direction == 'U' || light.Direction == 'D')
                            {
                                newLights.Add(new Light
                                {
                                    Direction = light.Direction,
                                    Row = light.Row + dr(light.Direction),
                                    Col = light.Col + dc(light.Direction)
                                });
                            }
                            else
                            {
                                newLights.Add(new Light
                                {
                                    Direction = 'U',
                                    Row = light.Row + dr('U'),
                                    Col = light.Col + dc('U')
                                });

                                newLights.Add(new Light
                                {
                                    Direction = 'D',
                                    Row = light.Row + dr('D'),
                                    Col = light.Col + dc('D')
                                });
                            }
                        }
                        else if (ch == '/')
                        {
                            var d = light.Direction switch
                            {
                                'R' => 'U',
                                'L' => 'D',
                                'U' => 'R',
                                'D' => 'L'
                            };

                            newLights.Add(new Light
                            {
                                Direction = d,
                                Row = light.Row + dr(d),
                                Col = light.Col + dc(d)
                            });
                        }
                        else if (ch == '\\')
                        {
                            var d = light.Direction switch
                            {
                                'R' => 'D',
                                'L' => 'U',
                                'U' => 'L',
                                'D' => 'R'
                            };

                            newLights.Add(new Light
                            {
                                Direction = d,
                                Row = light.Row + dr(d),
                                Col = light.Col + dc(d)
                            });
                        }
                    }
                }

                lights = newLights;
            }

            return seen1.Count;
        }

        public int Total(List<string> inputs, bool isPart2 = false)
        {
            var m = inputs.Count;
            var n = inputs[0].Length;

            if (!isPart2)
            {
                return score(inputs, new Light
                {
                    Direction = 'R',
                    Row = 0,
                    Col = 0
                }, m, n);
            }

            var ret = 0;
            for (int i = 0; i < m; i++)
            {
                ret = Math.Max(ret, score(inputs, new Light
                {
                    Row = i,
                    Col = 0,
                    Direction = 'R'
                }, m, n));

                ret = Math.Max(ret, score(inputs, new Light
                {
                    Row = i,
                    Col = n - 1,
                    Direction = 'L'
                }, m, n));
            }

            for (int j = 0; j < n; j++)
            {
                ret = Math.Max(ret, score(inputs, new Light
                {
                    Row = 0,
                    Col = j,
                    Direction = 'D'
                }, m, n));

                ret = Math.Max(ret, score(inputs, new Light
                {
                    Row = m - 1,
                    Col = j,
                    Direction = 'U'
                }, m, n));
            }

            return ret;
        }
    }
}

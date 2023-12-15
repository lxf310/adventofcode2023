namespace Event2023.Puzzles.DayFifteen
{
    public class DayFifteenPart2 : DayFifteenBase
    {
        private void move(string step, List<List<Tuple<string, int>>> boxes)
        {
            if (step.EndsWith('-'))
            {
                var label = step.Substring(0, step.Length - 1);
                var code = hash(label);
                boxes[code].Remove(boxes[code].SingleOrDefault(x => x.Item1 == label));
            }
            else
            {
                var temp = step.Split('=');
                var label = temp[0];
                var length = int.Parse(temp[1]);
                var code = hash(label);
                int i = 0;
                for (; i < boxes[code].Count; i++)
                {
                    if (boxes[code][i].Item1 == label)
                    {
                        break;
                    }
                }

                if (i == boxes[code].Count)
                {
                    boxes[code].Add(new Tuple<string, int>(label, length));
                }
                else
                {
                    boxes[code].RemoveAt(i);
                    boxes[code].Insert(i, new Tuple<string, int>(label, length));
                }
            }
        }

        private int count(List<List<Tuple<string, int>>> boxes)
        {
            var cnt = 0;
            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = 0; j < boxes[i].Count; j++)
                {
                    cnt += (i + 1) * (j + 1) * boxes[i][j].Item2;
                }
            }

            return cnt;
        }

        public int Total(List<string> inputs)
        {
            var boxes = new List<List<Tuple<string, int>>>();
            for (int i = 0; i < 256; i++)
            {
                boxes.Add(new List<Tuple<string, int>>());
            }

            var steps = inputs[0].Split(',').Where(x => !string.IsNullOrWhiteSpace(x));
            foreach (var step in steps)
            {
                move(step, boxes);
            }

            var ret = count(boxes);
            return ret;
        }
    }
}

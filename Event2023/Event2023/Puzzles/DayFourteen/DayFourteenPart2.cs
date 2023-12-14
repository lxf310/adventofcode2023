using System.Text;

namespace Event2023.Puzzles.DayFourteen
{
    public class DayFourteenPart2
    {
        private void rollN(List<List<char>> src)
        {
            var m = src.Count;
            var n = src[0].Count;

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int k = i; k > 0; k--)
                    {
                        if (src[k][j] == 'O' && src[k - 1][j] == '.')
                        {
                            src[k - 1][j] = 'O';
                            src[k][j] = '.';
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void rollW(List<List<char>> src)
        {
            var m = src.Count;
            var n = src[0].Count;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (src[i][j] == 'O')
                    {
                        for (int k = j; k > 0; k--)
                        {
                            if (src[i][k] == 'O' && src[i][k - 1] == '.')
                            {
                                src[i][k - 1] = 'O';
                                src[i][k] = '.';
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void rollS(List<List<char>> src)
        {
            var m = src.Count;
            var n = src[0].Count;
            for (int j = 0; j < n; j++)
            {
                for (int i = m - 1; i >= 0; i--)
                {
                    for (int k = i; k < m - 1; k++)
                    {
                        if (src[k][j] == 'O' && src[k + 1][j] == '.')
                        {
                            src[k + 1][j] = 'O';
                            src[k][j] = '.';
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void rollE(List<List<char>> src)
        {
            var m = src.Count;
            var n = src[0].Count;
            for (int i = 0; i < m; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    for (int k = j; k < n - 1; k++)
                    {
                        if (src[i][k] == 'O' && src[i][k + 1] == '.')
                        {
                            src[i][k + 1] = 'O';
                            src[i][k] = '.';
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private int score(List<List<char>> src)
        {
            var m = src.Count;
            var n = src[0].Count;
            var ret = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (src[i][j] == 'O')
                    {
                        ret += (m - i);
                    }
                }
            }

            return ret;
        }

        private List<List<char>> convert(List<string> inputs)
        {
            var des = new List<List<char>>();
            var m = inputs.Count;
            var n = inputs[0].Length;
            for (int i = 0; i < m; i++)
            {
                des.Add(new List<char>());
                for (int j = 0; j < n; j++)
                {
                    des.Last().Add(inputs[i][j]);
                }
            }

            return des;
        }

        private string getKey(List<List<char>> src)
        {
            var build = new StringBuilder();
            var m = src.Count;
            var n = src[0].Count;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    build.Append($"{i}_{j}_{src[i][j]}");
                }
            }
            return build.ToString();
        }

        public int Total(List<string> inputs)
        {
            var cnt = 0;
            var total = 1000000000;
            var src = convert(inputs);
            var memo = new Dictionary<string, int>();

            while (cnt < total)
            {
                cnt++;
                rollN(src);

                rollW(src);

                rollS(src);

                rollE(src);

                var key = getKey(src);
                if (memo.ContainsKey(key))
                {
                    var len = cnt - memo[key];
                    var aim = (total - cnt) / len;
                    cnt += aim * len;
                    memo[key] = cnt;
                }
                else
                {
                    memo.Add(key, cnt);
                }
            }

            var ret = score(src);
            return ret;
        }
    }
}

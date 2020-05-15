using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
namespace CTask1
{
    class FileManager
    {
        private const int RequiredSymbolsCount = 3;
        public Round Reader(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                char[] definitions = {',', ' ', '.', ':'};
                String[] temp = sr.ReadToEnd().Split(definitions, StringSplitOptions.RemoveEmptyEntries);

                

                if (temp.Length != RequiredSymbolsCount)
                {
                    throw new Exception("3 numbers required");
                }

                if (double.TryParse(temp[0], out double x))
                {
                    if (float.TryParse(temp[1], out float y))
                    {
                        if (float.TryParse(temp[2], out float radius))
                        {
                            if (radius > 0)
                            {
                                return new Round(radius, new Point(x, y));
                            }
                            else
                            {
                                throw new ArgumentException("Raduis can't be less or equal 0");
                            }
                        }
                    }
                }
            }
            throw new ArgumentException("Data can't be parsed(values is not correct)");
        }

        public void Writer(Round round, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Center cordinates: " + round.Center.X + " " + round.Center.Y);
                sw.WriteLine("Radius length: " + round.Radius);
                sw.WriteLine("Length of round: " + round.RoundLength());
                sw.WriteLine("Area of round: " + round.RoundArea());
            }
        }
    }
}

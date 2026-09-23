
namespace BibleBooksNE.Model.VerseTypes
{
    internal class Counters
    {
        public long[] Values { get; } = [-1, 0, 0, 0, 0, 0, 0, 0];

        public Counters(long headLines, long verses, long crosslinks, long footnotes, long wordList, long audios)
        {
            Values[1] = headLines;
            Values[2] = verses;
            Values[3] = crosslinks;
            Values[4] = footnotes;
            Values[5] = wordList;
            Values[6] = audios;
            Values[7] = Count();
        }

        public Counters(int bibleId, Counters counter)
        {
            Values[0] = bibleId;
            Values[1] = counter.Values[1];
            Values[2] = counter.Values[2];
            Values[3] = counter.Values[3];
            Values[4] = counter.Values[4];
            Values[5] = counter.Values[5];
            Values[6] = counter.Values[6];
            Values[7] = counter.Values[7];
        }

        public static Counters Count(Counters[] counters)
        {
            long[] array = [0, 0, 0, 0, 0, 0];

            for (int i = 0; i < array.Length; i++)
            {
                foreach (Counters item in counters)
                {
                    array[i] += item.Values[i + 1];
                }
            }
            return new Counters(counters.Length, new Counters(array[0], array[1], array[2], array[3], array[4], array[5]));
        }

        private long Count()
        {
            return Values[1] + Values[2] + Values[3] + Values[4] + Values[5] + Values[6];
        }

        public override string ToString()
        {
            return string.Join(", ", Values);
        }
    }
}
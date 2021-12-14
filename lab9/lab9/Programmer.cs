using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class Programmer
        {
            public delegate void RemoveDelegate(string message, List<int> labs);
            public delegate void MutateDelegate(string message, List<int> labs);
            public event RemoveDelegate Remove;
            public event MutateDelegate Mutate;
            public Programmer(List<int> labs)
            {
                Labs = labs;
            }
            public List<int> Labs { get; private set; }
            public void Add(List<int> labs)
            {
                Labs = Labs.Concat(labs).ToList();
                Remove?.Invoke($"Лабы добавлены", labs);
            }

            public void RemoveLabs(List<int> labs)
            {
                foreach (int elem in labs) { Labs.Remove(elem); }
                Mutate?.Invoke($"Списанные лабы удалены", labs);
            }
        }
}

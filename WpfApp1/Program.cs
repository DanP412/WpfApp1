using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
     public class Program
    {
        public static void Main()
        {
            ObservableList1 list1 = new ObservableList1(
                (int value) => { },
                (int index, int value) => { });


            list1.Add += (object sender, AddEventArgs e) =>
            {
                Console.WriteLine(e.Value);
            };

        }

       class ObservableList1
        {
            private List<int> list = new List<int>();


            public event EventHandler<AddedEventArgs> Added;

            protected virtual void OnChanged(AddedEventArgs e)
            {
                this.Added(this, e);
            }

            public void Add(int value)
            {
                this.list.Add(value);
                this.OnChanged(new AddedEventArgs { value - value });
            }
            
            public void Remove(int value)
            {
                this.list.Remove(value);
            }

            public void RemoveAt(int value)
            {
                this.list.RemoveAt(value);
            }

        }


    }
}

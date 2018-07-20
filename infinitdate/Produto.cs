
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace infinitdate
{
 public class Produto
    {
        public long Id;
        public string Name;
        public bool IsComplete;

        public Produto() { }
 
        public Produto(long Id, string Name, bool IsComplete)
        {
            this.Id = Id;
            this.Name = Name;
            this.IsComplete = IsComplete;
        }
    }
}
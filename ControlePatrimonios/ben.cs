//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlePatrimonios
{
    using System;
    using System.Collections.Generic;
    
    public partial class ben
    {
        public ben()
        {
            this.patrimonios = new HashSet<patrimonio>();
        }
    
        public int idBem { get; set; }
        public string descBem { get; set; }
        public int idCategoria { get; set; }
    
        public virtual categoria categoria { get; set; }
        public virtual ICollection<patrimonio> patrimonios { get; set; }
    }
}

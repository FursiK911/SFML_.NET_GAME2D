//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magazin_for_game
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int id { get; set; }
        public int idBuyer { get; set; }
        public int idItem { get; set; }
        public int NumberItems { get; set; }
        public System.DateTime DataPurchase { get; set; }
    
        public virtual Items Items { get; set; }
        public virtual Player Players { get; set; }
    }
}
﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class shop_in_gameContext : DbContext
    {
        public shop_in_gameContext()
            : base("name=shop_in_gameContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ItemSets> ItemSets { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<RarityItem> RarityItems { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<TypeItem> TypeItems { get; set; }
    }
}

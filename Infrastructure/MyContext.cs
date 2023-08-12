using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public virtual DbSet<Users> TBL_Users { get; set; }
        public virtual DbSet<TeamStats> TBL_TeamStats { get; set; }
        public virtual DbSet<Team> TBL_Team { get; set; }
        public virtual DbSet<SoccerInfo> TBL_SoccerInfo { get; set; }
        public virtual DbSet<Role> TBL_Role { get; set; }
        public virtual DbSet<ProductCategory> TBL_ProductCategory { get; set; }
        public virtual DbSet<Product> TBL_Product { get; set; }
        public virtual DbSet<PlayerStats> TBL_PlayerStats { get; set; }
        public virtual DbSet<PlayerImages> TBL_PlayerImages { get; set; }
        public virtual DbSet<PlayerAchievement> TBL_PlayerAchievement { get; set; }
        public virtual DbSet<Player> TBL_Player { get; set; }
        public virtual DbSet<OrderItem> TBL_OrderItem { get; set; }
        public virtual DbSet<Order> TBL_Order { get; set; }
        public virtual DbSet<MatchStats> TBL_MatchStats { get; set; }
        public virtual DbSet<Matches> TBL_Matches { get; set; }
        public virtual DbSet<Competition> TBL_Competition { get; set; }
        public virtual DbSet<ClubHistory> TBL_ClubHistory { get; set; }
        public virtual DbSet<Cart> TBL_Cart { get; set; }
        public virtual DbSet<ContactUs> TBL_ContactUs { get; set; }
        public virtual DbSet<UserAddresses> TBL_UserAddresses { get; set; }
        public virtual DbSet<Feedback> TBL_Feedback { get; set; }
        public virtual DbSet<News> TBL_News { get; set; }


    }

}

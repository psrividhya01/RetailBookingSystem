using Microsoft.EntityFrameworkCore;
using Retail_Backend.model;

namespace Retail_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Core tables
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<LoyaltyPoints> LoyaltyPoints { get; set; }

        // Feature tables
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<OrderTracking> OrderTrackings { get; set; }
        public DbSet<Slideshow> Slideshows { get; set; }
        public DbSet<AdminActivityLog> AdminActivityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- User ----------
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("Customer");

            // ---------- User → Cart (1:1) ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → Wishlist (1:1) ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.Wishlist)
                .WithOne(w => w.User)
                .HasForeignKey<Wishlist>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → LoyaltyPoints (1:1) ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.LoyaltyPoints)
                .WithOne(lp => lp.User)
                .HasForeignKey<LoyaltyPoints>(lp => lp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → Addresses (1:N) ----------
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → Orders (1:N) ----------
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- Order → Address (N:1) ----------
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany()
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- Order → Offer (N:1, optional) ----------
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Offer)
                .WithMany()
                .HasForeignKey(o => o.OfferId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Order → Payment (1:1) ----------
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Order → OrderItems (1:N) ----------
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Order → OrderTracking (1:N) ----------
            modelBuilder.Entity<OrderTracking>()
                .HasOne(ot => ot.Order)
                .WithMany(o => o.TrackingHistory)
                .HasForeignKey(ot => ot.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- MenuItem → Category (N:1) ----------
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Category)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- MenuItem → OrderItem ----------
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- MenuItem → CartItem ----------
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.MenuItem)
                .WithMany()
                .HasForeignKey(ci => ci.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- MenuItem → WishlistItem ----------
            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.MenuItem)
                .WithMany()
                .HasForeignKey(wi => wi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- MenuItem → Reviews (1:N) ----------
            modelBuilder.Entity<Review>()
                .HasOne(r => r.MenuItem)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → Reviews (1:N) ----------
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- Cart → CartItems (1:N) ----------
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Wishlist → WishlistItems (1:N) ----------
            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.Wishlist)
                .WithMany(w => w.WishlistItems)
                .HasForeignKey(wi => wi.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → Notifications (1:N) ----------
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- User → EmailLogs (1:N) ----------
            modelBuilder.Entity<EmailLog>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- AdminActivityLog → User (Admin) ----------
            modelBuilder.Entity<AdminActivityLog>()
                .HasOne(a => a.Admin)
                .WithMany()
                .HasForeignKey(a => a.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- Decimal precision ----------
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.DiscountPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Rating)
                .HasColumnType("decimal(3,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.DiscountAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.FinalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Offer>()
                .Property(o => o.DiscountPercentage)
                .HasColumnType("decimal(5,2)");
        }
    }
}
using Microsoft.EntityFrameworkCore;

public class BibliotecaContext : DbContext

{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prestamo>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Prestamos) // Ajusta según la propiedad de navegación en Usuario
            .HasForeignKey(p => p.UsuarioId)
            .IsRequired(false); // O ajusta según tu lógica

        // Otras configuraciones pueden ir aquí...

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configuración de tu cadena de conexión u otras opciones aquí
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-576841Q\\MSSQLSERVER;Initial Catalog=GestionB; Integrated Security = true");
        }
    }


    public DbSet<AutorDto> AutorDto { get; set; }

    public DbSet<CategoriaDto> CategoriaDto { get; set; }

    public DbSet<EstadoPrestamoDto> EstadoPrestamoDto { get; set; }

    public DbSet<LibroDto> LibroDto { get; set; }

    public DbSet<PrestamoDto> PrestamoDto { get; set; }

    public DbSet<SancionDto> SancionDto { get; set; }

    public DbSet<UsuarioDto> UsuarioDto { get; set; }
}


namespace SQLEntity.Models;

public partial class HotelMaiorContext : DbContext
{
    public HotelMaiorContext()
    {
    }

    public HotelMaiorContext(DbContextOptions<HotelMaiorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Conta> Conta { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Filial> Filiais { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Iten> Itens { get; set; }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<Lavanderia> Lavanderia { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Quarto> Quartos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<TipoFuncionario> TipoFuncionarios { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }

    public virtual DbSet<TiposQuarto> TiposQuartos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HotelMaior;Trusted_Connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642B30F9782");

            entity.Property(e => e.IdCliente).ValueGeneratedNever();
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkEnderecoIdEndereco).HasColumnName("fk_Endereco_IdEndereco");
            entity.Property(e => e.Nacionalidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelefoneCliente)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkEnderecoIdEnderecoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.FkEnderecoIdEndereco)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Clientes__fk_End__4BAC3F29");
        });

        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(e => e.IdConta).HasName("PK__Conta__D599CC48CFC94709");

            entity.Property(e => e.IdConta).ValueGeneratedNever();
            entity.Property(e => e.FkReservasIdReserva).HasColumnName("fk_Reservas_IdReserva");
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ValorItens).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.FkReservasIdReservaNavigation).WithMany(p => p.Conta)
                .HasForeignKey(d => d.FkReservasIdReserva)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Conta__fk_Reserv__6477ECF3");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__Endereco__0B7C7F17E6625445");

            entity.ToTable("Endereco");

            entity.Property(e => e.IdEndereco).ValueGeneratedNever();
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Filial>(entity =>
        {
            entity.HasKey(e => e.IdFilial).HasName("PK__Filiais__05733A9953FEE02C");

            entity.Property(e => e.IdFilial).ValueGeneratedNever();
            entity.Property(e => e.FkEnderecoIdEndereco).HasColumnName("fk_Endereco_IdEndereco");
            entity.Property(e => e.NomeFilial)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkEnderecoIdEnderecoNavigation).WithMany(p => p.Filiais)
                .HasForeignKey(d => d.FkEnderecoIdEndereco)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Filiais__fk_Ende__5165187F");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("PK__Funciona__35CB052A73D2CC2E");

            entity.Property(e => e.IdFuncionario).ValueGeneratedNever();
            entity.Property(e => e.FkFiliaisIdFilial).HasColumnName("fk_Filiais_IdFilial");
            entity.Property(e => e.FkTipoFuncionarioIdTipoFuncionario).HasColumnName("fk_TipoFuncionario_IdTipoFuncionario");
            entity.Property(e => e.NomeFuncionario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkFiliaisIdFilialNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.FkFiliaisIdFilial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Funcionar__fk_Fi__5812160E");

            entity.HasOne(d => d.FkTipoFuncionarioIdTipoFuncionarioNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.FkTipoFuncionarioIdTipoFuncionario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Funcionar__fk_Ti__59063A47");
        });

        modelBuilder.Entity<Iten>(entity =>
        {
            entity.HasKey(e => e.IdItens).HasName("PK__Itens__C27D3FE9CC78D87B");

            entity.Property(e => e.IdItens).ValueGeneratedNever();
            entity.Property(e => e.DescricaoItem)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkFiliaisIdFilial).HasColumnName("fk_Filiais_IdFilial");
            entity.Property(e => e.ValorItem).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.FkFiliaisIdFilialNavigation).WithMany(p => p.Itens)
                .HasForeignKey(d => d.FkFiliaisIdFilial)
                .HasConstraintName("FK__Itens__fk_Filiai__6754599E");
        });

        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido).HasName("PK__ItensPed__F77088BA07525A9A");

            entity.Property(e => e.IdItemPedido).ValueGeneratedNever();
            entity.Property(e => e.DescricaoItem)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkPedidosIdPedido).HasColumnName("fk_Pedidos_IdPedido");
            entity.Property(e => e.ValorItem).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.FkPedidosIdPedidoNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.FkPedidosIdPedido)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ItensPedi__fk_Pe__72C60C4A");
        });

        modelBuilder.Entity<Lavanderia>(entity =>
        {
            entity.HasKey(e => e.IdLavanderia).HasName("PK__Lavander__C45ECFA31E080DDC");

            entity.Property(e => e.IdLavanderia).ValueGeneratedNever();
            entity.Property(e => e.DescricaoServico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkContaIdConta).HasColumnName("fk_Conta_IdConta");
            entity.Property(e => e.ValorServico).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.FkContaIdContaNavigation).WithMany(p => p.Lavanderia)
                .HasForeignKey(d => d.FkContaIdConta)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Lavanderi__fk_Co__6A30C649");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.CodigoNotaFiscal).HasName("PK__Pagament__F9C36FE576005D78");

            entity.ToTable("Pagamento");

            entity.Property(e => e.CodigoNotaFiscal)
                .ValueGeneratedNever()
                .HasColumnName("Codigo_NotaFiscal");
            entity.Property(e => e.CodigoTipoPagamento).HasColumnName("Codigo_TipoPagamento");
            entity.Property(e => e.DataNotaFiscal)
                .HasColumnType("datetime")
                .HasColumnName("Data_NotaFiscal");
            entity.Property(e => e.FkContaIdConta).HasColumnName("fk_Conta_IdConta");
            entity.Property(e => e.FkTipoPagamentoIdTipoPagamento).HasColumnName("fk_TipoPagamento_IdTipoPagamento");
            entity.Property(e => e.ValorTotalNotaFiscal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ValorTotal_NotaFiscal");

            entity.HasOne(d => d.FkContaIdContaNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.FkContaIdConta)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Pagamento__fk_Co__6EF57B66");

            entity.HasOne(d => d.FkTipoPagamentoIdTipoPagamentoNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.FkTipoPagamentoIdTipoPagamento)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Pagamento__fk_Ti__6FE99F9F");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__9D335DC3793D9B36");

            entity.Property(e => e.IdPedido).ValueGeneratedNever();
            entity.Property(e => e.FkClientesIdCliente).HasColumnName("fk_Clientes_IdCliente");

            entity.HasOne(d => d.FkClientesIdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.FkClientesIdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Pedidos__fk_Clie__4E88ABD4");
        });

        modelBuilder.Entity<Quarto>(entity =>
        {
            entity.HasKey(e => e.NumeroQuarto).HasName("PK__Quartos__DAD94D86771A5EE0");

            entity.Property(e => e.NumeroQuarto).ValueGeneratedNever();
            entity.Property(e => e.FkFiliaisIdFilial).HasColumnName("fk_Filiais_IdFilial");
            entity.Property(e => e.FkReservasIdReserva).HasColumnName("fk_Reservas_IdReserva");
            entity.Property(e => e.FkTiposQuartoIdQuarto).HasColumnName("fk_TiposQuarto_IdQuarto");

            entity.HasOne(d => d.FkFiliaisIdFilialNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.FkFiliaisIdFilial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Quartos__fk_Fili__5FB337D6");

            entity.HasOne(d => d.FkReservasIdReservaNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.FkReservasIdReserva)
                .HasConstraintName("FK__Quartos__fk_Rese__619B8048");

            entity.HasOne(d => d.FkTiposQuartoIdQuartoNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.FkTiposQuartoIdQuarto)
                .HasConstraintName("FK__Quartos__fk_Tipo__60A75C0F");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__0E49C69DD84E69E1");

            entity.Property(e => e.IdReserva).ValueGeneratedNever();
            entity.Property(e => e.FkClientesIdCliente).HasColumnName("fk_Clientes_IdCliente");
            entity.Property(e => e.FkFuncionariosIdFuncionario).HasColumnName("fk_Funcionarios_IdFuncionario");
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.FkClientesIdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkClientesIdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Reservas__fk_Cli__5BE2A6F2");

            entity.HasOne(d => d.FkFuncionariosIdFuncionarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkFuncionariosIdFuncionario)
                .HasConstraintName("FK__Reservas__fk_Fun__5CD6CB2B");
        });

        modelBuilder.Entity<TipoFuncionario>(entity =>
        {
            entity.HasKey(e => e.IdTipoFuncionario).HasName("PK__TipoFunc__B490BD21258C7659");

            entity.ToTable("TipoFuncionario");

            entity.Property(e => e.IdTipoFuncionario).ValueGeneratedNever();
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.IdTipoPagamento).HasName("PK__TipoPaga__D0F980A65906960C");

            entity.ToTable("TipoPagamento");

            entity.Property(e => e.IdTipoPagamento).ValueGeneratedNever();
            entity.Property(e => e.DescricaoTipoPag)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposQuarto>(entity =>
        {
            entity.HasKey(e => e.IdQuarto).HasName("PK__TiposQua__69B702BF4E59C7CC");

            entity.ToTable("TiposQuarto");

            entity.Property(e => e.IdQuarto).ValueGeneratedNever();
            entity.Property(e => e.DescricaoQuarto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValorQuarto).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

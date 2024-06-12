using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class ProfessorMap : BaseMap<Professor>
    {
        public ProfessorMap() : base("tb_professor")
        {
        }

        public override void Configure(EntityTypeBuilder<Professor> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Username).HasColumnName("username").IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").IsRequired();
            builder.Property(x => x.DisciplinaId).HasColumnName("disciplina_id").IsRequired();

            builder.HasOne(x => x.Disciplina).WithMany().HasForeignKey(x => x.DisciplinaId);
            // Não é necessário declarar a lista de Turmas aqui.
            // O EF Core gerenciará essa associação automaticamente.
        }
    }
}
